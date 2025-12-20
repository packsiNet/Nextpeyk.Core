using ApplicationLayer.Extensions;
using ApplicationLayer.Features.FleetApplications.Query;
using ApplicationLayer.Interfaces.FleetApplications;
using MediatR;

namespace ApplicationLayer.Features.FleetApplications.Handler;

public class GetRouteParcelHandler(IFleetApplicationServices services) : IRequestHandler<GetRouteParcelQuery, HandlerResult>
{
    public async Task<HandlerResult> Handle(GetRouteParcelQuery request, CancellationToken cancellationToken)
    {
        var result = await services.GetRouteParcelAsync();
        return result.ToHandlerResult();
    }
}