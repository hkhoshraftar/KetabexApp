using Foundation;
using System;
using DSoft.Messaging;
using Ketabex.Shared;
using Ketabex.Shared.Api;
using UIKit;

namespace Ketabex.iOS
{
    public partial class CheckSmsCodeController : UIViewController
    {
        public CheckSmsCodeController (IntPtr handle) : base (handle)
        {
            
        }

        partial void ButtonSubmitCode_TouchUpInside(UIButton sender)
        {
            new Auth().CheckSmsCode(TxtCode.Text);
        }

        public override void ViewDidLoad()
        {
            //Receive RequestSmsCode
            MessageBus.Default.Register<MessageBusPayload>((o, args) =>
            {
                var arg = args as MessageBusPayload;
                GlobalUtil.DismissProgress("GetSmsCodeRsult");
                if (arg.BroadcastId == MessageBusPayload.BroadcastEnum.GetSmsCodeRsult && arg.Succeeded)
                {
                    GlobalUtil.NativeUtil.SaveInLocal("isAuth", true.ToString());

                    if ((bool)GlobalUtil.Values["isSignedUp"])
                    {
                        InvokeOnMainThread(() =>
                        {
                            PerformSegue("CheckCodeToMainSegue", this);
                        });
                    }
                    else
                    {
                        InvokeOnMainThread(() =>
                        {
                            PerformSegue("CheckCodeToSignUpSegue", this);
                        });
                    }
                }
                else
                {
                    GlobalUtil.NativeUtil.ShowMessage("خطا");
                }
            });

            base.ViewDidLoad();
        }

        partial void ButtonEditNumber_TouchUpInside(UIButton sender)
        {
           DismissViewController(true,null);
        }
    }
}