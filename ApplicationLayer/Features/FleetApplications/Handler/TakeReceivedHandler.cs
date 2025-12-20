using ApplicationLayer.Extensions;
using ApplicationLayer.Features.FleetApplications.Command;
using ApplicationLayer.Interfaces.FleetApplications;
using MediatR;

namespace ApplicationLayer.Features.FleetApplications.Handler;

public class TakeReceivedHandler(IFleetApplicationServices services) : IRequestHandler<TakeReceivedCommand, HandlerResult>
{
    public async Task<HandlerResult> Handle(TakeReceivedCommand request, CancellationToken cancellationToken)
    {
        var result = await services.TakeReceivedAsync();
        return result.ToHandlerResult();
    }
}