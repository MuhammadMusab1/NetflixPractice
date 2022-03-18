namespace NetfilxPractice.Models
{
    public class WatchUserMovie : UserItem
    {
        public int WatchingMovieId { get; set; }
        public Movie WatchingMovie { get; set; }
    }
}
