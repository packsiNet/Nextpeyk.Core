using ApplicationLayer.Extensions;
using ApplicationLayer.Features.FleetApplications.Command;
using ApplicationLayer.Interfaces.FleetApplications;
using MediatR;

namespace ApplicationLayer.Features.FleetApplications.Handler;

public class ReturnHandler(IFleetApplicationServices services) : IRequestHandler<ReturnCommand, HandlerResult>
{
    public async Task<HandlerResult> Handle(ReturnCommand request, CancellationToken cancellationToken)
    {
        var result = await services.ReturnAsync();
        return result.ToHandlerResult();
    }
}