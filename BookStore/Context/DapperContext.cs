using BookStore.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BookStore.Context
{
    public class DapperContext : IdentityDbContext
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
            optionsBuilder.UseSqlServer(_connectionString);
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

            // No-key entity configurations (if needed)
            modelBuilder.Entity<BasketItem>().HasNoKey();
            modelBuilder.Entity<BasketTotal>().HasNoKey();
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
