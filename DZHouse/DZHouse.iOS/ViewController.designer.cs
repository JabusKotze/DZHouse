// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace DZHouse.iOS
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton LeftGate { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton RightGate { get; set; }

        [Action ("LeftGate_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void LeftGate_TouchUpInside (UIKit.UIButton sender);

        [Action ("RightGate_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void RightGate_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (LeftGate != null) {
                LeftGate.Dispose ();
                LeftGate = null;
            }

            if (RightGate != null) {
                RightGate.Dispose ();
                RightGate = null;
            }
        }
    }
}