using System;
using System.Collections.Generic;

namespace VotingSystem.Models
{
    public class VoteDetailViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Remaining { get; set; }

        public IEnumerable<Item> VoteItems { get; set; }

        public class Item
        {
            public string ItemName { get; set; }
        }
    }
}
