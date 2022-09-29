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
        Task<IBaseResponse<IEnumerable<Movie>>> GetMovieList();
        Task<IBaseResponse<MovieViewModels>> CreateMovie(MovieViewModels movieViewModels);
        Task<IBaseResponse<bool>> DeleteMovie(int id);
        Task<IBaseResponse<MovieViewModels>> GetMovie(int id);
        Task<IBaseResponse<Movie>> GetMovieName(string name);
        Task<IBaseResponse<Movie>> Edit(int id, MovieViewModels model); 
    }
}
