using Microsoft.Extensions.Logging;
using SimpleMovieSearch.DAL.Interfaces;
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
        private readonly ILogger<UserService> _logger;
        private readonly IBaseRepositoriy<Users> _userRepository;

        public UserService(ILogger<UserService> logger, IBaseRepositoriy<Users> userRepository)
        { 
            _logger = logger;
            _userRepository = userRepository;
        }
        public Task<IBaseResponse<Users>> Create(UserViewModel model)
        {
            throw new NotImplementedException();
        }


        public Task<BaseResponse<IEnumerable<UserViewModel>>> GetUsers()
        {
            throw new NotImplementedException();
        }
        
        public BaseResponse<Dictionary<int, string>> GetRoles()
        {
            throw new NotImplementedException();
        }
    }
}
