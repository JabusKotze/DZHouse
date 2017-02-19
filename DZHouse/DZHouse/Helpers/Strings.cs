using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZHouse.Helpers
{
    public static class Strings
    {
        //Auth0 Url strings
        public static readonly string SignupURL = "https://appmit.auth0.com/dbconnections/signup";
        public static readonly string SignInURL = "https://appmit.auth0.com/oauth/ro";
        public static readonly string ChangePasswordURL = "https://appmit.auth0.com/dbconnections/change_password";
        public static readonly string metadata = "https://appmit.auth0.com/api/v2/users";


        //Azure API URLs        
        public static readonly string ManageDeviceAPI_URL = "https://getappmit.azurewebsites.net/api/v1/manage/device";
        
       
        //Error Messages
        public static readonly string invalidUsernamePassword = "Incorrect Username Password";
        public static readonly string userAlreadyExists = "Account already exists";
        public static readonly string noInternet = "No Internet Connection";
        public static readonly string Oops = "Oops! Something went wrong \nPlease try again";
        public static readonly string couldNotSignIn = "Oops! Could not sign in \nPlease sign in again";
        public static readonly string noAccountFound = "This Account does not exist";
        public static readonly string couldNotSignOut = "Oops! Could not sign out\nPlease try again";
        public static readonly string requiredFieldsAreMissing = "Required fields are missing";
        public static readonly string passwordStrength = "Password must contain at least:\n1 Uppercase letter \n1 Numerical Value \n1 Lowercase letter\n and contain 8 characters or more";
        public static readonly string notValidBarcode = "Barcode Not Valid";

        public static readonly string onYourMarks = "On Your Marks";
        public static readonly string getSet = "Get Set";
        public static readonly string go = "Go!";


        //Device Variables
        public static readonly string deviceId = "61957A97-C8F0-4117-B173-41C9BACBB373";
        public static readonly string mode = "TOGGLE";
        //Left Gate Variables
        public static readonly int left_max_ticks = 1;
        public static readonly int left_time_span = 500;
        public static readonly int left_gpio_pin = 4;
        //Right Gate Variables
        public static readonly int right_max_ticks = 1;
        public static readonly int right_time_span = 500;
        public static readonly int right_gpio_pin = 3;
    }
}
