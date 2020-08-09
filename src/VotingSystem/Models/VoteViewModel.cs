using System;

namespace VotingSystem.Models
{
    public class VoteViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Remaining { get; set; }
    }
}
