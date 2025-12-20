using ApplicationLayer.Dto.BaseDtos;
using ApplicationLayer.Dto.FleetApplications;

namespace ApplicationLayer.Interfaces.FleetApplications;

public interface IFleetApplicationServices
{
    Task<Result<FleetInfoDto>> GetInfoAsync();
    Task<Result> GetParcelsAsync();
    Task<Result> GetArchiveParcelsAsync();
    Task<Result> GetParcelDetailsAsync();
    Task<Result> GetParcelWithBarcodeAsync();
    Task<Result> GetIdentityTypeAsync();
    Task<Result> TakeReceivedAsync();
    Task<Result> TakeDeliveredAsync();
    Task<Result> ChangeDeliveryStatusAsync();
    Task<Result> ReturnAsync();
    Task<Result> DeclineReceivedAsync();
    Task<Result> CheckCodAmountAsync();
    Task<Result> LocationFleetAsync();
    Task<Result> GetRouteParcelAsync();
    Task<Result> GetFleetActivityPerDayAsync();
    Task<Result> CustomSendStatusAsync();
}