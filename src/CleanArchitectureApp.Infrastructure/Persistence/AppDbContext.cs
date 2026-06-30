using CleanArchitectureApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureApp.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Order> Orders => Set<Order>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(p => p.Name).IsRequired().HasMaxLength(200);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasOne(o => o.Product)
                  .WithMany(p => p.Orders)
                  .HasForeignKey(o => o.ProductId);
        });

        base.OnModelCreating(modelBuilder);
    }
}
