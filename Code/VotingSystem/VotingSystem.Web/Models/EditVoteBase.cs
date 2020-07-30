using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VotingSystem.Web.Models
{
    public class EditVoteBase
    {
        public string Title { get; set; }
        public DateTimeOffset CreateTime { get; set; }
        public DateTimeOffset Deadline { get; set; }
        public bool IsMultiple { get; set; }
    }
}
