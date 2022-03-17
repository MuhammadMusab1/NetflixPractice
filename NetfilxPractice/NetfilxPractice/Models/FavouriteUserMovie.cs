namespace NetfilxPractice.Models
{
    public class FavouriteUserMovie
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int FavouriteMovieId { get; set; }
        public Movie FavouriteMovie { get; set; }
    }
}
