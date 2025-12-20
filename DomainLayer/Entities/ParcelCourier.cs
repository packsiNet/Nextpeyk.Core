using DomainLayer.Common.BaseEntities;

namespace DomainLayer.Entities;

public class Parcel : BaseEntityModel, IAuditableEntity
{
    public string OrderId { get; set; }

    public string Barcode { get; set; }

    public int PackageFormatId { get; set; }

    public int Length { get; set; }

    public int Width { get; set; }

    public int Height { get; set; }

    public int Weight { get; set; }

    public decimal Value { get; set; }

    public string SenderFirstName { get; set; }

    public string SenderLastName { get; set; }

    public string SenderPhoneNumber { get; set; }

    public decimal SenderLatitude { get; set; }

    public decimal SenderLongitude { get; set; }

    public string ReciverFirstName { get; set; }

    public string ReciverLastName { get; set; }

    public string ReciverPhoneNumber { get; set; }

    public decimal ReciverLatitude { get; set; }

    public decimal ReciverLongitude { get; set; }

    public string SenderAddress { get; set; }

    public string ReciverAddress { get; set; }

    public int State { get; set; }
}