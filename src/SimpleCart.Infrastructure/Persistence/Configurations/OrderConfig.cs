using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleCart.Core.Models.Carts;
using SimpleCart.Core.Models.Orders;

namespace SimpleCart.Infrastructure.Persistence.Configurations;

public class OrderConfig : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.Property(x => x.TrackingId).IsRequired();
        builder.Property(x => x.DeliveryDate).IsRequired();
        builder.Property(x => x.PaymentType).HasConversion<string>().IsRequired();
        builder.Property(x => x.PaymentStatus).HasConversion<string>().IsRequired();
        builder.Property(x => x.Status).HasConversion<string>().IsRequired();
        builder.HasIndex(x => x.TrackingId).IsUnique();
        
        builder.OwnsOne(x => x.Customer, c =>
        {
            c.Property(x => x.Id).IsRequired().HasColumnName("CustomerId");
            c.Property(x => x.Name).IsRequired().HasColumnName("CustomerName");
        });
        builder.HasMany(x => x.Items)
            .WithOne(i => i.Order)
            .HasForeignKey(i => i.OrderId);

        builder.Metadata.FindNavigation(nameof(Cart.Items))
            ?.SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}