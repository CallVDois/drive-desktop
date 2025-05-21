using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveDesktop.Extensions
{
    public static class HttpClientExtensions
    {
        
        public static async Task<T> DesserializeBodyAsync<T>(this HttpResponseMessage response)
        {
            var result = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            if (result == null)
                throw new InvalidOperationException("Failed to deserialize the response body.");

            return result;
        }
    }
}
