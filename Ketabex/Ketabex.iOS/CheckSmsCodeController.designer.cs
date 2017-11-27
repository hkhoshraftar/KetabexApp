// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Ketabex.iOS
{
    [Register ("CheckSmsCodeController")]
    partial class CheckSmsCodeController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ButtonEditNumber { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ButtonSubmitCode { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField TxtCode { get; set; }

        [Action ("ButtonEditNumber_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void ButtonEditNumber_TouchUpInside (UIKit.UIButton sender);

        [Action ("ButtonSubmitCode_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void ButtonSubmitCode_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (ButtonEditNumber != null) {
                ButtonEditNumber.Dispose ();
                ButtonEditNumber = null;
            }

            if (ButtonSubmitCode != null) {
                ButtonSubmitCode.Dispose ();
                ButtonSubmitCode = null;
            }

            if (TxtCode != null) {
                TxtCode.Dispose ();
                TxtCode = null;
            }
        }
    }
}