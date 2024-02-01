using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace BlazorWebAssemblySakilaApp.Authorization;

public static class Policies
{
    public static AuthorizationPolicy AdultPolicy()
    {
        return new AuthorizationPolicyBuilder()
            .AddRequirements(new MinimumAgeRequriment(18))
            .Build();
    }
}

public record MinimumAgeRequriment(byte age) : IAuthorizationRequirement; // mark interface

public class AgeAuthorizationHandler : AuthorizationHandler<MinimumAgeRequriment>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAgeRequriment requirement)
    {
        var dateOfBirth = DateTime.Parse(context.User.FindFirst(c => c.Type == ClaimTypes.DateOfBirth).Value);

        var age = DateTime.Today.Year - dateOfBirth.Year;

        if (age >= requirement.age)
        {
            context.Succeed(requirement);
        }

        else
        {
            context.Fail();
        }

        return Task.CompletedTask;

    }
}