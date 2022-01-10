using Microsoft.EntityFrameworkCore;
using SimpleCart.Core.Models.CartAggregate;
using SimpleCart.Core.Models.ProductAggregate;
using SimpleCart.Core.Models.UserAggregate;

namespace SimpleCart.Core.Interfaces;

public interface IUnitOfWork
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
}