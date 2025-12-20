using DomainLayer.Common.BaseEntities;

namespace DomainLayer.Entities;

public class ParcelAssign : BaseEntityModel, IAuditableEntity
{
    public int ParcelCourierId { get; set; }

    public int FleetId { get; set; }

    public int Sort { get; set; }

    public ParcelCourier ParcelCourier { get; set; }

    public Fleet Fleet { get; set; }

}