using DomainLayer.Entities;
using InfrastructureLayer.Configuration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainLayer.Configuration;

public class SettingConfiguration : BaseEntityConfiguration<Setting>
{
    public override void Configure(EntityTypeBuilder<Setting> builder)
    {
        base.Configure(builder);

        builder.Property(current => current.Key).HasMaxLength(100);
        builder.Property(current => current.Value).HasMaxLength(4000); // Allow longer values for settings
    }
}
