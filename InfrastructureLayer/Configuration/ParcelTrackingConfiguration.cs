using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfrastructureLayer.Configuration;

public class ParcelTrackingConfiguration : BaseEntityConfiguration<ParcelTracking>
{
    public override void Configure(EntityTypeBuilder<ParcelTracking> builder)
    {
        base.Configure(builder);

        builder.ToTable("ParcelTrackings");

        builder.Property(x => x.Description).HasMaxLength(1000);

        builder.HasOne(x => x.Fleet)
            .WithMany()
            .HasForeignKey(x => x.FleetIdId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
