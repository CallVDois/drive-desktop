using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveDesktop.Authentication
{
    public interface ITokenProvider
    {
        string GetTokenType();

        string? GetAccessToken();

        void CloseSession();
    }
}
