using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VotingSystem.Web.Models
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
            public bool IsMultiple { get; set; }
        }
    }
}
