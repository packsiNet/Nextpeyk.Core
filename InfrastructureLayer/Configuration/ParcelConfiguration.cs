using DomainLayer.Entities;
using InfrastructureLayer.Configuration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainLayer.Configuration;

public class ParcelConfiguration : BaseEntityConfiguration<Parcel>
{
    public override void Configure(EntityTypeBuilder<Parcel> builder)
    {
        base.Configure(builder);

        builder.Property(current => current.OrderId).HasMaxLength(50);
        builder.Property(current => current.Barcode).HasMaxLength(100);
        
        builder.Property(current => current.SenderFirstName).HasMaxLength(100);
        builder.Property(current => current.SenderLastName).HasMaxLength(100);
        builder.Property(current => current.SenderPhoneNumber).HasMaxLength(20);
        builder.Property(current => current.SenderAddress).HasMaxLength(500);

        builder.Property(current => current.ReciverFirstName).HasMaxLength(100);
        builder.Property(current => current.ReciverLastName).HasMaxLength(100);
        builder.Property(current => current.ReciverPhoneNumber).HasMaxLength(20);
        builder.Property(current => current.ReciverAddress).HasMaxLength(500);

        builder.Property(current => current.SenderLatitude).HasPrecision(18, 8);
        builder.Property(current => current.SenderLongitude).HasPrecision(18, 8);
        builder.Property(current => current.ReciverLatitude).HasPrecision(18, 8);
        builder.Property(current => current.ReciverLongitude).HasPrecision(18, 8);
        
        builder.Property(current => current.Value).HasPrecision(18, 2);
    }
}
