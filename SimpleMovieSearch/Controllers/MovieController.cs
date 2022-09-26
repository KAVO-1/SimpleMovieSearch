using Microsoft.AspNetCore.Mvc;
using SimpleMovieSearch.DAL.Interfaces;
using SimpleMovieSearch.Service.Interfaces;
using SimpleMovieSearch.Domain.Enum;
using Microsoft.AspNetCore.Authorization;
using SimpleMovieSearch.Domain.ViewModels.Movie;
using System.Linq;

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
        public async Task<IActionResult> MovieIndex() //список всех фильмов
        {
            var resp = await _movieService.GetMovieList();
            return View(resp.Data.ToList());
        }

        [HttpGet]
        public async Task<IActionResult> GetMovie(int id) //получить один фильм по Id
        {
            var response = await _movieService.GetMovie(id);
            if (response.StatusName == StatusName.OK)
            {
                return View(response.Data);
            }
            return View(response.Data);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id) //удaлить фильм (админ)
        {
            
            var resp = await _movieService.DeleteMovie(id);

            if (resp.StatusName == StatusName.OK)
            {
                return View(resp.Data);
            }
            return RedirectToAction("Error");

        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Save(int id) //сохранить фильм (админ)
        {
            if (id==0)
            {
                return View();
            }

            var resp = await _movieService.GetMovie( id);
            if (resp.StatusName == StatusName.OK)
            {
                return View(resp.Data);
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



        [HttpGet]
        public async Task<IActionResult> MovieSearch( string search) // Поиск
        {

            var response = await _movieService.GetMovieName(search);
            if (response.StatusName == StatusName.OK)
            {
                return View(response.Data);
            }
            return View(response.Data);
        }

    }
}
