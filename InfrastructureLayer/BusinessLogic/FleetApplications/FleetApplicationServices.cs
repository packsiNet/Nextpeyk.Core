using ApplicationLayer.Common.Extensions;
using ApplicationLayer.Dto.BaseDtos;
using ApplicationLayer.Dto.FleetApplications;
using ApplicationLayer.Interfaces;
using ApplicationLayer.Interfaces.FleetApplications;
using DomainLayer.Common.Attributes;
using DomainLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace InfrastructureLayer.BusinessLogic.FleetApplications;

[InjectAsScoped]
public class FleetApplicationServices(IUnitOfWork unitOfWork,
    IHttpContextAccessor accessor,
    ILogger<FleetApplicationServices> logger,
    IRepository<UserAccount> userAccountRepository) : IFleetApplicationServices
{
    public async Task<Result<FleetInfoDto>> GetInfoAsync()
    {
        try
        {
            var currentUserId = accessor.HttpContext.User.Identity.GetUserId();
            var response = await userAccountRepository.Query()
                        .Include(current => current.UserProfiles)
                        .Select(current => new FleetInfoDto
                        {
                            Id = current.Id,
                            UserName = current.UserName,
                            Email = current.Email,
                            Address = current.UserProfiles.FirstOrDefault().Address,
                            Company = current.UserProfiles.FirstOrDefault().Company,
                            FirstName = current.UserProfiles.FirstOrDefault().FirstName,
                            LastName = current.UserProfiles.FirstOrDefault().LastName,
                            NationalCode = current.UserProfiles.FirstOrDefault().NationalCode,
                            PhoneNumber = current.PhoneNumber
                        }).FirstOrDefaultAsync(current => current.Id == currentUserId);
            if (response == null)
                return Result<FleetInfoDto>.NotFound();

            return Result<FleetInfoDto>.Success(response);
        }
        catch (Exception exception)
        {
            logger.Log(LogLevel.Error, exception);
            return Result<FleetInfoDto>.GeneralFailure(exception.Message);
        }
    }

    public Task<Result> GetParcelsAsync()
    {

    }

    public Task<Result> GetArchiveParcelsAsync()
        => Task.FromResult(Result.Success());

    public Task<Result> GetParcelDetailsAsync()
        => Task.FromResult(Result.Success());

    public Task<Result> GetParcelWithBarcodeAsync()
        => Task.FromResult(Result.Success());

    public Task<Result> GetIdentityTypeAsync()
        => Task.FromResult(Result.Success());

    public Task<Result> TakeReceivedAsync()
        => Task.FromResult(Result.Success());

    public Task<Result> TakeDeliveredAsync()
        => Task.FromResult(Result.Success());

    public Task<Result> ChangeDeliveryStatusAsync()
        => Task.FromResult(Result.Success());

    public Task<Result> ReturnAsync()
        => Task.FromResult(Result.Success());

    public Task<Result> DeclineReceivedAsync()
        => Task.FromResult(Result.Success());

    public Task<Result> CheckCodAmountAsync()
        => Task.FromResult(Result.Success());

    public Task<Result> LocationFleetAsync()
        => Task.FromResult(Result.Success());

    public Task<Result> GetRouteParcelAsync()
        => Task.FromResult(Result.Success());

    public Task<Result> GetFleetActivityPerDayAsync()
        => Task.FromResult(Result.Success());

    public Task<Result> CustomSendStatusAsync()
        => Task.FromResult(Result.Success());
}