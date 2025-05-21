using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveDesktop.Authentication
{
    internal interface ITokenSession
    {
        Guid Id { get; }

        Boolean IsReady { get; }

        Token Token { get; }

        DateTime CreatedAt { get; }

        DateTime RefreshedAt { get; }

        DateTime ExpiresAt { get; }

        Boolean Expired { get; }

        void Close();

        void Refresh();

    }
}
