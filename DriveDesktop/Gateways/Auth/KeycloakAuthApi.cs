using DriveDesktop.Authentication;
using DriveDesktop.Extensions;
using DriveDesktop.Gateways.Auth.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DriveDesktop.Gateways.Auth
{
    internal class KeycloakAuthApi : IAuthApi
    {
        private readonly HttpClient _httpClient;

        private readonly string _realm;
        private readonly string _clientId;

        public KeycloakAuthApi(string baseUrl, string realm, string clientId)
        {
            this._realm = realm;
            this._clientId = clientId;
            this._httpClient = new HttpClient()
            {
                BaseAddress = new Uri(baseUrl),
                Timeout = TimeSpan.FromSeconds(30)
            };
        }

        public async Task<Token> FetchToken(UserCredentials credentials)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, $"/realms/{_realm}/protocol/openid-connect/token");
            request.Headers.Add("Accept", "application/json");
            request.Content = new FormUrlEncodedContent(new Dictionary<string, string>
                        {
                            { "grant_type", "password" },
                            { "username", credentials.Username },
                            { "password", credentials.Password },
                            { "client_id", _clientId   },
                            { "scope", "openid" },
                        });

            var response = await _httpClient.SendAsync(request);
            return await response.DesserializeBodyAsync<Token>();
        }

        public async Task<Token> RefreshToken(string refreshToken)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, $"/realms/{_realm}/protocol/openid-connect/token");
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Accept-Encoding", "gzip, deflate, br");
            request.Content = new FormUrlEncodedContent(new Dictionary<string, string>
                        {
                            { "grant_type", "refresh_token" },
                            { "refresh_token", refreshToken },
                            { "client_id", _clientId   },
                            { "scope", "openid" },
                        });

            var response = await _httpClient.SendAsync(request);
            return await response.DesserializeBodyAsync<Token>();
        }
    }
}
