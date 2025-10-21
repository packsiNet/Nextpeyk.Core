using ApplicationLayer.Common.Enums;
using ApplicationLayer.Features.Samples.Query;
using MediatR;

namespace ApplicationLayer.Features.Samples.Handler;

public class SampleHandler() : IRequestHandler<SampleGetQuery, HandlerResult>
{
    public async Task<HandlerResult> Handle(SampleGetQuery request, CancellationToken cancellationToken)
    {
        return new HandlerResult() { RequestStatus = RequestStatus.Successful, ObjectResult = new[] { 1, 2, 3 }, Message = "Sample handler executed successfully.", };
    }
}