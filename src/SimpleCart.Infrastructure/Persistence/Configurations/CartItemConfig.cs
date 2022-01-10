using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleCart.Core.Models.Carts;

namespace SimpleCart.Infrastructure.Persistence.Configurations;

public class CartItemConfig : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.Property(x => x.UnitPrice).IsRequired();
        builder.Property(x => x.Quantity).IsRequired();
        builder.Property(x => x.ProductId).IsRequired();
        builder.Property(x => x.CartId).IsRequired();
    }
}