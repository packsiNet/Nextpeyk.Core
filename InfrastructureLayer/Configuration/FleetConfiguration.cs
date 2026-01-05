using DomainLayer.Entities;
using InfrastructureLayer.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainLayer.Configuration;

public class FleetConfiguration : BaseEntityConfiguration<Fleet>
{
    public override void Configure(EntityTypeBuilder<Fleet> builder)
    {
        base.Configure(builder);

        builder.HasOne(current => current.UserAccount).WithMany(current => current.Fleets).HasForeignKey(current => current.UserAccountId);
        builder.HasOne(current => current.Courier).WithMany(current => current.Fleets).HasForeignKey(current => current.CourierId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(current => current.FleetType).WithMany(current => current.Fleets).HasForeignKey(current => current.FleetTypeId);
        builder.HasOne(current => current.Contract).WithMany(current => current.Fleets).HasForeignKey(current => current.ContractId);
    }
}