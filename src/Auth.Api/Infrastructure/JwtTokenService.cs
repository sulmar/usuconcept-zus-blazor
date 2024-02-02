using Auth.Api.Abstractions;
using Auth.Api.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace Auth.Api.Infrastructure;


// dotnet add package System.IdentityModel.Tokens.Jwt

public class JwtTokenService : ITokenService
{
    public string CreateToken(UserIdentity userIdentity)
    {
        JwtSecurityTokenHandler.DefaultOutboundClaimTypeMap.Clear();

        Claim[] claims =
        [
            new Claim(ClaimTypes.Name, userIdentity.Email),
            new Claim(ClaimTypes.Email, userIdentity.Email),
            new Claim(ClaimTypes.NameIdentifier, userIdentity.Id.ToString()),

            new Claim(JwtRegisteredClaimNames.Sub, userIdentity.Email),
            new Claim(JwtRegisteredClaimNames.Name, userIdentity.Email),
            new Claim(JwtRegisteredClaimNames.NameId, userIdentity.Email),
            new Claim(JwtRegisteredClaimNames.UniqueName, userIdentity.Email),            
        ];

        ClaimsIdentity identity = new ClaimsIdentity(claims);
        identity.AddClaim( new Claim(ClaimTypes.Role, $"store-{userIdentity.StoreId}"));

        if (userIdentity.FirstName.EndsWith("A"))
        {
            identity.AddClaim(new Claim("rating", "PG"));
            identity.AddClaim(new Claim("rating", "G"));
            identity.AddClaim(new Claim("rating", "PG-13"));
        }
        else
        {
            identity.AddClaim(new Claim("rating", "R"));
            identity.AddClaim(new Claim("rating", "NC17"));
        }

        // TODO: pobierz datę urodzenia z klienta
        identity.AddClaim(new Claim(ClaimTypes.DateOfBirth, DateTime.Parse("2010-01-01").ToShortDateString()));

        var tokenHandler = new JwtSecurityTokenHandler();

        string secretKey = "your-256-bit-secret-your-256-bit-secret-your-256-bit-secret";

        var key = Encoding.ASCII.GetBytes(secretKey);

        var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = identity,
            Expires = DateTime.UtcNow.AddMinutes(15),
            SigningCredentials = signingCredentials,
        };

        var securityToken = tokenHandler.CreateToken(tokenDescriptor);

        var token = tokenHandler.WriteToken(securityToken);

        return token;
    }
}
