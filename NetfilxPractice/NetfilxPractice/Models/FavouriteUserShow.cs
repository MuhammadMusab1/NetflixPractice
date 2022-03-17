namespace NetfilxPractice.Models
{
    public class FavouriteUserShow
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int FavouriteShowId { get; set; }
        public Show FavouriteShow { get; set; }
    }
}
