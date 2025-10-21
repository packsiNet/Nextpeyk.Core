﻿namespace ApplicationLayer.DTOs.Identity;

public class AuthorizeResultDto
{
    public string UserFullName { get; set; }

    public string SamAccountName { get; set; }

    public string AccessTokens { get; set; }

    public string TokenId { get; set; }

    public string RefreshToken { get; set; }
}