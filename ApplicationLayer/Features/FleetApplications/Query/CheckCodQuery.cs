using MediatR;
using ApplicationLayer;

namespace ApplicationLayer.Features.FleetApplications.Query;

public record CheckCodQuery : IRequest<HandlerResult>;