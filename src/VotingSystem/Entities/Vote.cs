using System;
using System.Collections.Generic;

namespace VotingSystem.Entities
{
    public class Vote
    {
        public Guid Id { get; set; }
        public string CreatedById { get; set; }
        public string Title { get; set; }
        public DateTimeOffset CreateTime { get; set; }
        public DateTimeOffset Deadline { get; set; }
        public bool IsMultiple { get; set; }
        public bool IsDelete { get; set; }

        public ICollection<VoteItem> VoteItems { get; set; }
    }
}
