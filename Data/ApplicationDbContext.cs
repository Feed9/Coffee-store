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
        public DbSet<Product> Products { get; set; } = null!;       
        public DbSet<CancellationRequest> CancellationRequests { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Addition> Additions { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderItem> OrderItems { get; set; } = null!;
        public DbSet<PriceVolume> PricesVolumes { get; set; } = null!;


    }
}