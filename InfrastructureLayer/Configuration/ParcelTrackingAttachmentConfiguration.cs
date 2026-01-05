using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfrastructureLayer.Configuration;

public class ParcelTrackingAttachmentConfiguration : BaseEntityConfiguration<ParcelTrackingAttachment>
{
    public override void Configure(EntityTypeBuilder<ParcelTrackingAttachment> builder)
    {
        base.Configure(builder);

        builder.ToTable("ParcelTrackingAttachments");

        builder.Property(x => x.FileName).HasMaxLength(255);

        builder.HasOne(x => x.ParcelTracking)
            .WithMany(x => x.ParcelTrackingAttachments)
            .HasForeignKey(x => x.ParcelTrackingId);
    }
}
