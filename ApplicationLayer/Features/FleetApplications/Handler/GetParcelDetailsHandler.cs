using ApplicationLayer.Extensions;
using ApplicationLayer.Features.FleetApplications.Query;
using ApplicationLayer.Interfaces.FleetApplications;
using MediatR;

namespace ApplicationLayer.Features.FleetApplications.Handler;

public class GetParcelDetailsHandler(IFleetApplicationServices services) : IRequestHandler<GetParcelDetailsQuery, HandlerResult>
{
    public async Task<HandlerResult> Handle(GetParcelDetailsQuery request, CancellationToken cancellationToken)
    {
        var result = await services.GetParcelDetailsAsync();
        return result.ToHandlerResult();
    }
}