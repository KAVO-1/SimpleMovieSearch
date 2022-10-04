using SimpleMovieSearch.Domain.Response;
using SimpleMovieSearch.Domain.ViewModels.Account;
using SimpleMovieSearch.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMovieSearch.Service.Execution
{
    public class AccountService : IAccountService
    {
        public Task<BaseResponse<ClaimsIdentity>> Login(LoginViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<ClaimsIdentity>> Register(RegisterViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
