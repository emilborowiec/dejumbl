using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using PonderingProgrammer.Dejumbl.Web.Model;

namespace PonderingProgrammer.Dejumbl.Web
{
    public class ContextOwnerRequirementHandler : AuthorizationHandler<ContextOwnerRequirement, Context>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ContextOwnerRequirement requirement, Context resource)
        {
            if (context.User.Identity?.Name == resource.OwnerUserName)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}