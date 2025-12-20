using MediatR;
using ApplicationLayer;

namespace ApplicationLayer.Features.FleetApplications.Query;

public record GetParcelsQuery : IRequest<HandlerResult>;
