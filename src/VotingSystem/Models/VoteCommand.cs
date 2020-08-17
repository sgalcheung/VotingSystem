using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VotingSystem.Entities;

namespace VotingSystem.Models
{
    public class VoteCommand
    {
        public Guid Id { get; set; }

        public IEnumerable<Guid> SelectedItems { get; set; }

        public void ToVote(Vote vote)
        {
            //vote.VoteItems.Where(x=>SelectedItems.Contains(x.Id))

            foreach (var voteItem in vote.VoteItems)
            {
                foreach (var selectedItemId in SelectedItems)
                {
                    if (voteItem.Id == selectedItemId)
                    {
                        voteItem.Count++;
                    }
                }
            }
        }

    }
}
