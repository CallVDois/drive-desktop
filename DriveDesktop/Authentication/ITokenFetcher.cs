using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveDesktop.Authentication
{
    internal interface ITokenFetcher
    {
        Task<Token> FetchToken();

        Task<Token> RefreshToken(string refreshToken);

    }
}
