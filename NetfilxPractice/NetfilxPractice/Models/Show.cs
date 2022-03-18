namespace NetfilxPractice.Models
{
    public class Show
    {
        public int Id { get; set; } 
        public string ShowName { get; set; }
        public string ShowType { get; set; }
        public ICollection<Episode> Episodes { get; set;}
        public ICollection<FavouriteUserShow> FavouriteShows { get; set; }
        public ICollection<WatchUserShow> WatchingShows { get; set; }
        public int TotalEpisodes { get; set;}
        public Show() //never used constructor(only did this to avoid this warings)
        {
            ShowName = "";
            ShowType = "";
            TotalEpisodes = 0;
            Episodes = new HashSet<Episode>();
            FavouriteShows = new HashSet<FavouriteUserShow>();
            WatchingShows = new HashSet<WatchUserShow>();
        }
        public Show(string showName, string showType, int totalEpisode)
        {
            ShowName = showName;
            ShowType = showType;
            Episodes = new HashSet<Episode>();
            FavouriteShows = new HashSet<FavouriteUserShow>();
            WatchingShows = new HashSet<WatchUserShow>();
            TotalEpisodes = totalEpisode;
        }
    }
}
