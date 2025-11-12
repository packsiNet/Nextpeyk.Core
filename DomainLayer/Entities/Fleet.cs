using DomainLayer.Common.BaseEntities;

namespace DomainLayer.Entities;

public class Fleet : BaseEntityModel, IAuditableEntity
{
    public int UserAccountId { get; set; }

    public int CourierId { get; set; }

    public int FleetTypeId { get; set; }

    public int? ContractId { get; set; }

    public string Description { get; set; }

    public string Plaque { get; set; }

    public string DrivingLicense { get; set; }

    public Courier Courier { get; set; }

    public Contract Contract { get; set; }

    public FleetType FleetType { get; set; }

    public UserAccount UserAccount { get; set; }
}