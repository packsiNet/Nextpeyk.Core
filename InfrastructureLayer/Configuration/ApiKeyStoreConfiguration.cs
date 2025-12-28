using DomainLayer.Entities;
using InfrastructureLayer.Configuration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainLayer.Configuration
{
    public class ApiKeyStoreConfiguration : BaseEntityConfiguration<ApiKeyStore>
    {
        public override void Configure(EntityTypeBuilder<ApiKeyStore> builder)
        {
            base.Configure(builder);
        }
    }
}