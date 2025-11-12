using ApplicationLayer.Dto.Fleets;
using MediatR;

namespace ApplicationLayer.Features.Fleets;

public record AddFleetCommand(AddFleetInputDto Model) : IRequest<HandlerResult>;