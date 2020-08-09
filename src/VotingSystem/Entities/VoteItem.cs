using System;

namespace VotingSystem.Entities
{
    public class VoteItem
    {
        public Guid Id { get; set; }
        public Guid VoteId { get; set; }
        public string ItemName { get; set; }
    }
}
