using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleCart.Core.Models.Products;

namespace SimpleCart.Infrastructure.Persistence.Configurations;

public class CategoryConfig : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Description).IsRequired().HasMaxLength(300);
        builder.HasIndex(x => x.Name).IsUnique();
        builder.HasMany(x => x.Products)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.CategoryId);
        
        builder.Metadata.FindNavigation(nameof(Category.Products))
            ?.SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}