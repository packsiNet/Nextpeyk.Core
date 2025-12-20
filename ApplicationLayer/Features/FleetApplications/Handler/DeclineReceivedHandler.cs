using ApplicationLayer.Extensions;
using ApplicationLayer.Features.FleetApplications.Command;
using ApplicationLayer.Interfaces.FleetApplications;
using MediatR;

namespace ApplicationLayer.Features.FleetApplications.Handler;

public class DeclineReceivedHandler(IFleetApplicationServices services) : IRequestHandler<DeclineReceivedCommand, HandlerResult>
{
    public async Task<HandlerResult> Handle(DeclineReceivedCommand request, CancellationToken cancellationToken)
    {
        var result = await services.DeclineReceivedAsync();
        return result.ToHandlerResult();
    }
}