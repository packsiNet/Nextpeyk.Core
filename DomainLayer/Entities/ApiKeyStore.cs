using DomainLayer.Common.BaseEntities;

namespace DomainLayer.Entities;

public class ApiKeyStore : BaseEntityModel, IAuditableEntity
{
    public int UserAccountId { get; set; }

    public string ApiKey { get; set; }

    public UserAccount UserAccount { get; set; }
}