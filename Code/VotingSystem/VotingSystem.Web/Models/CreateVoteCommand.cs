using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VotingSystem.Web.Entities;

namespace VotingSystem.Web.Models
{
    public class CreateVoteCommand : EditVoteBase
    {
        /// <summary>
        /// 为了创建的时候初始化三个
        /// </summary>
        public CreateVoteCommand()
        {
            VoteItems.Add(new CreateVoteItemCommand());
            VoteItems.Add(new CreateVoteItemCommand());
            VoteItems.Add(new CreateVoteItemCommand());
        }

        public IList<CreateVoteItemCommand> VoteItems { get; set; } = new List<CreateVoteItemCommand>();

        public Vote ToVote(string createById)
        {
            return new Vote
            {
                Id = Guid.NewGuid(),
                Title = Title,
                CreateTime = CreateTime,
                Deadline = Deadline,
                IsMultiple = IsMultiple,
                VoteItems = VoteItems?.Select(x => x.ToVoteItem()).ToList(),
                CreatedById = createById
            };
        }
    }
}
