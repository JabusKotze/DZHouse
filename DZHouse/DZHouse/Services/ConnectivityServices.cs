using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Connectivity;
using DZHouse.Helpers;

namespace DZHouse.Services
{
    public class ConnectivityService
    {
        public static async Task<bool> IsConnected()
        {
            return await CrossConnectivity.Current.IsRemoteReachable(Keys.ApplicationMobileService, 80, 5000);
        }
    }
}
