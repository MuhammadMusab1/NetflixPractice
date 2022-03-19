namespace NetfilxPractice.Models
{
    public class Show
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<Episode> Episodes { get; set; }
        public ICollection<FavouriteShow> FavouriteUsers { get; set; }
        public ICollection<WatchShow> WatchUsers { get; set; }

        public Show()
        {
            Episodes = new HashSet<Episode>();
            FavouriteUsers = new HashSet<FavouriteShow>();
            WatchUsers = new HashSet<WatchShow>();
        }
    }
}
