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
        public async Task<IActionResult> AddMovieToUserWatchList(int? movieId)
        {
            if(movieId != null)
            {
                try
                {
                    Movie watchingMovie = _db.Movie.Include(movie => movie.WatchingMovies).First(movie => movie.Id == movieId);
                    ApplicationUser user = await _userManager.FindByNameAsync(User.Identity.Name);
                    WatchUserMovie? checkIfUserHasAddedToWatchListAlready = _db.WatchUserMovie.FirstOrDefault(wum => wum.UserId == user.Id && wum.WatchingMovieId == watchingMovie.Id);
                    if(checkIfUserHasAddedToWatchListAlready == null)
                    {
                        WatchUserMovie watchUserMovie = new WatchUserMovie(user, watchingMovie);

                        user.WatchingMovies.Add(watchUserMovie);
                        watchingMovie.WatchingMovies.Add(watchUserMovie);
                        _db.WatchUserMovie.Add(watchUserMovie);

                        await _userManager.UpdateAsync(user);
                        ViewBag.message = "Movie Added to WatchList";
                        return View("MessageView");
                    }
                    else
                    {
                        ViewBag.message = "Already added this Movie To WatchList";
                        return View("MessageView");
                    }
                }
                catch(Exception ex)
                {
                    return NotFound(ex.Message);
                }
            }
            else
            {
                return NotFound("No movie found");
            }
        }
        public async Task<IActionResult> AddMovieToUserFavouriteList(int? movieId)
        {
            if (movieId != null)
            {
                try
                {
                    Movie favouriteMovie = _db.Movie.Include(movie => movie.WatchingMovies).First(movie => movie.Id == movieId);
                    ApplicationUser user = await _userManager.FindByNameAsync(User.Identity.Name);
                    FavouriteUserMovie? checkIfUserHasFavouritedIt = _db.FavouriteUserMovie.FirstOrDefault(fum => fum.UserId ==user.Id && fum.FavouriteMovieId==favouriteMovie.Id);
                    if(checkIfUserHasFavouritedIt == null)
                    {
                        FavouriteUserMovie favouriteUserMovie = new FavouriteUserMovie(user, favouriteMovie);

                        user.FavouriteMovies.Add(favouriteUserMovie);
                        favouriteMovie.FavouriteMovies.Add(favouriteUserMovie);
                        _db.FavouriteUserMovie.Add(favouriteUserMovie);

                        await _userManager.UpdateAsync(user);
                        ViewBag.message = "Movie Added To Favourites";
                        return View("MessageView");
                    }
                    else
                    {
                        ViewBag.message = "Already added this Movie To Favourite";
                        return View("MessageView");
                    }
                }
                catch (Exception ex)
                {
                    return NotFound(ex.Message);
                }
            }
            else
            {
                return NotFound("No movie found");
            }
        }
        public async Task<IActionResult> AddShowToUserWatchList(int? showId)
        {
            if(showId != null)
            {
                try
                {
                    ApplicationUser user = await _userManager.FindByNameAsync(User.Identity.Name);
                    Show showAddingToWaitList = _db.Show.Include(show => show.WatchingShows).First(show => show.Id == showId);
                    WatchUserShow? checkIfUserHasAddedAlreadyToWatchList = _db.WatchUserShow.FirstOrDefault(wus => wus.UserId == user.Id && wus.WatchingShowId == showAddingToWaitList.Id);

                    if(checkIfUserHasAddedAlreadyToWatchList == null)
                    {
                        WatchUserShow newWatchUserShow = new WatchUserShow(user, showAddingToWaitList);
                        showAddingToWaitList.WatchingShows.Add(newWatchUserShow);
                        user.WatchingShows.Add(newWatchUserShow);
                        _db.WatchUserShow.Add(newWatchUserShow);

                        await _userManager.UpdateAsync(user);
                        ViewBag.message = "Show Added to Watch List";
                        return View("MessageView");
                    }
                    else
                    {
                        ViewBag.message = "Already added to Watch List";
                        return View("MessageView");
                    }

                }
                catch(Exception ex)
                {
                    return NotFound(ex.Message);
                }
            }
            else
            {
                return BadRequest();
            }
        }
        public async Task<IActionResult> AddShowToUserFavouriteList(int? showId)
        {
            if (showId != null)
            {
                try
                {
                    ApplicationUser user = await _userManager.FindByNameAsync(User.Identity.Name);
                    Show showAddingToFavouriteList = _db.Show.Include(show => show.FavouriteShows).First(show => show.Id == showId);
                    FavouriteUserShow? checkIfUserHasAddedAlreadyToWatchList = _db.FavouriteUserShow.FirstOrDefault(wus => wus.UserId == user.Id && wus.FavouriteShowId == showAddingToFavouriteList.Id);

                    if (checkIfUserHasAddedAlreadyToWatchList == null)
                    {
                        FavouriteUserShow newFavouriteUserShow = new FavouriteUserShow(user, showAddingToFavouriteList);
                        showAddingToFavouriteList.FavouriteShows.Add(newFavouriteUserShow);
                        user.FavouriteShows.Add(newFavouriteUserShow);
                        _db.FavouriteUserShow.Add(newFavouriteUserShow);

                        await _userManager.UpdateAsync(user);
                        ViewBag.message = "Show Added to Favourite List";
                        return View("MessageView");
                    }
                    else
                    {
                        ViewBag.message = "Already added to Favourite List";
                        return View("MessageView");
                    }

                }
                catch (Exception ex)
                {
                    return NotFound(ex.Message);
                }
            }
            else
            {
                return BadRequest();
            }
        }
        public async Task<IActionResult> UserInfo()
        {
            ApplicationUser user = _db.Users
                .Include(u => u.FavouriteMovies).ThenInclude(fm => fm.FavouriteMovie)
                .Include(u => u.WatchingMovies).ThenInclude(wm => wm.WatchingMovie)
                .Include(u => u.WatchingShows).ThenInclude(ws => ws.WatchingShow)
                .Include(u => u.FavouriteShows).ThenInclude(fs => fs.FavouriteShow)
                .First(user => user.UserName == User.Identity.Name);
            return View(user);
        } 
    }
}

/*
Create a view that lets us see a list of movies, 
and 
episodes collected under their shows. 
They should all have buttons for adding them to a watchlist, or the favourites list. 
 */
