using DomainLayer.Common.BaseEntities;
using NetTopologySuite.Geometries;

namespace DomainLayer.Entities;

public class GpsFleet : BaseEntityModel, IAuditableEntity
{
    public int FleetId { get; set; }

    public Point Location { get; set; }

    public Fleet Fleet { get; set; }
}
