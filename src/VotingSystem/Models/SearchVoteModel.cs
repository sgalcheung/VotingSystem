namespace VotingSystem.Models
{
    public class SearchVoteModel
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 5;
        public string Title { get; set; }
    }
}
