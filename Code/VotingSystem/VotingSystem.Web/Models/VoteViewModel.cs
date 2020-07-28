using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VotingSystem.Web.Models
{
    public class VoteViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Remaining { get; set; }
    }
}
