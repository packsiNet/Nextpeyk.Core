using DomainLayer.Common.BaseEntities;

namespace DomainLayer.Entities;

public class Contract : BaseEntityModel, IAuditableEntity
{
    public string Title { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public string Description { get; set; }

    public ICollection<Fleet> Fleets { get; set; } = [];

    public ICollection<Courier> Couriers { get; set; } = [];
}