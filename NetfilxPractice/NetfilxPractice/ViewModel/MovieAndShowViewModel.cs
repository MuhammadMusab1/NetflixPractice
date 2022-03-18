using NetfilxPractice.Models;

namespace NetfilxPractice.ViewModel
{
    public class MovieAndShowViewModel
    {
        public ICollection<Movie> AllMovies { get; set; }
        public ICollection<Show> AllShows { get; set;}

        public MovieAndShowViewModel(List<Movie> allMovies, List<Show> allShows)
        {
            AllMovies = allMovies;
            AllShows = allShows;
        }
    }
}
