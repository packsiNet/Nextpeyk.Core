using DomainLayer.Entities;
using InfrastructureLayer.Configuration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainLayer.Configuration;

public class ParcelAssignConfiguration : BaseEntityConfiguration<ParcelAssign>
{
    public override void Configure(EntityTypeBuilder<ParcelAssign> builder)
    {
        base.Configure(builder);

        builder.HasOne(current => current.ParcelCourier)
               .WithMany(current => current.ParcelAssigns)
               .HasForeignKey(current => current.ParcelCourierId);

        builder.HasOne(current => current.Fleet)
               .WithMany()
               .HasForeignKey(current => current.FleetId);
    }
}
