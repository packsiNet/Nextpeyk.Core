using MediatR;
using ApplicationLayer;

namespace ApplicationLayer.Features.FleetApplications.Command;

public record LocationFleetCommand : IRequest<HandlerResult>;