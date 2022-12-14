using SimpleMovieSearch.Domain.Entity;
using SimpleMovieSearch.Domain.Response;
using SimpleMovieSearch.Domain.ViewModels.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMovieSearch.Service.Interfaces
{
    public interface IMovieService
    {
        IBaseResponse<List<Movie>> GetMovieList();
        Task<IBaseResponse<Movie>> CreateMovie(MovieViewModels movieViewModels);
        Task<IBaseResponse<bool>> DeleteMovie(int id);
        Task<IBaseResponse<MovieViewModels>> GetMovie(int id);
        Task<IBaseResponse<MovieViewModels>> GetMovieName(string name);
        Task<IBaseResponse<Movie>> Edit(int id, MovieViewModels model); 
    }
}
