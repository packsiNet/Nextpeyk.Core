using ApplicationLayer.Extensions;
using ApplicationLayer.Features.FleetApplications.Query;
using ApplicationLayer.Interfaces.FleetApplications;
using MediatR;

namespace ApplicationLayer.Features.FleetApplications.Handler;

public class GetArchiveParcelsHandler(IFleetApplicationServices services) : IRequestHandler<GetArchiveParcelsQuery, HandlerResult>
{
    public async Task<HandlerResult> Handle(GetArchiveParcelsQuery request, CancellationToken cancellationToken)
    {
        var result = await services.GetArchiveParcelsAsync();
        return result.ToHandlerResult();
    }
}