using Microsoft.AspNetCore.Mvc;

namespace SimpleMovieSearch.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
