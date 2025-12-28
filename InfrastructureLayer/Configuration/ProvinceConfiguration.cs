using DomainLayer.Entities;
using InfrastructureLayer.Configuration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainLayer.Configuration;

public class ProvinceConfiguration : BaseEntityConfiguration<Province>
{
    public override void Configure(EntityTypeBuilder<Province> builder)
    {
        base.Configure(builder);

        builder.Property(current => current.Name).IsRequired();
        builder.Property(current => current.Code).IsRequired();
    }
}