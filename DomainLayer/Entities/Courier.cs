using DomainLayer.Common.BaseEntities;

namespace DomainLayer.Entities;

public class Courier : BaseEntityModel, IAuditableEntity
{
    public int UserAccountId { get; set; }

    public int ContractId { get; set; }

    public int CityId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string Logo { get; set; }

    public string SupportPhoneNumber { get; set; }

    public string SupportFullName { get; set; }

    public string Website { get; set; }

    public bool HasFMCG { get; set; }

    public bool HasPackaging { get; set; }

    public bool HasCOD { get; set; }

    public bool HasFreightCollect { get; set; }

    public int DailyCcapacity { get; set; }

    public int MaxShipmentWeight { get; set; }

    public int MinParcelsOrder { get; set; }

    public Contract Contract { get; set; }

    public UserAccount UserAccount { get; set; }

    public City City { get; set; }

    public ICollection<Fleet> Fleets { get; set; } = [];
}