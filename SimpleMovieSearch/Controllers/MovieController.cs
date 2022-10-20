using Microsoft.AspNetCore.Mvc;
using SimpleMovieSearch.DAL.Interfaces;
using SimpleMovieSearch.Service.Interfaces;
using SimpleMovieSearch.Domain.Enum;
using Microsoft.AspNetCore.Authorization;
using SimpleMovieSearch.Domain.ViewModels.Movie;
using System.Linq;
using System.Xml.Linq;

namespace SimpleMovieSearch.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }
         
        [HttpGet]
        public  IActionResult MovieIndex() //список всех фильмов
        {
            var resp = _movieService.GetMovieList();
            if (resp.StatusName == StatusName.OK)
            {
                return View(resp.Data);
            }
            return View("Error", $"{resp.Description}");
        }

        [HttpGet]
        public async Task<IActionResult> GetMovie(int id) //получить один фильм по Id
        {
            var resp = await _movieService.GetMovie(id);
            if (resp.StatusName == StatusName.OK)
            {
                return View(resp.Data);
            }
            return View(resp.Data);
        }

         
        public async Task<IActionResult> SearchMovie(string search) // Search Movie
        {
            var movie = await _movieService.GetMovieName(search);
            if (movie.StatusName == StatusName.OK)
            {
                ViewData["search"] = search;
                return View(movie.Data);
            }
            return View("Error");
        }



        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id) //удaлить фильм (админ)
        {

            var resp = await _movieService.DeleteMovie(id);

            if (resp.StatusName == StatusName.OK)
            {
                return RedirectToAction("MovieIndex");
            }
            return View("Error", $"{resp.Description}");

        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Save(int id) //сохранить фильм (админ)
        {
            if (id == 0)
            {
                return PartialView();
            }

            var resp = await _movieService.GetMovie(id);
            if (resp.StatusName == StatusName.OK)
            {
                return PartialView(resp.Data);
            }
            return RedirectToAction("Error");

        }

        [HttpPost]
        public async Task<IActionResult> Save(MovieViewModels movieViewModels) //сохранить 
        {
            if (ModelState.IsValid)
            {
                if (movieViewModels.Id == 0)
                {
                    await _movieService.CreateMovie(movieViewModels);
                }
                else
                {
                    await _movieService.Edit(movieViewModels.Id, movieViewModels);
                }

            }
            return RedirectToAction("GetMovie");
        }


    }
}
