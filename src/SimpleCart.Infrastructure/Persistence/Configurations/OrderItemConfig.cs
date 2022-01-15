using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleCart.Core.Models.Orders;

namespace SimpleCart.Infrastructure.Persistence.Configurations;

public class OrderItemConfig : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.Property(x => x.UnitPrice).IsRequired();
        builder.Property(x => x.Quantity).IsRequired();
        builder.Property(x => x.ProductId).IsRequired();
        builder.Property(x => x.OrderId).IsRequired();
    }
}