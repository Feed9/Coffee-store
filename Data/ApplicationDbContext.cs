using Coffee_store.Data.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Coffee_store.Data
{


    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Addition> Additions { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItemAdditions> OrderItemAdditions { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<PriceVolume> PricesVolumes { get; set; }


    }
}