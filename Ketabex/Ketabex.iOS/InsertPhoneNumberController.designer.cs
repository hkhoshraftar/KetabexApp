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
    [Register ("InsertPhoneNumberController")]
    partial class InsertPhoneNumberController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton BtnSubmitPhoneNumber { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField TxtPhoneNumber { get; set; }

        [Action ("BtnSubmitPhoneNumber_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnSubmitPhoneNumber_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (BtnSubmitPhoneNumber != null) {
                BtnSubmitPhoneNumber.Dispose ();
                BtnSubmitPhoneNumber = null;
            }

            if (TxtPhoneNumber != null) {
                TxtPhoneNumber.Dispose ();
                TxtPhoneNumber = null;
            }
        }
    }
}