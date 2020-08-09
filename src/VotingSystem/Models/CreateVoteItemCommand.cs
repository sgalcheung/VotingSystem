using System;
using VotingSystem.Entities;

namespace VotingSystem.Models
{
    public class CreateVoteItemCommand
    {
        public string ItemName { get; set; }

        public VoteItem ToVoteItem()
        {
            return new VoteItem
            {
                Id = Guid.NewGuid(),
                ItemName = ItemName
            };
        }
    }
}
