using ApplicationLayer.Extensions;
using ApplicationLayer.Features.FleetApplications.Command;
using ApplicationLayer.Interfaces.FleetApplications;
using MediatR;

namespace ApplicationLayer.Features.FleetApplications.Handler;

public class TakeDeliveredHandler(IFleetApplicationServices services) : IRequestHandler<TakeDeliveredCommand, HandlerResult>
{
    public async Task<HandlerResult> Handle(TakeDeliveredCommand request, CancellationToken cancellationToken)
    {
        var result = await services.TakeDeliveredAsync();
        return result.ToHandlerResult();
    }
}