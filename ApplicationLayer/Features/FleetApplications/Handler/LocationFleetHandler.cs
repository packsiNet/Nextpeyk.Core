using ApplicationLayer.Extensions;
using ApplicationLayer.Features.FleetApplications.Command;
using ApplicationLayer.Interfaces.FleetApplications;
using MediatR;

namespace ApplicationLayer.Features.FleetApplications.Handler;

public class LocationFleetHandler(IFleetApplicationServices services) : IRequestHandler<LocationFleetCommand, HandlerResult>
{
    public async Task<HandlerResult> Handle(LocationFleetCommand request, CancellationToken cancellationToken)
    {
        var result = await services.LocationFleetAsync();
        return result.ToHandlerResult();
    }
}