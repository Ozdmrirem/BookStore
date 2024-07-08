using KitapMagaza.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BookStore.Context
{
    public class DapperContext:IdentityDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //tablomu veritabanına yansıtmak için baglantıyı burada yapacagım
            //ilerleyen sureclerde bu baglantıyı appsettings.json 'a tasıyacagım.
            //bu kısım artık olmasada olur
            optionsBuilder.UseSqlServer("Server=localhost,1440;initial Catalog = BookStore;User=sa;Password=123456aA.");
        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<BasketTotal> BasketTotals { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<CashBox> CashBoxes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Selling> Sellings { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Author varlığını anahtarsız olarak yapılandırın
            modelBuilder.Entity<BasketItem>()
                .HasNoKey();
            modelBuilder.Entity<BasketTotal>()
                .HasNoKey();
        }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
