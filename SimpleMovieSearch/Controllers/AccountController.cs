using Microsoft.AspNetCore.Mvc;

namespace SimpleMovieSearch.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
