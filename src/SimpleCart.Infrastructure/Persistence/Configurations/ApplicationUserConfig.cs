using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleCart.Core.Models.Users;

namespace SimpleCart.Infrastructure.Persistence.Configurations;

public class ApplicationUserConfig : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(x => x.FirstName).IsRequired().HasMaxLength(100);
        builder.Property(x => x.LastName).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Username).IsRequired().HasMaxLength(100);
        builder.HasIndex(x => x.Username).IsUnique();
        builder.Property(x => x.AuthenticationProvider).HasConversion<string>().IsRequired();

        builder.OwnsOne(x => x.Address, a =>
        {
            a.WithOwner();
            a.Property(x => x.Title).IsRequired().HasMaxLength(100);
            a.Property(x => x.State).IsRequired().HasMaxLength(100);
            a.Property(x => x.Country).IsRequired().HasMaxLength(100);
            a.Property(x => x.City).IsRequired().HasMaxLength(100);
            a.Property(x => x.Street).IsRequired().HasMaxLength(200);
            a.Property(x => x.ZipCode).IsRequired().HasMaxLength(10);
        });

    }
}