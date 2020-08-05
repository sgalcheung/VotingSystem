using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VotingSystem.Web.Entities;

namespace VotingSystem.Web.Models
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
