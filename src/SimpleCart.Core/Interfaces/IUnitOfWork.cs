using Microsoft.EntityFrameworkCore;
using SimpleCart.Core.Models.ProductAggregate;

namespace SimpleCart.Core.Interfaces;

public interface IUnitOfWork
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
}