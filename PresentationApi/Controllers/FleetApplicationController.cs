using ApplicationLayer.Common.Extensions;
using ApplicationLayer.Features.FleetApplications.Command;
using ApplicationLayer.Features.FleetApplications.Query;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PresentationApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[ApiExplorerSettings(GroupName = "Mobile")]
public class FleetApplicationController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    [Route("GetInfo")]
    public async Task<IActionResult> GetFleeInfotAsync()
        => await ResultHelper.GetResultAsync(mediator, new GetFleetInfoQuery());

    [HttpGet]
    [Route("GetParcels")]
    public async Task<IActionResult> GetParcelsAsync()
        => await ResultHelper.GetResultAsync(mediator, new GetParcelsQuery());

    [HttpGet]
    [Route("GetArchiveParcels")]
    public async Task<IActionResult> GetArchiveParcelsAsync()
        => await ResultHelper.GetResultAsync(mediator, new GetArchiveParcelsQuery());

    [HttpPost]
    [Route("GetParcelDetails")]
    public async Task<IActionResult> GetParcelDetailsAsync(GetParcelDetailsQuery model)
        => await ResultHelper.GetResultAsync(mediator, model);

    [HttpPost]
    [Route("GetParcelWithBarcode")]
    public async Task<IActionResult> GetParcelWithBarcodeAsync(GetParcelWithBarcodeQuery model)
        => await ResultHelper.GetResultAsync(mediator, model);

    [HttpGet]
    [Route("GetIdentityTypes")]
    public async Task<IActionResult> GetIdentityTypeAsync()
        => await ResultHelper.GetResultAsync(mediator, new IdentityTypeDropdownQuery());

    [HttpPost]
    [Route("TakeReceived")]
    public async Task<IActionResult> TakeReceivedAsync(TakeReceivedCommand model)
        => await ResultHelper.GetResultAsync(mediator, model);

    [HttpPost]
    [Route("TakeDelivered")]
    public async Task<IActionResult> TakeDeliveredAsync(TakeDeliveredCommand model)
        => await ResultHelper.GetResultAsync(mediator, model);

    [HttpPost]
    [Route("ChangeDeliveryStatus")]
    public async Task<IActionResult> ChangeStatusAsync(ChangeDeliveryStatusCommand model)
        => await ResultHelper.GetResultAsync(mediator, model);

    [HttpPost]
    [Route("Return")]
    public async Task<IActionResult> ReturnAsync(ReturnCommand model)
        => await ResultHelper.GetResultAsync(mediator, model);

    [HttpPost]
    [Route("DeclineReceived")]
    public async Task<IActionResult> DeclineReceivedAsync(DeclineReceivedCommand model)
        => await ResultHelper.GetResultAsync(mediator, model);

    [HttpPost]
    [Route("CheckCodAmount")]
    public async Task<IActionResult> CheckCodAmount(CheckCodQuery model)
        => await ResultHelper.GetResultAsync(mediator, model);

    [HttpPost]
    [Route("LocationFleet")]
    public async Task<IActionResult> LocationFleetAsync(LocationFleetCommand model)
        => await ResultHelper.GetResultAsync(mediator, model);

    [HttpPost]
    [Route("GetRouteParcel")]
    public async Task<IActionResult> GetRouteParcel(GetRouteParcelQuery model)
        => await ResultHelper.GetResultAsync(mediator, model);

    [HttpGet]
    [Route("GetFleetActivityPerDay")]
    public async Task<IActionResult> GetActiveFleetAsync()
        => await ResultHelper.GetResultAsync(mediator, new GetFleetActivityPerDayAppQuery());

    [HttpPost]
    [Route("CustomSendStatus")]
    public async Task<IActionResult> CustomSendStatusAsync(CustomSendStatusCommand mdoel)
        => await ResultHelper.GetResultAsync(mediator, mdoel);
}