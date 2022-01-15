using Microsoft.EntityFrameworkCore;
using SimpleCart.Core.Interfaces;
using SimpleCart.Core.Models.Carts;
using SimpleCart.Core.Models.Orders;
using SimpleCart.Core.Models.Products;
using SimpleCart.Core.Models.Users;

namespace SimpleCart.Infrastructure.Persistence;

public class ApplicationDatabaseContext : DbContext, IUnitOfWork
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public Task<int> Commit()
    {
        return this.SaveChangesAsync();
    }

    public ApplicationDatabaseContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDatabaseContext).Assembly);
    }
}