namespace NetfilxPractice.Models
{
    public class Show
    {
        public int Id { get; set; } 
        public string ShowName { get; set; }
        public int ShowType { get; set; }
        public ICollection<Episode> Episodes { get; set;}
        public ICollection<FavouriteUserShow> FavouriteShows { get; set; }
        public ICollection<WatchUserShow> WatchingShows { get; set; }
        public int TotalEpisodes { get; set;}
        public Show()
        {
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
    }
}
