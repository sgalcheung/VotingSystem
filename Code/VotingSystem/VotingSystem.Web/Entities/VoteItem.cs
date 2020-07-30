using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VotingSystem.Web.Entities
{
    public class VoteItem
    {
        public Guid Id { get; set; }
        public Guid VoteId { get; set; }
        public string ItemName { get; set; }
    }
}
