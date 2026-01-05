using DomainLayer.Entities;
using InfrastructureLayer.Configuration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainLayer.Configuration;

public class ContractConfiguration : BaseEntityConfiguration<Contract>
{
    public override void Configure(EntityTypeBuilder<Contract> builder)
    {
        base.Configure(builder);

        builder.Property(current => current.Title).HasMaxLength(200);
    }
}
