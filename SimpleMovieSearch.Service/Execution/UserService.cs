using SimpleMovieSearch.Domain.Entity;
using SimpleMovieSearch.Domain.Response;
using SimpleMovieSearch.Domain.ViewModels.User;
using SimpleMovieSearch.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMovieSearch.Service.Execution
{
    public class UserService : IUserService
    {
        public Task<IBaseResponse<User>> Create(UserViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<IEnumerable<UserViewModel>>> GetUsers()
        {
            throw new NotImplementedException();
        }
    }
}
