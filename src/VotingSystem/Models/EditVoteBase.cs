using System;

namespace VotingSystem.Models
{
    public class EditVoteBase
    {
        public string Title { get; set; }
        public DateTimeOffset CreateTime { get; set; }
        public DateTimeOffset Deadline { get; set; }
        public bool IsMultiple { get; set; }
        public bool IsPublish { get; set; }
    }
}
