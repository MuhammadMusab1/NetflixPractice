namespace NetfilxPractice.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Length { get; set; }
        public ICollection<FavouriteMovie> FavouriteUsers { get; set; }
        public ICollection<WatchMovie> WatchUsers { get; set; }

        public Movie()
        {
            FavouriteUsers = new HashSet<FavouriteMovie>();
            WatchUsers = new HashSet<WatchMovie>();
        }
        /**one to one
        public string ApplicationUserId { get; set; }
        public ApplicationUser User { get; set; }**/
        /**one to many
        public string ApplicationUserId { get; set; }
        public ApplicationUser User { get; set; }**/
    }
}
