using Auth.Api.Model;

namespace Auth.Api.Abstractions;

public interface IAuthService
{
    Task<UserIdentity> TryAthorizeAsync(string username, string password);
}
