using DomainLayer.Entities;
using InfrastructureLayer.Configuration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainLayer.Configuration
{
    public class CourierConfiguration : BaseEntityConfiguration<Courier>
    {
        public override void Configure(EntityTypeBuilder<Courier> builder)
        {
            base.Configure(builder);

            builder.Property(current => current.Title).HasMaxLength(100);
            builder.Property(current => current.Description).HasMaxLength(1000);

            builder.HasOne(current => current.UserAccount).WithMany(current => current.Couriers).HasForeignKey(current => current.UserAccountId);
            //builder.HasOne(current => current.CourierType).WithMany(current => current.Couriers).HasForeignKey(current => current.CourierTypeId);
            builder.HasOne(current => current.City).WithMany(current => current.Couriers).HasForeignKey(current => current.CityId);
            builder.HasOne(current => current.Contract).WithMany(current => current.Couriers).HasForeignKey(current => current.ContractId);
        }
    }
}