namespace NetfilxPractice.Models
{
    public class FavouriteUserMovie : UserItem
    {
        public int FavouriteMovieId { get; set; }
        public Movie FavouriteMovie { get; set; }
    }
}
