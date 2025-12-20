using MediatR;
using ApplicationLayer;

namespace ApplicationLayer.Features.FleetApplications.Command;

public record DeclineReceivedCommand : IRequest<HandlerResult>;