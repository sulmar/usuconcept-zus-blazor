using Auth.Api.Abstractions;
using Auth.Api.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Auth.Api.Infrastructure
{
    public class DbUserIdentityRepository : IUserIdentityRepository
    {
        private readonly IPasswordHasher<UserIdentity> passwordHasher;
        private readonly AppIdentityContext context;

        public DbUserIdentityRepository(IPasswordHasher<UserIdentity> passwordHasher, AppIdentityContext context)
        {
            this.passwordHasher = passwordHasher;
            this.context = context;
        }

        public async Task<UserIdentity> GetByUsername(string username)
        {
            UserIdentity userIdentity = await context.UserIdentities.SingleOrDefaultAsync(p=>p.Email == username);

            if (userIdentity != null)
            {
                userIdentity.HashedPassword = passwordHasher.HashPassword(userIdentity, "123");
            }

            return userIdentity;
        }
    }
}
