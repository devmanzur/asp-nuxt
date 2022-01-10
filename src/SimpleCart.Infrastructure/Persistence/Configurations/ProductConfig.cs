using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleCart.Core.Models.Products;

namespace SimpleCart.Infrastructure.Persistence.Configurations;

public class ProductConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Description).IsRequired().HasMaxLength(300);
        builder.Property(x => x.ImageUri).IsRequired();
        builder.Property(x => x.Price).IsRequired();
        builder.Property(x => x.CategoryId).IsRequired();
    }
}