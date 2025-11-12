using DomainLayer.Common.BaseEntities;

namespace DomainLayer.Entities;

public class FleetType : BaseEntityModel, IAuditableEntity
{
    public string Title { get; set; }

    public ICollection<Fleet> Fleets { get; set; } = [];
}