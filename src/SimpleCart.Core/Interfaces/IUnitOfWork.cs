using Microsoft.EntityFrameworkCore;
using SimpleCart.Core.Models.Carts;
using SimpleCart.Core.Models.Products;
using SimpleCart.Core.Models.Users;

namespace SimpleCart.Core.Interfaces;

public interface IUnitOfWork
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    Task<int> Commit();
}