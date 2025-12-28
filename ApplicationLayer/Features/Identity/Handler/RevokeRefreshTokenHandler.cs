using ApplicationLayer.Dto.BaseDtos;
using ApplicationLayer.Interfaces;
using ApplicationLayer.Features.Identity.Commands;
using MediatR;

namespace ApplicationLayer.Features.Identity.Handler;

public class RevokeRefreshTokenHandler : IRequestHandler<RevokeRefreshTokenCommand, Result>
{
    private readonly IRefreshTokenService _refreshTokenService;

    public RevokeRefreshTokenHandler(IRefreshTokenService refreshTokenService)
    {
        _refreshTokenService = refreshTokenService;
    }

    public async Task<Result> Handle(RevokeRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        return await _refreshTokenService.RevokeRefreshTokenByUserIdAsync(request.UserId);
    }
}
