using System;
using System.Collections.Generic;
using System.Linq;
using VotingSystem.Entities;

namespace VotingSystem.Models
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

            CreateTime = DateTimeOffset.Now; // 初始化为当前电脑时间
            Deadline = DateTimeOffset.Now.AddDays(5);
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
