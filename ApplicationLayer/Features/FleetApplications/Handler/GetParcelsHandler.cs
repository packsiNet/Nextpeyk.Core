using ApplicationLayer.Extensions;
using ApplicationLayer.Features.FleetApplications.Query;
using ApplicationLayer.Interfaces.FleetApplications;
using MediatR;

namespace ApplicationLayer.Features.FleetApplications.Handler;

public class GetParcelsHandler(IFleetApplicationServices services) : IRequestHandler<GetParcelsQuery, HandlerResult>
{
    public async Task<HandlerResult> Handle(GetParcelsQuery request, CancellationToken cancellationToken)
    {
        var result = await services.GetParcelsAsync();
        return result.ToHandlerResult();
    }
}