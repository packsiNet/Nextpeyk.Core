using DomainLayer.Common.BaseEntities;

namespace DomainLayer.Entities;

public class ParcelTrackingAttachment : BaseEntityModel, IAuditableEntity
{
    public int ParcelTrackingId { get; set; }

    public string FileName { get; set; }

    public ParcelTracking ParcelTracking { get; set; }
}
