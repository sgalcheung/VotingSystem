using System;
using VotingSystem.Entities;

namespace VotingSystem.Models
{
    public class UpdateVoteCommand : EditVoteBase
    {
        public Guid Id { get; set; }

        public void UpdateVote(Vote vote)
        {
            vote.Title = Title;
            vote.Deadline = Deadline;
            //vote.IsMultiple = IsMultiple;
        }
    }
}
