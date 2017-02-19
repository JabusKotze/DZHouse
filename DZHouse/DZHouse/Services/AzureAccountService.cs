using DZHouse.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZHouse.Services
{
    public class AzureAccountService
    {
        private static AzureAccountService instance;
              

        public static AzureAccountService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AzureAccountService();
                }

                return instance;
            }
        }

        public string AuthenticationToken { get; set; }
        
        public bool ReadyToSignIn
        {
            get { return !string.IsNullOrEmpty(AuthenticationToken); }
        }

        private AzureAccountService()
        {
            FetchAuthenticationToken();
        }

        void FetchAuthenticationToken()
        {
            AuthenticationToken = Settings.AuthToken;            
        }
    }
}
