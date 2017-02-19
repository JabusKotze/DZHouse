using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Diagnostics;
using DZHouse.Helpers;
using DZHouse.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DZHouse.DataLayer
{

    public class DeviceMessage
    {
        [JsonProperty("gpio_pin")]
        public int GpioPin { get; set; }

        [JsonProperty("mode")]
        public string Mode { get; set; }

        [JsonProperty("max_ticks")]
        public int MaxTicks { get; set; }

        [JsonProperty("time_span")]
        public int TimeSpan { get; set; }
    }

    public class APIDeviceHelper
    {
        HttpClient client;              

        /// <summary>
        /// Initialize Http Client
        /// </summary>
        /// <returns>The client</returns>
        private HttpClient GetClient()
        {
            client = Client.GetClient();            
            return client;
        }



        public async Task<bool> SendDeviceMessage(string deviceId, int gpioPin, string mode, int maxTicks, int timeSpan)
        {
            bool result = false;
            string message;
            var uri = new Uri(Strings.ManageDeviceAPI_URL + "/" + deviceId);

            if (await ConnectivityService.IsConnected() == false)
            {
                Settings.ErrorMessage = Strings.noInternet;
                return result;
            }


            var data = new DeviceMessage
            {
                GpioPin = gpioPin,
                Mode = mode,
                MaxTicks = maxTicks,
                TimeSpan = timeSpan
            };

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
                    result = true;                    
                }
                else
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var jsonObject = JObject.Parse(jsonString);
                    message = jsonObject["message"].ToString();
                    result = false;
                    Settings.ErrorMessage = message;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Settings.ErrorMessage = Strings.Oops;
            }

            return result;
        }
    }
}
