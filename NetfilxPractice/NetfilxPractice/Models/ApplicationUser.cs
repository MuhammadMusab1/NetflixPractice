using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetfilxPractice.Models
{
    public class ApplicationUser : IdentityUser
    {
        //Add new properties to IdentityUser
        public ICollection<FavouriteUserShow> FavouriteShows { get; set; }
        public ICollection<WatchUserShow> WatchingShows { get; set; }
        public ICollection<FavouriteUserMovie> FavouriteMovies { get; set; }
        public ICollection<WatchUserMovie> WatchingMovies { get; set; }

        public ApplicationUser()
        {
            FavouriteShows = new HashSet<FavouriteUserShow>();
            WatchingShows = new HashSet<WatchUserShow>();
            FavouriteMovies = new HashSet<FavouriteUserMovie>();
            WatchingMovies = new HashSet<WatchUserMovie>();
        }
    }
}
