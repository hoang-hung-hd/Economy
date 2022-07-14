using Microsoft.EntityFrameworkCore;

namespace Economy.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
            // Bỏ tiền tố AspNet của các bảng: mặc định
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
                }
            }

            builder.Entity<StockModel>().HasKey(u => new
            {
                u.ProductId,
                u.StoreId
            });
        }

        public DbSet<CategoryModel> Category { set; get; }
        public DbSet<BrandModel> Brand { set; get; }
        public DbSet<ProductModel> Product { set; get; }
        public DbSet<StoreModel> Store { set; get; }
        public DbSet<StockModel> Stock { set; get; }
        public DbSet<CustomerModel> Customer { set; get; }
        public DbSet<StaffModel> Staff { set; get; }
        public DbSet<BillModel> Bill { set; get; }
        public DbSet<ListItemModel> ListItem { set; get; }
        public DbSet<UserModel> Users { set; get; }
    }
}
