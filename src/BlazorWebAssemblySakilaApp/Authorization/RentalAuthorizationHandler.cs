using Microsoft.AspNetCore.Authorization;
using Sakila.Model;
using System.Security.Claims;

namespace BlazorWebAssemblySakilaApp.Authorization;

public class OwnerRequirement : IAuthorizationRequirement { }

public class RentalAuthorizationHandler : AuthorizationHandler<OwnerRequirement, Rental>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OwnerRequirement requirement, Rental resource)
    {
        var customerId = int.Parse(context.User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value);

        if (resource.CustomerId == customerId)
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}
