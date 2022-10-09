using Microsoft.EntityFrameworkCore;
using SimpleMovieSearch.DAL.Interfaces;
using SimpleMovieSearch.Domain.Entity;
using SimpleMovieSearch.Domain.Enum;
using SimpleMovieSearch.Domain.Extensions;
using SimpleMovieSearch.Domain.Response;
using SimpleMovieSearch.Domain.ViewModels.Movie;
using SimpleMovieSearch.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMovieSearch.Service.Execution
{
    public class MovieService : IMovieService
    { 
        private readonly IBaseRepositoriy<Movie> _movieRepository;

        public MovieService(IBaseRepositoriy<Movie> movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<IBaseResponse<Movie>> CreateMovie(MovieViewModels movieViewModels)
        {
            try
            {
                var movie = new Movie()
                {
                    Name = movieViewModels.Name,
                    Description = movieViewModels.Description,
                    Country = movieViewModels.Country,
                    //MoviesCategory = (MoviesCategory)Convert.ToInt32(movieViewModels.MoviesCategory),
                };
                await _movieRepository.Create(movie);

                return new BaseResponse<Movie>()
                {
                    StatusName = StatusName.OK,
                    Data = movie
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Movie>()
                {
                    Description = $"[CreateMovie] : {ex.Message}",
                    StatusName = StatusName.InternalServerError
                };
            }

        }

        public async Task<IBaseResponse<bool>> DeleteMovie(int id)
        {
            try
            {
                var movie = await _movieRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (movie == null)
                {
                    return new BaseResponse<bool>()
                    {
                        Description = "Movie not found",
                        StatusName = StatusName.UserNotFound,
                        Data = false
                    };
                }

                return new BaseResponse<bool>()
                {
                    Data = true,
                    StatusName = StatusName.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[DeleteMovie] : {ex.Message}",
                    StatusName = StatusName.InternalServerError
                };
            }

        }

        public async Task<IBaseResponse<MovieViewModels>> GetMovie(int id)
        {
            try
            {
                var movie = await _movieRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (movie == null)
                {
                    return new BaseResponse<MovieViewModels>()
                    {
                        Description = "Film не найден",
                        StatusName = StatusName.UserNotFound
                    };
                }

                var data = new MovieViewModels()
                {
                    Description = movie.Description,
                    Name = movie.Name,
                    Country = movie.Country,
                    //MoviesCategory = movie.MoviesCategory.GetDisplayName()
                };

                return new BaseResponse<MovieViewModels>()
                {
                    StatusName = StatusName.OK,
                    Data = data
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<MovieViewModels>()
                {
                    Description = $"[GetMovie] : {ex.Message}",
                    StatusName = StatusName.InternalServerError
                };
            }

        }
         
        public  IBaseResponse<List<Movie>> GetMovieList() 
        {
            try
            { 
                var movies = _movieRepository.GetAll().ToList();
                if (!movies.Any())
                {
                    return new BaseResponse<List<Movie>>()
                    {
                        Description = "Найдено 0 элементов",
                        StatusName = StatusName.OK
                    };
                }
                 
                return new BaseResponse<List<Movie>>()
                {
                    Data = movies,
                    StatusName = StatusName.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<Movie>>()
                {
                    Description = $"[GetCars] : {ex.Message}",
                    StatusName = StatusName.InternalServerError
                };
            }

        }

        public async Task<IBaseResponse<Movie>> Edit(int id, MovieViewModels model)
        {
            try
            {
                var movie = await _movieRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);

                if (movie == null)
                {
                    return new BaseResponse<Movie>()
                    {
                        Description = "Movie not found",
                        StatusName = StatusName.MovieNotFound
                    };
                }

                movie.Name = model.Name; 
                movie.Country = model.Country;
                movie.Description = model.Description;
                //movie.MoviesCategory = model.MoviesCategory;

                await _movieRepository.Update(movie);

                return new BaseResponse<Movie>()
                {
                    Data = movie,
                    StatusName = StatusName.OK,
                };

            }
            catch (Exception ex)
            {
                return new BaseResponse<Movie>()
                {
                    Description = $"[Edit] : {ex.Message}",
                    StatusName = StatusName.InternalServerError
                };

            }
        }

        public async Task<IBaseResponse<MovieViewModels>> GetMovieName(string name)
        {
            try
            {
                var movie = await _movieRepository.GetAll().FirstOrDefaultAsync(x => x.Name == name);
                if (movie == null)
                {
                    return new BaseResponse<MovieViewModels>()
                    {
                        Description = "Film не найден",
                        StatusName = StatusName.UserNotFound
                    };
                }
                var data = new MovieViewModels()
                {   
                    Name = movie.Name,
                    Description = movie.Description,
                    Country = movie.Country,
                    MoviesCategory = movie.MoviesCategory,

                };

                return new BaseResponse<MovieViewModels>()
                {
                    StatusName = StatusName.OK,
                    Data = data
                };

            }
            catch (Exception ex)
            {
                return new BaseResponse<MovieViewModels>()
                {
                    Description = $"[GetMovie] : {ex.Message}",
                    StatusName = StatusName.InternalServerError
                };
            }
        }
    }
}
