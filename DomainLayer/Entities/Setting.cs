using DomainLayer.Common.BaseEntities;

namespace DomainLayer.Entities;

public class Setting : BaseEntityModel, IAuditableEntity
{
    public string Key { get; set; }

    public string Value { get; set; }
}