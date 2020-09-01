using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using VotingSystem.Entities;

namespace VotingSystem.Authorization
{
    public class IsVoteOwnerHandler : AuthorizationHandler<IsVoteOwnerRequirement, Vote>
    {
        private readonly UserManager<IdentityUser> _userManager;

        public IsVoteOwnerHandler(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, IsVoteOwnerRequirement requirement, Vote resource)
        {
            var appUser = await _userManager.GetUserAsync(context.User);
            if (appUser == null)
            {
                return;
            }

            if (resource.CreatedById == appUser.Id)
            {
                context.Succeed(requirement);
            }
        }
    }
}
