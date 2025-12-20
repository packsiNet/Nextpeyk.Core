using ApplicationLayer.Extensions;
using ApplicationLayer.Features.FleetApplications.Query;
using ApplicationLayer.Interfaces.FleetApplications;
using MediatR;

namespace ApplicationLayer.Features.FleetApplications.Handler;

public class IdentityTypeDropdownHandler(IFleetApplicationServices services) : IRequestHandler<IdentityTypeDropdownQuery, HandlerResult>
{
    public async Task<HandlerResult> Handle(IdentityTypeDropdownQuery request, CancellationToken cancellationToken)
    {
        var result = await services.GetIdentityTypeAsync();
        return result.ToHandlerResult();
    }
}