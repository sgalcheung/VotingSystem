using Microsoft.AspNetCore.Authorization;

namespace VotingSystem.Authorization
{
    public class IsVoteOwnerRequirement : IAuthorizationRequirement
    {
    }
}
