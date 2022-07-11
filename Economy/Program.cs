using Economy.Models;
using Economy.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
{
    var services = builder.Services;
    var env = builder.Environment;

    services.AddDbContext<AppDbContext>(options => {
        string connectString = builder.Configuration.GetConnectionString("SimpleApi");
        options.UseSqlServer(connectString);
    });
    services.AddCors();

    // Đăng ký các dịch vụ của Identity
    services.AddIdentity<AppUser, IdentityRole>()
        .AddEntityFrameworkStores<AppDbContext>()
        .AddDefaultTokenProviders();

    // Truy cập IdentityOptions
    services.Configure<IdentityOptions>(options => {
        // Thiết lập về Password
        options.Password.RequireDigit = false; // Không bắt phải có số
        options.Password.RequireLowercase = false; // Không bắt phải có chữ thường
        options.Password.RequireNonAlphanumeric = false; // Không bắt ký tự đặc biệt
        options.Password.RequireUppercase = false; // Không bắt buộc chữ in
        options.Password.RequiredLength = 3; // Số ký tự tối thiểu của password
        options.Password.RequiredUniqueChars = 1; // Số ký tự riêng biệt

        // Cấu hình Lockout - khóa user
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // Khóa 5 phút
        options.Lockout.MaxFailedAccessAttempts = 5; // Thất bại 5 lầ thì khóa
        options.Lockout.AllowedForNewUsers = true;

        // Cấu hình về User.
        options.User.AllowedUserNameCharacters = // các ký tự đặt tên user
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
        options.User.RequireUniqueEmail = true; // Email là duy nhất

        // Cấu hình đăng nhập.
        options.SignIn.RequireConfirmedEmail = true; // Cấu hình xác thực địa chỉ email (email phải tồn tại)
        options.SignIn.RequireConfirmedPhoneNumber = false; // Xác thực số điện thoại

    });

    // Cấu hình Cookie
    services.ConfigureApplicationCookie(options => {
        // options.Cookie.HttpOnly = true;  
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
        options.LoginPath = $"/login/";                                 // Url đến trang đăng nhập
        options.LogoutPath = $"/logout/";
        options.AccessDeniedPath = $"/Identity/Account/AccessDenied";   // Trang khi User bị cấm truy cập
    });
    services.Configure<SecurityStampValidatorOptions>(options =>
    {
        // Trên 5 giây truy cập lại sẽ nạp lại thông tin User (Role)
        // SecurityStamp trong bảng User đổi -> nạp lại thông tinn Security
        options.ValidationInterval = TimeSpan.FromSeconds(5);
    });

    services.AddScoped<IBrandService, BrandService>();
    services.AddScoped<CategoryService, CategoryService>();
    services.AddScoped<ProductService, ProductService>();
}

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

{
    // global cors policy
    app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
    app.MapControllers();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
