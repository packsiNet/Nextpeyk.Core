using ApplicationLayer.Extensions;
using ApplicationLayer.Features.FleetApplications.Command;
using ApplicationLayer.Interfaces.FleetApplications;
using MediatR;

namespace ApplicationLayer.Features.FleetApplications.Handler;

public class CustomSendStatusHandler(IFleetApplicationServices services) : IRequestHandler<CustomSendStatusCommand, HandlerResult>
{
    public async Task<HandlerResult> Handle(CustomSendStatusCommand request, CancellationToken cancellationToken)
    {
        var result = await services.CustomSendStatusAsync();
        return result.ToHandlerResult();
    }
}