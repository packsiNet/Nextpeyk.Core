using DomainLayer.Common.BaseEntities;

namespace DomainLayer.Entities;

public class CourierBoxSize : BaseEntityModel
{
    public int CourierId { get; set; }
    public int BoxSizeId { get; set; }

    public virtual Courier Courier { get; set; }
}
