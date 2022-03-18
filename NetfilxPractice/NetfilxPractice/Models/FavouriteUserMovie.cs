namespace NetfilxPractice.Models
{
    public class FavouriteUserMovie : UserItem
    {
        public int FavouriteMovieId { get; set; }
        public Movie FavouriteMovie { get; set; }
        public FavouriteUserMovie()
        {

        }
        public FavouriteUserMovie(ApplicationUser user, Movie favouriteMovie)
        {
            FavouriteMovieId = favouriteMovie.Id;
            FavouriteMovie = favouriteMovie;
            User = user;
            UserId = user.Id;
        }
    }
}
