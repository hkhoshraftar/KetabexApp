using Foundation;
using System;
using BigTed;
using DSoft.Messaging;
using Ketabex.Shared;
using Ketabex.Shared.Api;
using UIKit;

namespace Ketabex.iOS
{
    public partial class InsertPhoneNumberController : UIViewController
    {
        public InsertPhoneNumberController (IntPtr handle) : base (handle)
        {
        }
     

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            //Receive RequestSmsCode
            MessageBus.Default.Register<MessageBusPayload>((o, args) =>
            {
                var arg = args as MessageBusPayload;
                GlobalUtil.DismissProgress("RequestSmsCode");

                if (arg.BroadcastId == MessageBusPayload.BroadcastEnum.RequestSmsCode && arg.Succeeded)
                {
                    InvokeOnMainThread(() =>
                    {
                        PerformSegue("PhoneEntryToCoedEntrySegue", this);

                    });
                }
                else if (arg.BroadcastId == MessageBusPayload.BroadcastEnum.RequestSmsCode && !arg.Succeeded)
                {
                    GlobalUtil.NativeUtil.ShowMessage("خطا");
                }
            });
        }


        partial void BtnSubmitPhoneNumber_TouchUpInside(UIButton sender)
        {
            new Auth().RequestSmsCode(TxtPhoneNumber.Text);

        }
    }
}