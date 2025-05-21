namespace DriveDesktop.Authentication
{
    internal class TokenSession : ITokenSession, IDisposable
    {
        private ITokenFetcher _fetcher;

        private readonly Task<Token> _fetchToken;
        private readonly Task<Token> _refreshToken;

        private readonly Semaphore _mutex = new(1, 1);

        private readonly Guid _id = Guid.NewGuid();
        private bool _isReady = false;
        private Token _token = new();
        private readonly DateTime _createdAt = DateTime.UtcNow;
        private DateTime _refreshedAt = DateTime.UtcNow;
        private bool _expired = false;

        internal TokenSession(ITokenFetcher fetcher)
        {
            _fetcher = fetcher;
            _fetchToken = _fetcher.FetchToken();
            _refreshToken = _fetcher.RefreshToken(_token.RefreshToken);
            FetchTokenAsync(_fetchToken);
        }

        public Guid Id => _id;

        public Token Token
        {
            get
            {
                _mutex.WaitOne();
                try
                {
                    return _token;
                }
                finally
                {
                    _mutex.Release();
                }
            }
        }

        public DateTime CreatedAt => _createdAt;

        public DateTime RefreshedAt => _refreshedAt;

        public bool Expired => _expired;

        public bool IsReady => _isReady;

        public DateTime ExpiresAt => DateTime.UtcNow.AddSeconds(Token.ExpiresIn);

        public void Close()
        {
            _mutex.WaitOne();
            this._token = new Token();
            _mutex.Release();
            this._token = null!;
            this._isReady = false;
            this._expired = true;
        }

        public void Refresh()
        {
            FetchTokenAsync(_refreshToken);
        }

        public void Dispose()
        {
            Close();
            _mutex?.Dispose();
            _fetcher = null!;
        }

        private async void FetchTokenAsync(Task<Token> fetchTask)
        {
            try
            {
                var token = await fetchTask;
                if (token != null)
                {
                    _mutex.WaitOne();
                    _token = token;
                    _mutex.Release();
                    _isReady = true;
                    _refreshedAt = DateTime.UtcNow;
                }
                else
                {
                    _isReady = false;
                    _expired = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
