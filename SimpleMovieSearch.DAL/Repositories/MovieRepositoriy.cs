                    using Microsoft.EntityFrameworkCore;
using SimpleMovieSearch.DAL.Interfaces;
using SimpleMovieSearch.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMovieSearch.DAL.Repositories
{
    public class MovieRepositoriy : IBaseRepositoriy<Movie>
    {
        private readonly ApplicationDbContext _context;

        public MovieRepositoriy(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(Movie entity)
        {
            await _context.Movie.AddAsync(entity);
            await _context.SaveChangesAsync();
            
        }

        public async Task Delete(Movie entity)
        {
            _context.Movie.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Movie> GetAll() //это БАЗА
        {
            return _context.Movie;
        }

        public async Task<Movie> Update(Movie entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

    }
}
