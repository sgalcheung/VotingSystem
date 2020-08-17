using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VotingSystem.Models
{
    public class VotePublicViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int VoteCount { get; set; }
        public string Remaining { get; set; }
        public bool IsMultiple { get; set; }

        public IEnumerable<Item> VoteItems { get; set; }

        public class Item
        {
            public Guid Id { get; set; }
            public Guid VoteId { get; set; }
            public string ItemName { get; set; }
            public long Count { get; set; }
            public string Percentage { get; set; }
        }
    }
}
