using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfrastructureLayer.Configuration;

public class GpsFleetConfiguration : BaseEntityConfiguration<GpsFleet>
{
    public override void Configure(EntityTypeBuilder<GpsFleet> builder)
    {
        base.Configure(builder);

        builder.ToTable("GpsFleets");

        builder.Property(x => x.Location).HasColumnType("geometry");

        builder.HasOne(x => x.Fleet)
            .WithMany()
            .HasForeignKey(x => x.FleetId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
