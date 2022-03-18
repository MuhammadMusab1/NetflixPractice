namespace NetfilxPractice.Models
{
    public class FavouriteUserShow : UserItem
    {
        public int FavouriteShowId { get; set; }
        public Show FavouriteShow { get; set; }
    }
}
