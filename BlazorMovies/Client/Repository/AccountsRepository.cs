using BlazorMovies.Client.Helpers;
using BlazorMovies.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Repository
{
    public class AccountsRepository: IAccountsRepository
    {
        private readonly IHttpService httpService;
        private readonly string url = "api/accounts";

        public AccountsRepository(IHttpService httpService)
        {
            this.httpService = httpService;
        }

        public async Task<UserToken> Register(UserInfo userInfo)
        {
            var response = await httpService.Post<UserInfo, UserToken>($"{url}/create", userInfo);

            if (!response.Sucess)
            {
                throw new ApplicationException(await response.GetBody());
            }

            return response.Response;
        }

        public async Task<UserToken> Login(UserInfo userInfo)
        {
            var response = await httpService.Post<UserInfo, UserToken>($"{url}/login", userInfo);

            if (!response.Sucess)
            {
                throw new ApplicationException(await response.GetBody());
            }

            return response.Response;
        }
    }
}
