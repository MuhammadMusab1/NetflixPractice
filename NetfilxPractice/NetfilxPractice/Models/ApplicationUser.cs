using Microsoft.AspNetCore.Identity;

namespace NetfilxPractice.Models
{
    public class ApplicationUser : IdentityUser
    {
        //Add new properties to IdentityUser
        public ICollection<FavouriteMovie> FavouriteMovieList { get; set; }
        public ICollection<WatchMovie> WatchMovieList { get; set; }
        public ICollection<FavouriteShow> FavouriteShowList { get; set; }
        public ICollection<WatchShow> WatchShowList { get; set; }

        public ApplicationUser()
        {
            FavouriteMovieList = new HashSet<FavouriteMovie>();
            WatchMovieList = new HashSet<WatchMovie>();
            FavouriteShowList = new HashSet<FavouriteShow>();
            WatchShowList = new HashSet<WatchShow>();
        }
        /**one to one
        public int MovieId { get; set; }
        public Movie Movie { get; set; }**/
        /**one to many
        public ICollection<Movie> MovieList { get; set; }**/
        /**many to many
        public ICollection<UserMovie> **/
    }
}
