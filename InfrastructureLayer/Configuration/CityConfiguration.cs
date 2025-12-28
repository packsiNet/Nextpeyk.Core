using DomainLayer.Entities;
using InfrastructureLayer.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainLayer.Configuration;

public class CityConfiguration : BaseEntityConfiguration<City>
{
    public override void Configure(EntityTypeBuilder<City> builder)
    {
        base.Configure(builder);

        builder.Property(current => current.Name).IsRequired();
        builder.Property(current => current.Code).IsRequired();
        builder.Property(c => c.CenterPoint).HasColumnType("geography");
        builder.Property(c => c.Boundary).HasColumnType("geography");

        builder.HasOne(current => current.Province).WithMany(current => current.Cities).HasForeignKey(current => current.ProvinceId);
    }
}