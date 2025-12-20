using MediatR;
using ApplicationLayer;

namespace ApplicationLayer.Features.FleetApplications.Query;

public record GetFleetActivityPerDayAppQuery : IRequest<HandlerResult>;