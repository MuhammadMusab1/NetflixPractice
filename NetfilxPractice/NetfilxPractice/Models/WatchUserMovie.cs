namespace NetfilxPractice.Models
{
    public class WatchUserMovie
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int WatchingMovieId { get; set; }
        public Movie WatchingMovie { get; set; }
    }
}
