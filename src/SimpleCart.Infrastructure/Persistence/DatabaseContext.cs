using Microsoft.EntityFrameworkCore;
using SimpleCart.Core.Interfaces;
using SimpleCart.Core.Models.Carts;
using SimpleCart.Core.Models.Products;
using SimpleCart.Core.Models.Users;

namespace SimpleCart.Infrastructure.Persistence;

public class DatabaseContext : DbContext, IUnitOfWork
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
    }
}