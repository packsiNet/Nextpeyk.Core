using ApplicationLayer.Extensions;
using ApplicationLayer.Features.FleetApplications.Query;
using ApplicationLayer.Interfaces.FleetApplications;
using MediatR;

namespace ApplicationLayer.Features.FleetApplications.Handler;

public class CheckCodHandler(IFleetApplicationServices services) : IRequestHandler<CheckCodQuery, HandlerResult>
{
    public async Task<HandlerResult> Handle(CheckCodQuery request, CancellationToken cancellationToken)
    {
        var result = await services.CheckCodAmountAsync();
        return result.ToHandlerResult();
    }
}