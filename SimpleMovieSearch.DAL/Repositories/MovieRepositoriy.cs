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
    public class MovieRepositoriy : IMovieRepositoriy
    {
        private readonly ApplicationDbContext _context;

        public MovieRepositoriy(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(Movie entity)
        {
            await _context.Movie.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Movie entity)
        {
            _context.Movie.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Movie> Get(int id)
        {
            return await _context.Movie.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Movie> GetMovieName(string name)
        {
            return await _context.Movie.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<List<Movie>> Select()
        {
            return await _context.Movie.ToListAsync();
        }

        public async Task<Movie> Update(Movie entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
