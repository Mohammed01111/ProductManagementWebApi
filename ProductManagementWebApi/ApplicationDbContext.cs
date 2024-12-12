using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using ProductManagementWebApi.Models;

namespace ProductManagementWebApi
{

    public class ApplicationDbContext : DbContext
    {
        // DbSet for Products
        public DbSet<Product> Products { get; set; }

        // Constructor with options
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Product entity
            modelBuilder.Entity<Product>(entity =>
            {
                // Primary key configuration
                entity.HasKey(p => p.Id);

                // Property configurations
                entity.Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(p => p.Price)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)");

                entity.Property(p => p.Category)
                    .HasMaxLength(50)
                    .HasDefaultValue("general");

                entity.Property(p => p.DateAdded)
                    .HasDefaultValueSql("GETUTCDATE()");

                // Optional: Index for faster querying
                entity.HasIndex(p => p.Category);
                entity.HasIndex(p => p.DateAdded);
            });
        }

        // Optional: Override SaveChanges to handle DateAdded
        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is Product && e.State == EntityState.Added);

            foreach (var entityEntry in entries)
            {
                if (entityEntry.Entity is Product product)
                {
                    // Ensure DateAdded is set when a new product is added
                    if (product.DateAdded == default)
                    {
                        product.DateAdded = DateTime.UtcNow;
                    }
                }
            }

            return base.SaveChanges();
        }
    }
    
}




