using SimpleMovieSearch.DAL.Interfaces;
using SimpleMovieSearch.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMovieSearch.DAL.Repositories
{
    internal class UserRepository : IBaseRepositoriy<User>
    {
        public Task Create(User entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User> Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
