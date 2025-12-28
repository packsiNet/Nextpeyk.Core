using ApplicationLayer.Dto.BaseDtos;
using DomainLayer.Entities;

namespace ApplicationLayer.Interfaces;

public interface IRefreshTokenService
{
    Result<RefreshToken> AddRefreshToken(RefreshToken refreshToken);

    RefreshToken RefreshTokenGenerator(int userId, string tokenId);

    Result RemoveExpiredTokensFromDatabase();

    Task<Result> RevokeRefreshTokenByUserIdAsync(int userId);

    Task<Result> UpdateRefreshTokenAsync(RefreshToken refreshToken);

    Task<Result<RefreshToken>> VerifyTokenAsync(string accessTokens, string refreshToken);
}