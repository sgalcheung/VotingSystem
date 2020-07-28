using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VotingSystem.Web.Entities;

namespace VotingSystem.Web.Models
{
    public class CreateVoteItemCommand
    {
        public string ItemName { get; set; }

        public bool IsMultiple { get; set; }

        public VoteItem ToVoteItem()
        {
            return new VoteItem
            {
                ItemName = ItemName,
                IsMultiple = IsMultiple
            };
        }
    }
}
