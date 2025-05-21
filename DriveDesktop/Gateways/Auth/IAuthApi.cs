using DriveDesktop.Authentication;
using DriveDesktop.Gateways.Auth.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveDesktop.Gateways.Auth
{
    public interface IAuthApi
    {

        Task<Token> FetchToken(UserCredentials credentials);

        Task<Token> RefreshToken(string refreshToken);

    }
}
