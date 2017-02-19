using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModernHttpClient;
using System.Net.Http;
using System.Net.Http.Headers;
using DZHouse.Helpers;

namespace DZHouse.DataLayer
{
    public static class Client
    {
        /// <summary>
        /// Generates Http Client 
        /// </summary>
        /// <returns>Authorized Http Client</returns>
        public static HttpClient GetClient()
        {
            string authorizationKey = "";
            HttpClient client = new HttpClient(new NativeMessageHandler());
            client.MaxResponseContentBufferSize = 256000;
            if (string.IsNullOrEmpty(authorizationKey))
            {
                authorizationKey = Settings.AuthToken;
            }

            client.DefaultRequestHeaders.Add("x-zumo-auth", authorizationKey);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }
    }
}
