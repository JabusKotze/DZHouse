using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Content.PM;
using AndroidHUD;
using DZHouse.Services;
using DZHouse.DataLayer;
using DZHouse.Helpers;
using Auth0.SDK;

namespace DZHouse.Droid.Activities
{
    [Activity(Label = "@string/app_name", Icon = "@drawable/icon", MainLauncher = true, NoHistory = true, LaunchMode = LaunchMode.SingleTop, Theme = "@style/DZHouseTheme.Splash", ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashActivity : Activity
    {
        
        protected override void OnStart()
        {
            base.OnStart();
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.SplashScreen);
            
            
            //Start timer for launch screen
            Timer timer = new Timer();
            timer.Interval = 3000;
            timer.AutoReset = false;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private async void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            APISignInHelper signIn = new APISignInHelper();
            AndHUD.Shared.Show(this);
            if (string.IsNullOrWhiteSpace(Settings.AuthToken))
            {
                if (await signIn.SignIn(Keys.Email,Keys.Password))
                {
                    AndHUD.Shared.Dismiss(this);                                        
                    var intent = new Intent(this, typeof(MainActivity));
                    intent.SetFlags(ActivityFlags.ClearTop | ActivityFlags.ClearTask);
                    StartActivity(intent);                    
                }
                else
                {
                    AndHUD.Shared.Dismiss(this);
                    AndHUD.Shared.ShowError(this, Settings.ErrorMessage, MaskType.Black, TimeSpan.FromSeconds(3));                                        
                }
            }
            else 
            {
                if (TokenValidator.HasExpired(Settings.AuthToken))
                {
                    if (await signIn.SignIn(Keys.Email, Keys.Password))
                    {
                        AndHUD.Shared.Dismiss(this);
                        var intent = new Intent(this, typeof(MainActivity));
                        intent.SetFlags(ActivityFlags.ClearTop | ActivityFlags.ClearTask);
                        StartActivity(intent);
                    }
                    else
                    {
                        AndHUD.Shared.Dismiss(this);
                        AndHUD.Shared.ShowError(this, Settings.ErrorMessage, MaskType.Black, TimeSpan.FromSeconds(3));
                    }
                }
                else
                {
                    AndHUD.Shared.Dismiss(this);
                    var intent = new Intent(this, typeof(MainActivity));
                    intent.SetFlags(ActivityFlags.ClearTop | ActivityFlags.ClearTask);
                    StartActivity(intent);
                }                                   
            }
        }
    }
}