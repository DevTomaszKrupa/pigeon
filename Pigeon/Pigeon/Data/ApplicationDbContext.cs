using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Pigeon.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCard> ShoppingCards { get; set; }
        public DbSet<ShoppingCardProduct> ShoppingCardProducts { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Product>()
                   .HasKey(x => x.ProductId);

            builder.Entity<Product>()
                .HasMany(x => x.OrderProducts)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductId);
        }
    }
}