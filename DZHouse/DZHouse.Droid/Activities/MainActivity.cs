using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Auth0.SDK;
using DZHouse.Helpers;
using AndroidHUD;
using Android.Content.PM;
using DZHouse.DataLayer;

namespace DZHouse.Droid.Activities
{
    [Activity(Label = "@string/app_name", Icon = "@drawable/icon", LaunchMode = LaunchMode.SingleTop, Theme = "@style/DZHouseTheme")]
    public class MainActivity : BaseActivity
	{
		
        RelativeLayout layout;

        protected override int LayoutResource
        {
            get
            {
                return Resource.Layout.Main;
            }
        }

        protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);
            
            layout = FindViewById<RelativeLayout>(Resource.Id.main_screen);
            FindViewById<Button>(Resource.Id.left_gate).Click += LeftGateClick;
            FindViewById<Button>(Resource.Id.right_gate).Click += RightGateClick;                        
        }

        private async void RightGateClick(object sender, EventArgs e)
        {
            AndHUD.Shared.Show(this, "Contacting Gate...", maskType: MaskType.Black);
            if (TokenValidator.HasExpired(Settings.AuthToken))
            {
                APISignInHelper signIn = new APISignInHelper();
                if (await signIn.SignIn(Keys.Email, Keys.Password))
                {

                    APIDeviceHelper sendMessage = new APIDeviceHelper();

                    if (await sendMessage.SendDeviceMessage(Strings.deviceId, Strings.right_gpio_pin, Strings.mode, Strings.right_max_ticks, Strings.right_time_span))
                    {
                        AndHUD.Shared.Dismiss(this);
                        AndHUD.Shared.ShowSuccess(this, "Right Gate Toggled", MaskType.Black, TimeSpan.FromSeconds(3));
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
                    AndHUD.Shared.ShowError(this, Settings.ErrorMessage, MaskType.Black, TimeSpan.FromSeconds(3));
                }
            }
            else
            {
                APIDeviceHelper sendMessage = new APIDeviceHelper();

                if (await sendMessage.SendDeviceMessage(Strings.deviceId, Strings.right_gpio_pin, Strings.mode, Strings.right_max_ticks, Strings.right_time_span))
                {
                    AndHUD.Shared.Dismiss(this);
                    AndHUD.Shared.ShowSuccess(this, "Right Gate Toggled", MaskType.Black, TimeSpan.FromSeconds(3));
                }
                else
                {
                    AndHUD.Shared.Dismiss(this);
                    AndHUD.Shared.ShowError(this, Settings.ErrorMessage, MaskType.Black, TimeSpan.FromSeconds(3));
                }
            }
        }

        private async void LeftGateClick(object sender, EventArgs e)
        {
            AndHUD.Shared.Show(this, "Contacting Gate...", maskType: MaskType.Black);            
            if (TokenValidator.HasExpired(Settings.AuthToken))
            {
                APISignInHelper signIn = new APISignInHelper();
                if (await signIn.SignIn(Keys.Email, Keys.Password))
                {
                    
                    APIDeviceHelper sendMessage = new APIDeviceHelper();
                    
                    if(await sendMessage.SendDeviceMessage(Strings.deviceId,Strings.left_gpio_pin,Strings.mode,Strings.left_max_ticks,Strings.left_time_span))
                    {
                        AndHUD.Shared.Dismiss(this);
                        AndHUD.Shared.ShowSuccess(this, "Left Gate Toggled", MaskType.Black, TimeSpan.FromSeconds(3));
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
                    AndHUD.Shared.ShowError(this, Settings.ErrorMessage, MaskType.Black, TimeSpan.FromSeconds(3));
                }
            }
            else
            {
                APIDeviceHelper sendMessage = new APIDeviceHelper();

                if (await sendMessage.SendDeviceMessage(Strings.deviceId, Strings.left_gpio_pin, Strings.mode, Strings.left_max_ticks, Strings.left_time_span))
                {
                    AndHUD.Shared.Dismiss(this);
                    AndHUD.Shared.ShowSuccess(this, "Left Gate Toggled", MaskType.Black, TimeSpan.FromSeconds(3));
                }
                else
                {
                    AndHUD.Shared.Dismiss(this);
                    AndHUD.Shared.ShowError(this, Settings.ErrorMessage, MaskType.Black, TimeSpan.FromSeconds(3));
                }
            }            
        }
    }
}


