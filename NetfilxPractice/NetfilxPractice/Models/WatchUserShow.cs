namespace NetfilxPractice.Models
{
    public class WatchUserShow : UserItem
    {
        public int WatchingShowId { get; set; }
        public Show WatchingShow { get; set; }
    }
}
