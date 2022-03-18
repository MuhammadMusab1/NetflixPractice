namespace NetfilxPractice.Models
{
    public class WatchUserMovie : UserItem
    {
        public int WatchingMovieId { get; set; }
        public Movie WatchingMovie { get; set; }
        public WatchUserMovie()
        {

        }
        public WatchUserMovie(ApplicationUser user, Movie watchingMovie)
        {
            WatchingMovie = watchingMovie;
            WatchingMovieId = watchingMovie.Id;
            User = user;
            UserId = user.Id;
        }
    }
}
