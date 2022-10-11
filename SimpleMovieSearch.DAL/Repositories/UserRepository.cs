using SimpleMovieSearch.DAL.Interfaces;
using SimpleMovieSearch.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMovieSearch.DAL.Repositories
{
    public class UserRepository : IBaseRepositoriy<Users>
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(Users entity)
        {
            await _dbContext.Users.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Users entity)
        {
            _dbContext.Users.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<Users> GetAll()
        {
           return _dbContext.Users;
        }

        public async Task<Users> Update(Users entity)
        {
            _dbContext.Users.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
