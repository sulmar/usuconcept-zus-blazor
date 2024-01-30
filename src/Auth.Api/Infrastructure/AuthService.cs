using Auth.Api.Abstractions;
using Auth.Api.Model;
using Microsoft.AspNetCore.Identity;

namespace Auth.Api.Infrastructure;

public class AuthService : IAuthService
{
    private readonly IUserIdentityRepository userIdentityRepository;
    private readonly IPasswordHasher<UserIdentity> passwordHasher;

    public AuthService(IUserIdentityRepository userIdentityRepository, IPasswordHasher<UserIdentity> passwordHasher)
    {
        this.userIdentityRepository = userIdentityRepository;
        this.passwordHasher = passwordHasher;
    }

    public async Task<UserIdentity> TryAthorizeAsync(string username, string password)
    {
        var userIdentity = await userIdentityRepository.GetByUsername(username);

        if (userIdentity != null && passwordHasher.VerifyHashedPassword(userIdentity, userIdentity.HashedPassword, password) == PasswordVerificationResult.Success)
        {
            return userIdentity;
        }

        return null;

    }
}


