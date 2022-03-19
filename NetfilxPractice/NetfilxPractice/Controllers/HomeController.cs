using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NetfilxPractice.Data;
using NetfilxPractice.Models;
using System.Diagnostics;

namespace NetfilxPractice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext _db;
        private UserManager<ApplicationUser> _userManager;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AllMovies()
        {
            string userName = User.Identity.Name;
            ViewBag.User = await _userManager.FindByNameAsync(userName);
            return View();
        }
        public IActionResult AllShows()
        {
            string userName = User.Identity.Name;
            ViewBag.User = await _userManager.FindByNameAsync(userName);
            return View();
        }

        public IActionResult AddFavouriteMovie()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}