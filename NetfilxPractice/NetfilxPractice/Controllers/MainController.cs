using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetfilxPractice.Data;
using NetfilxPractice.Models;
using NetfilxPractice.ViewModel;

namespace NetfilxPractice.Controllers
{
    [Authorize]
    public class MainController : Controller
    {
        private ApplicationDbContext _db { get; set; }
        private UserManager<ApplicationUser> _userManager { get; set; }
        public MainController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            List<Movie> allMovies = _db.Movie.ToList();
            List<Show> allShows = _db.Show.Include(show => show.Episodes).ToList();
            MovieAndShowViewModel movieAndShow = new MovieAndShowViewModel(allMovies, allShows);
            return View(movieAndShow);
        }
        public IActionResult AddMovieToUserWatchList()
        {
            return View();
        }
    }
}

/*
Create a view that lets us see a list of movies, 
and 
episodes collected under their shows. 
They should all have buttons for adding them to a watchlist, or the favourites list. 
 */
