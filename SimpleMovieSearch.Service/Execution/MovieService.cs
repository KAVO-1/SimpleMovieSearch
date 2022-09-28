using SimpleMovieSearch.DAL.Interfaces;
using SimpleMovieSearch.Domain.Entity;
using SimpleMovieSearch.Domain.Enum;
using SimpleMovieSearch.Domain.Response;
using SimpleMovieSearch.Domain.ViewModels.Movie;
using SimpleMovieSearch.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMovieSearch.Service.Execution
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepositoriy _movieRepository;

        public MovieService(IMovieRepositoriy movieRepository)
        {
            _movieRepository = movieRepository;
        }


        public async Task<IBaseResponse<MovieViewModels>> CreateMovie(MovieViewModels movieViewModels)
        {
            var baseResponse = new BaseResponse<MovieViewModels>();
            try
            {
                var movie = new Movie()
                {
                    Name = movieViewModels.Name,
                    Description = movieViewModels.Description,
                    Country = movieViewModels.Country,
                    MoviesCategory = movieViewModels.MoviesCategory,
                };
                await _movieRepository.Create(movie);
            }
            catch (Exception ex)
            {
                return new BaseResponse<MovieViewModels>()
                {
                    Description = $"[CreateMovie] : {ex.Message}",
                    StatusName = StatusName.InternalServerError
                };
            }
            return baseResponse;

        }

        ////////////////////////////////////////////////////////////////////////////


        public async Task<IBaseResponse<bool>> DeleteMovie(int id)
        {
            var baseResponse = new BaseResponse<bool>()
            {
                Data = true
            };
            try
            {
                var movie = await _movieRepository.Get(id);

                if (movie == null)
                {
                    baseResponse.Description = "Error, user not found";
                    baseResponse.StatusName = StatusName.UserNotFound;
                    baseResponse.Data = false;
                    return baseResponse;
                }
                
                await _movieRepository.Delete(movie);
                return baseResponse;

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
            var baseResponse = new BaseResponse<MovieViewModels>();
            try
            {
                var movie = await _movieRepository.Get(id);

                if (movie == null)
                {
                    baseResponse.Description = "Error, user not found";
                    baseResponse.StatusName = StatusName.UserNotFound;
                    return baseResponse; 
                }
                var data = new MovieViewModels()
                {
                    Name = movie.Name,
                    Country = movie.Country,
                    Description = movie.Description,
                    MoviesCategory = movie.MoviesCategory,
                    Id = movie.Id,
                };

                baseResponse.StatusName = StatusName.OK;
                baseResponse.Data = data;
                return baseResponse;

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
         


        public async Task<IBaseResponse<Movie>> GetMovieName(string name)
        {
            var baseResponse = new BaseResponse<Movie>();

            try
            {
                var movie = await _movieRepository.GetMovieName(name);

                if (movie == null)
                {
                    baseResponse.Description = "Error, user not found";
                    baseResponse.StatusName = StatusName.UserNotFound;
                    return baseResponse;
                }
                baseResponse.Data = movie;
                return baseResponse;

            }
            catch (Exception ex)
            {
                return new BaseResponse<Movie>()
                {
                    Description = $"[GetMovieName] : {ex.Message}",
                    StatusName = StatusName.InternalServerError
                };

            }

        }









        public async Task<IBaseResponse<IEnumerable<Movie>>> GetMovieList() 
        {
            var baseResponse = new BaseResponse<IEnumerable<Movie>>();
            try
            {
                var movies = await _movieRepository.Select();

                if (movies.Count==0)
                {
                    baseResponse.Description = "Error, zero elements found";
                    baseResponse.StatusName = StatusName.OK;
                    return baseResponse;
                }
                
                baseResponse.Data = movies;
                baseResponse.StatusName = StatusName.OK;
                return baseResponse;

            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Movie>>()
                {
                    Description = $"[GetMovieList] : {ex.Message}",
                    StatusName = StatusName.InternalServerError
                };

            }

        }

        public async Task<IBaseResponse<Movie>> Edit(int id, MovieViewModels model)
        {
            var baseResponse = new BaseResponse<Movie>();
            try
            {
                var movie = await _movieRepository.Get(id);

                if (movie == null)
                { 
                    baseResponse.StatusName = StatusName.MovieNotFound; 
                    baseResponse.Description = "Error, movie not found";
                    return baseResponse;
                }

                movie.Name = model.Name; 
                movie.Country = model.Country;
                movie.Description = model.Description;
                movie.MoviesCategory = model.MoviesCategory;

                await _movieRepository.Update(movie);
                return baseResponse;
                    
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
    }
}
