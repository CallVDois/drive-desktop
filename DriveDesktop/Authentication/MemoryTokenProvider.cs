using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveDesktop.Authentication
{
    public class MemoryTokenProvider : ITokenProvider
    {
        private ITokenSession _session;

        internal MemoryTokenProvider(ITokenSession session)
        {
            this._session = session;
            _ = autoRefreshLoop();
        }

        public string GetTokenType()
        {
            return this._session.Token.TokenType;
        }

        public string? GetAccessToken()
        {
            return this._session.Token.AccessToken;
        }

        public void CloseSession()
        {
            this._session.Close();
        }

        private async Task autoRefreshLoop()
        {
            while (!_session.Expired)
                await refreshSession();
        }

        private async Task refreshSession()
        {
            await Task.Delay(_session.ExpiresAt - DateTime.UtcNow);
            this._session.Refresh();
        }
    }

}