using Economy.Models;
using Economy.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.Text;

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
    services.AddScoped<UserService, UserService>();

    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience = builder.Configuration["Jwt:Audience"],
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });
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
