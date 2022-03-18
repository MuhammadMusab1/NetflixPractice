namespace NetfilxPractice.Models
{
    public class Show
    {
        public int Id { get; set; } 
        public string ShowName { get; set; }
        public ShowType ShowType { get; set; }
        public ICollection<Episode> Episodes { get; set;}
        public ICollection<FavouriteUserShow> FavouriteShows { get; set; }
        public ICollection<WatchUserShow> WatchingShows { get; set; }
        public int TotalEpisodes { get; set;}
        public Show() //never used constructor(only did this to avoid this warings)
        {
            ShowName = "";
            ShowType = ShowType.Nothing;
            TotalEpisodes = 0;
            Episodes = new HashSet<Episode>();
            FavouriteShows = new HashSet<FavouriteUserShow>();
            WatchingShows = new HashSet<WatchUserShow>();
        }
        public Show(string showName, ShowType showType, int totalEpisode)
        {
            ShowName = showName;
            ShowType = showType;
            TotalEpisodes = totalEpisode;
            Episodes = new HashSet<Episode>();
            FavouriteShows = new HashSet<FavouriteUserShow>();
            WatchingShows = new HashSet<WatchUserShow>();

        }
    }
    public enum ShowType
    {
        Horror,
        Comedy,
        Thriller,
        Nothing
    }
}
