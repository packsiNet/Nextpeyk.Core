using DomainLayer.Common.BaseEntities;
using NetTopologySuite.Geometries;

namespace DomainLayer.Entities
{
    public class City : BaseEntityModel, IAuditableEntity
    {
        public int ProvinceId { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public Point CenterPoint { get; set; }

        public Polygon Boundary { get; set; }

        public Province Province { get; set; }

        public virtual ICollection<Courier> Couriers { get; set; } = [];
    }
}