namespace NetfilxPractice.Models
{
    public class WatchUserShow : UserItem
    {
        public int WatchingShowId { get; set; }
        public Show WatchingShow { get; set; }
        public WatchUserShow()
        {

        }
        public WatchUserShow(ApplicationUser user, Show watchingShow) 
        {
            WatchingShow = watchingShow;
            WatchingShowId = watchingShow.Id;
            UserId = user.Id;
            User = user;
        }
    }
}
