using DomainLayer.Entities;
using InfrastructureLayer.Configuration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainLayer.Configuration;

public class ParcelCourierConfiguration : BaseEntityConfiguration<ParcelCourier>
{
    public override void Configure(EntityTypeBuilder<ParcelCourier> builder)
    {
        base.Configure(builder);

        builder.Property(current => current.Barcode).HasMaxLength(100);

        builder.Property(current => current.CollectFirstName).HasMaxLength(100);
        builder.Property(current => current.CollectLastName).HasMaxLength(100);
        builder.Property(current => current.CollectPhoneNumber).HasMaxLength(20);
        builder.Property(current => current.CollectAddress).HasMaxLength(500);

        builder.Property(current => current.DeliveryFirstName).HasMaxLength(100);
        builder.Property(current => current.DeliveryLastName).HasMaxLength(100);
        builder.Property(current => current.DeliveryPhoneNumber).HasMaxLength(20);
        builder.Property(current => current.DeliveryAddress).HasMaxLength(500);

        builder.Property(current => current.CollectLatitude).HasPrecision(18, 8);
        builder.Property(current => current.CollectLongitude).HasPrecision(18, 8);
        builder.Property(current => current.DeliveryLatitude).HasPrecision(18, 8);
        builder.Property(current => current.DeliveryLongitude).HasPrecision(18, 8);

        builder.Property(current => current.CODAmount).HasPrecision(18, 2);
        builder.Property(current => current.FreightCollectAmount).HasPrecision(18, 2);
        
        builder.Property(current => current.VerificationCode).HasMaxLength(10);

        builder.HasOne(current => current.Parcel)
               .WithMany()
               .HasForeignKey(current => current.ParcelId);

        builder.HasOne(current => current.Courier)
               .WithMany()
               .HasForeignKey(current => current.CourierId);
    }
}
