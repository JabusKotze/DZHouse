using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Diagnostics;
using System.Net.Http.Headers;
using DZHouse.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DZHouse.Services;
using ModernHttpClient;

namespace DZHouse.DataLayer
{
    public class APISignInHelper
    {
        HttpClient client;

        public HttpClient GetClient()
        {
            client = new HttpClient(new NativeMessageHandler());
            client.MaxResponseContentBufferSize = 256000;
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
            //return Client.GetClient();
        }


        public async Task<bool> SignIn(string email, string password)
        {
            string token = "";
            var uri = new Uri(Strings.SignInURL);
            bool result = false;

            if (await ConnectivityService.IsConnected() == false)
            {
                Settings.ErrorMessage = Strings.noInternet;
                return false;
            }

            Dictionary<string, string> data = new Dictionary<string, string>();

            data.Add("client_id", Keys.Auth0ApplicationNameClientId);
            data.Add("username", email);
            data.Add("password", password);
            data.Add("connection", Keys.AuthConnectionDZHouse);
            data.Add("grant_type", "password");
            data.Add("scope", "openid");

            client = GetClient();

            try
            {

                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;

                response = await client.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var jsonObject = JObject.Parse(jsonString);
                    token = jsonObject["id_token"].ToString();
                    result = true;
                    Settings.AuthToken = token;
                }
                else
                {
                    var res = response.StatusCode.ToString();
                    Settings.ErrorMessage = Strings.noAccountFound;
                    result = false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Settings.ErrorMessage = Strings.Oops;
                result = false;
            }

            return result;
        }


    }

    
}
