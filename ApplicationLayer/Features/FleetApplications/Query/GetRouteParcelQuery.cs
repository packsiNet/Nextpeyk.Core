using MediatR;
using ApplicationLayer;

namespace ApplicationLayer.Features.FleetApplications.Query;

public record GetRouteParcelQuery : IRequest<HandlerResult>;