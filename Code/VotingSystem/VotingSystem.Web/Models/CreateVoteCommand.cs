using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VotingSystem.Web.Entities;

namespace VotingSystem.Web.Models
{
    public class CreateVoteCommand : EditVoteBase
    {
        public IList<CreateVoteItemCommand> VoteItems { get; set; } = new List<CreateVoteItemCommand>();

        public Vote ToVote(string createById)
        {
            return new Vote
            {
                Title = Title,
                Deadline = Deadline,
                VoteItems = VoteItems?.Select(x => x.ToVoteItem()).ToList(),
                CreatedById = createById
            };
        }
    }
}
