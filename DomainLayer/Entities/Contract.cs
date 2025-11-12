using DomainLayer.Common.BaseEntities;

namespace DomainLayer.Entities;

public class Contract : BaseEntityModel, IAuditableEntity
{
    public string Title { get; set; }

    public ICollection<Fleet> Fleets { get; set; } = [];

    public ICollection<Courier> Couriers { get; set; } = [];
}