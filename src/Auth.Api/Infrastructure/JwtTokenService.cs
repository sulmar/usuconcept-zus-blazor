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
        Claim[] claims =
        [
            new Claim(ClaimTypes.Name, userIdentity.Email),
            new Claim(ClaimTypes.Email, userIdentity.Email),
        ];

        ClaimsIdentity identity = new ClaimsIdentity(claims);

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
