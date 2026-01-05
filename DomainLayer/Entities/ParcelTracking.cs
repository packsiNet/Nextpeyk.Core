using DomainLayer.Common.BaseEntities;

namespace DomainLayer.Entities;

public class ParcelTracking : BaseEntityModel, IAuditableEntity
{
    public int ParcelId { get; set; }

    public int? FleetIdId { get; set; }

    public int Status { get; set; }

    public string Description { get; set; }

    public Fleet Fleet { get; set; }

    public ICollection<ParcelTrackingAttachment> ParcelTrackingAttachments { get; set; } = [];
}
