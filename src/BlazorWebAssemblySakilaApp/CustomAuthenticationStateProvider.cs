using Blazored.LocalStorage;
using BlazorWebAssemblySakilaApp.Model;
using BlazorWebAssemblySakilaApp.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlazorWebAssemblySakilaApp;

// dotnet add package Blazored.LocalStorage

public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly ILocalStorageService storage;
    private readonly NavigationManager navigationManager;
    private readonly ApiAuthService Api;

    public CustomAuthenticationStateProvider(ILocalStorageService storage, NavigationManager navigationManager, ApiAuthService Api)
    {
        this.storage = storage;
        this.navigationManager = navigationManager;
        this.Api = Api;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var state = new AuthenticationState(new System.Security.Claims.ClaimsPrincipal());

        string token = await storage.GetItemAsStringAsync("token");

        if (!string.IsNullOrEmpty(token))
        {
            // dotnet add package System.IdentityModel.Tokens.Jwt
            var tokenHandler = new JwtSecurityTokenHandler();

            if (tokenHandler.CanReadToken(token))
            {
                var jwtSecurityToken = tokenHandler.ReadJwtToken(token);

                string secretKey = "your-256-bit-secret-your-256-bit-secret-your-256-bit-secret";

                var key = Encoding.ASCII.GetBytes(secretKey);

                try
                {
                    tokenHandler.ValidateToken(token, new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidIssuer = "http://zus.pl",
                        ValidateAudience = false,
                        ValidAudience = "http://sakila.com",
                        ClockSkew = TimeSpan.Zero,
                        ValidateLifetime = true,

                    }, out var validatedToken);

                    ClaimsIdentity identity = new ClaimsIdentity(jwtSecurityToken.Claims, "JWT Token");

                    state = new AuthenticationState(new ClaimsPrincipal(identity));

                }
                catch (Exception ex)
                {
                    await storage.RemoveItemAsync("token");
                }
            }
        }
        else
        {
            navigationManager.NavigateTo("/login");
        }

        return state;
    }

    public async Task LoginAsync(LoginModel model)
    {
        var token = await Api.CreateToken(model);

        await storage.SetItemAsStringAsync("token", token);

        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    public async Task LogoutAsync()
    {
        await storage.RemoveItemAsync("token");

        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
}
