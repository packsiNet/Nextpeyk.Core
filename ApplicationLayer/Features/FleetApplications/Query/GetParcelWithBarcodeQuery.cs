using MediatR;
using ApplicationLayer;

namespace ApplicationLayer.Features.FleetApplications.Query;

public record GetParcelWithBarcodeQuery : IRequest<HandlerResult>;