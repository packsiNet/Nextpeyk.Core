using ApplicationLayer.Extensions;
using ApplicationLayer.Features.FleetApplications.Query;
using ApplicationLayer.Interfaces.FleetApplications;
using MediatR;

namespace ApplicationLayer.Features.FleetApplications.Handler;

public class GetFleetActivityPerDayAppHandler(IFleetApplicationServices services) : IRequestHandler<GetFleetActivityPerDayAppQuery, HandlerResult>
{
    public async Task<HandlerResult> Handle(GetFleetActivityPerDayAppQuery request, CancellationToken cancellationToken)
    {
        var result = await services.GetFleetActivityPerDayAsync();
        return result.ToHandlerResult();
    }
}