using DomainLayer.Entities;
using InfrastructureLayer.Configuration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainLayer.Configuration;

public class FleetTypeConfiguration : BaseEntityConfiguration<FleetType>
{
    public override void Configure(EntityTypeBuilder<FleetType> builder)
    {
        base.Configure(builder);

        builder.Property(current => current.Title).IsRequired();
    }
}