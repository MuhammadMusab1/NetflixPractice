using Microsoft.AspNetCore.Mvc;

namespace NetfilxPractice.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index()
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
