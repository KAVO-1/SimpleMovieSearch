using SimpleMovieSearch.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMovieSearch.DAL.Interfaces
{
    public interface IMovieRepositoriy : IbaseRepositoriy<Movie>
    {
        Task<Movie> GetMovieName(string name); 
    }
}
