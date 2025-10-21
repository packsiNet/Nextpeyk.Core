using MediatR;

namespace ApplicationLayer.Features.Samples.Query;

public record SampleGetQuery : IRequest<HandlerResult>;