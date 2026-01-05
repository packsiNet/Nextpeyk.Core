using DomainLayer.Common.BaseEntities;

namespace DomainLayer.Entities;

public class ParcelCourier : BaseEntityModel, IAuditableEntity
{
    public int Row { get; set; }

    /// <summary>
    /// ServiceType = PolygonType (Collect - dest)
    /// </summary>
    public int ServiceType { get; set; }

    public int? CourierId { get; set; }

    public int ParcelId { get; set; }

    public string Barcode { get; set; }

    public string CollectFirstName { get; set; }

    public string CollectLastName { get; set; }

    public string CollectPhoneNumber { get; set; }

    public decimal CollectLatitude { get; set; }

    public decimal CollectLongitude { get; set; }

    public string DeliveryFirstName { get; set; }

    public string DeliveryLastName { get; set; }

    public string DeliveryPhoneNumber { get; set; }

    public decimal DeliveryLatitude { get; set; }

    public decimal DeliveryLongitude { get; set; }

    public string CollectAddress { get; set; }

    public string DeliveryAddress { get; set; }

    public bool HasFMCG { get; set; }

    public decimal CODAmount { get; set; }

    public bool IsCODPaid { get; set; }

    public decimal FreightCollectAmount { get; set; }

    public bool IsFreightCollectPaid { get; set; }

    public string VerificationCode { get; set; }

    public bool HasFirstMileVerification { get; set; }

    public bool HasLastMileVerification { get; set; }

    public int Status { get; set; }

    public TimeSpan From { get; set; }

    public TimeSpan To { get; set; }

    public Parcel Parcel { get; set; }

    public Courier Courier { get; set; }

    public ICollection<ParcelAssign> ParcelAssigns { get; set; } = [];
}