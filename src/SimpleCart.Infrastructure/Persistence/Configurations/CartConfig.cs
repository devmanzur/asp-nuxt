using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleCart.Core.Models.Carts;

namespace SimpleCart.Infrastructure.Persistence.Configurations;

public class CartConfig : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.HasOne(x => x.Owner);
        builder.Property(x => x.OwnerId).IsRequired();
        builder.HasMany(x => x.Items)
            .WithOne(i => i.Cart)
            .HasForeignKey(i => i.CartId);
        
        builder.Metadata.FindNavigation(nameof(Cart.Items))
            ?.SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}