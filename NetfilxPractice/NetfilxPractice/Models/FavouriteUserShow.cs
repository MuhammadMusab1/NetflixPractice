namespace NetfilxPractice.Models
{
    public class FavouriteUserShow : UserItem
    {
        public int FavouriteShowId { get; set; }
        public Show FavouriteShow { get; set; }
        public FavouriteUserShow()
        {

        }
        public FavouriteUserShow(ApplicationUser user, Show favouriteShow)
        {
            User = user;
            FavouriteShow = favouriteShow;
            UserId = user.Id;
            FavouriteShowId = favouriteShow.Id;
        }
    }
}
