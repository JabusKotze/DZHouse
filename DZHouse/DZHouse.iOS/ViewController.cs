using System;

using UIKit;
using Newtonsoft.Json;
using Auth0.SDK;
using DZHouse.DataLayer;
using DZHouse.Helpers;
using BigTed;

namespace DZHouse.iOS
{
	public partial class ViewController : UIViewController
	{
		int count = 1;

		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
            // Perform any additional setup after loading the view, typically from a nib.
            //Button.AccessibilityIdentifier = "myButton";
		}


        public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

        async partial void RightGate_TouchUpInside(UIButton sender)
        {
            BTProgressHUD.Show("Contacting Gates...", maskType: ProgressHUD.MaskType.Gradient);
            APISignInHelper signIn = new APISignInHelper();

            if (string.IsNullOrWhiteSpace(Settings.AuthToken))
            {
                var test = await signIn.SignIn(Keys.Email, Keys.Password);
                BTProgressHUD.Dismiss();
            }
            else
            {

                if (TokenValidator.HasExpired(Settings.AuthToken))
                {

                    if (await signIn.SignIn(Keys.Email, Keys.Password))
                    {

                        APIDeviceHelper sendMessage = new APIDeviceHelper();

                        if (await sendMessage.SendDeviceMessage(Strings.deviceId, Strings.right_gpio_pin, Strings.mode, Strings.right_max_ticks, Strings.right_time_span))
                        {
                            BTProgressHUD.Dismiss();
                            BTProgressHUD.ShowSuccessWithStatus("Right Gate Toggled", 1000);
                        }
                        else
                        {
                            BTProgressHUD.Dismiss();
                            BTProgressHUD.ShowErrorWithStatus(Settings.ErrorMessage, 1000);
                        }
                    }
                    else
                    {
                        BTProgressHUD.Dismiss();
                        BTProgressHUD.ShowErrorWithStatus(Settings.ErrorMessage, 1000);
                    }
                }
                else
                {
                    APIDeviceHelper sendMessage = new APIDeviceHelper();

                    if (await sendMessage.SendDeviceMessage(Strings.deviceId, Strings.right_gpio_pin, Strings.mode, Strings.right_max_ticks, Strings.right_time_span))
                    {
                        BTProgressHUD.Dismiss();
                        BTProgressHUD.ShowSuccessWithStatus("Right Gate Toggled", 1000);
                    }
                    else
                    {
                        BTProgressHUD.Dismiss();
                        BTProgressHUD.ShowErrorWithStatus(Settings.ErrorMessage, 1000);
                    }
                }
            }
        }




        async partial void LeftGate_TouchUpInside(UIButton sender)
        {
            BTProgressHUD.Show("Contacting Gates...", maskType: ProgressHUD.MaskType.Gradient);
            APISignInHelper signIn = new APISignInHelper();

            if (string.IsNullOrWhiteSpace(Settings.AuthToken))
            {
                await signIn.SignIn(Keys.Email, Keys.Password);
                BTProgressHUD.Dismiss();
            }
            else
            {


                if (TokenValidator.HasExpired(Settings.AuthToken))
                {

                    if (await signIn.SignIn(Keys.Email, Keys.Password))
                    {

                        APIDeviceHelper sendMessage = new APIDeviceHelper();

                        if (await sendMessage.SendDeviceMessage(Strings.deviceId, Strings.left_gpio_pin, Strings.mode, Strings.left_max_ticks, Strings.left_time_span))
                        {
                            BTProgressHUD.Dismiss();
                            BTProgressHUD.ShowSuccessWithStatus("Left Gate Toggled", 1000);
                        }
                        else
                        {
                            BTProgressHUD.Dismiss();
                            BTProgressHUD.ShowErrorWithStatus(Settings.ErrorMessage, 1000);
                        }
                    }
                    else
                    {
                        BTProgressHUD.Dismiss();
                        BTProgressHUD.ShowErrorWithStatus(Settings.ErrorMessage, 1000);
                    }
                }
                else
                {
                    APIDeviceHelper sendMessage = new APIDeviceHelper();

                    if (await sendMessage.SendDeviceMessage(Strings.deviceId, Strings.left_gpio_pin, Strings.mode, Strings.left_max_ticks, Strings.left_time_span))
                    {
                        BTProgressHUD.Dismiss();
                        BTProgressHUD.ShowSuccessWithStatus("Left Gate Toggled", 1000);
                    }
                    else
                    {
                        BTProgressHUD.Dismiss();
                        BTProgressHUD.ShowErrorWithStatus(Settings.ErrorMessage, 1000);
                    }
                }
            }
        }
    }
}

