using DomainLayer.Common.BaseEntities;

namespace DomainLayer.Entities
{
    public class Province : BaseEntityModel, IAuditableEntity
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public ICollection<City> Cities { get; set; } = [];
    }
}