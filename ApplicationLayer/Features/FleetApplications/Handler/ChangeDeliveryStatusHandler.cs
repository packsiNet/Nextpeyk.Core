using ApplicationLayer.Extensions;
using ApplicationLayer.Features.FleetApplications.Command;
using ApplicationLayer.Interfaces.FleetApplications;
using MediatR;

namespace ApplicationLayer.Features.FleetApplications.Handler;

public class ChangeDeliveryStatusHandler(IFleetApplicationServices services) : IRequestHandler<ChangeDeliveryStatusCommand, HandlerResult>
{
    public async Task<HandlerResult> Handle(ChangeDeliveryStatusCommand request, CancellationToken cancellationToken)
    {
        var result = await services.ChangeDeliveryStatusAsync();
        return result.ToHandlerResult();
    }
}