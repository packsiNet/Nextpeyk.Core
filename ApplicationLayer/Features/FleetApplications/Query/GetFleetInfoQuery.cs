using MediatR;

namespace ApplicationLayer.Features.FleetApplications.Query;

public record GetFleetInfoQuery : IRequest<HandlerResult>;