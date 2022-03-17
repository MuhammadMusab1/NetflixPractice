namespace NetfilxPractice.Models
{
    public class WatchUserShow
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int WatchingShowId { get; set; }
        public Show WatchingShow { get; set; }
    }
}
