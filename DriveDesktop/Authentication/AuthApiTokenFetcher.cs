using DriveDesktop.Gateways.Auth;
using DriveDesktop.Gateways.Auth.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveDesktop.Authentication
{
    internal class AuthApiTokenFetcher : ITokenFetcher
    {
        private readonly IAuthApi authApi;
        private readonly UserCredentials credentials;

        internal AuthApiTokenFetcher(IAuthApi authApi, UserCredentials credentials)
        {
            this.authApi = authApi;
            this.credentials = credentials;
        }

        Task<Token> ITokenFetcher.FetchToken()
        {
            return authApi.FetchToken(credentials);
        }

        Task<Token> ITokenFetcher.RefreshToken(string refreshToken)
        {
            return authApi.RefreshToken(refreshToken);
        }

    }
}
