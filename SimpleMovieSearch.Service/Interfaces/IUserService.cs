using SimpleMovieSearch.Domain.Entity;
using SimpleMovieSearch.Domain.Response;
using SimpleMovieSearch.Domain.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMovieSearch.Service.Interfaces
{
    public interface IUserService
    {
        Task<IBaseResponse<User>> Create(UserViewModel model);
        Task<BaseResponse<IEnumerable<UserViewModel>>> GetUsers();
    }
}
