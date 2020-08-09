using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using VotingSystem.Data;
using VotingSystem.Entities;
using VotingSystem.Helper;
using VotingSystem.Models;

namespace VotingSystem
{
    public class VoteService
    {
        private readonly ILogger<VoteService> _logger;
        private readonly ApplicationDbContext _context;

        public VoteService(ILogger<VoteService> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public Task<PagedList<VoteViewModel>> GetVotes(SearchVoteModel model)
        {
            var votes = _context.Votes as IQueryable<Vote>;

            if (!string.IsNullOrWhiteSpace(model.Title))
            {
                model.Title = model.Title.Trim();
                votes = votes.Where(x => x.Title == model.Title);
            }

            var dateTime = DateTime.UtcNow;
            var voteViewModels = votes.Select(x => new VoteViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Remaining =
                    $"{x.Deadline.Day - dateTime.Day}days {x.Deadline.Hour - dateTime.Hour}hrs {x.Deadline.Minute - dateTime.Minute}mins"
            });

            return PagedList<VoteViewModel>.CreateAsync(voteViewModels, model.PageNumber, model.PageSize);
        }

        public Guid CreateVote(CreateVoteCommand command, string userId)
        {
            var vote = command.ToVote(userId);
            _context.Add(vote);
            _context.SaveChanges();

            return vote.Id;
        }

        public Vote GetVote(Guid id)
        {
            return _context.Votes
                .SingleOrDefault(x => x.Id == id);
        }

        public VoteDetailViewModel GetVoteDetail(Guid id)
        {
            return _context.Votes
                .Where(x => x.Id == id)
                .Select(x => new VoteDetailViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    //Remaining = x.Deadline,
                    VoteItems = x.VoteItems
                        .Select(item => new VoteDetailViewModel.Item
                        {
                            ItemName = item.ItemName
                        })
                })
                .SingleOrDefault();
        }

        public UpdateVoteCommand GetVoteForUpdate(Guid id)
        {
            return _context.Votes
                .Where(x => x.Id == id)
                .Select(x => new UpdateVoteCommand
                {
                    Title = x.Title,
                    Deadline = x.Deadline,
                    IsMultiple = x.IsMultiple
                })
                .SingleOrDefault();
        }

        public void UpdateVote(UpdateVoteCommand command)
        {
            var vote = _context.Votes.Find(command.Id);
            if (vote == null) throw new Exception("Unable to find the vote");

            command.UpdateVote(vote);
            _context.SaveChanges();
        }

        public void DeleteVote(Guid id)
        {
            var vote = _context.Votes.Find(id);

            _context.Votes.Remove(vote);
            _context.SaveChanges();
        }
    } 
}
