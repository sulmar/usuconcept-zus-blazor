using Auth.Api.Abstractions;
using Auth.Api.Infrastructure;
using Auth.Api.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IPasswordHasher<UserIdentity>, PasswordHasher<UserIdentity>>();
builder.Services.AddScoped<IUserIdentityRepository, DbUserIdentityRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddSingleton<ITokenService, JwtTokenService>();

builder.Services.AddDbContext<AppIdentityContext>(optionsBuilder => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=sakila;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"));

var app = builder.Build();

app.MapGet("/", () => "Hello Api!");


// POST /api/token/create 
// Content-Type: application/json
// { "login":"john.smith@domain.com", "passsword":"my_secret_password" }
//

app.MapPost("/api/token/create", async (LoginRequest request, IAuthService authService, ITokenService tokenService) =>
{
    var userIdentity = await authService.TryAthorizeAsync(request.Username, request.Password);

    if (userIdentity != null)
    {
        var token = tokenService.CreateToken(userIdentity);

        return Results.Ok(token);
    }

    return Results.BadRequest(new { message = "Username or password is incorrect." });
});

app.Run();
