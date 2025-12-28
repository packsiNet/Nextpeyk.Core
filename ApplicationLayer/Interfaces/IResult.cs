using ApplicationLayer.Common.Enums;

namespace ApplicationLayer.Interfaces;

public interface IResult
{
    RequestStatus RequestStatus { get; }
    string Message { get; }
}
