using ApplicationLayer.Extensions;
using ApplicationLayer.Features.FleetApplications.Query;
using ApplicationLayer.Interfaces.FleetApplications;
using MediatR;

namespace ApplicationLayer.Features.FleetApplications.Handler;

public class GetFleetInfoHandler(IFleetApplicationServices services) : IRequestHandler<GetFleetInfoQuery, HandlerResult>
{
    public async Task<HandlerResult> Handle(GetFleetInfoQuery request, CancellationToken cancellationToken)
    {
        var result = await services.GetInfoAsync();
        return result.ToHandlerResult();
    }
}