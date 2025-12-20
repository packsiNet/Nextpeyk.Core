using ApplicationLayer.Extensions;
using ApplicationLayer.Features.FleetApplications.Query;
using ApplicationLayer.Interfaces.FleetApplications;
using MediatR;

namespace ApplicationLayer.Features.FleetApplications.Handler;

public class GetParcelWithBarcodeHandler(IFleetApplicationServices services) : IRequestHandler<GetParcelWithBarcodeQuery, HandlerResult>
{
    public async Task<HandlerResult> Handle(GetParcelWithBarcodeQuery request, CancellationToken cancellationToken)
    {
        var result = await services.GetParcelWithBarcodeAsync();
        return result.ToHandlerResult();
    }
}