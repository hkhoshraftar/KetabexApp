using Foundation;
using System;
using DSoft.Messaging;
using Ketabex.Shared;
using Ketabex.Shared.Api;
using UIKit;

namespace Ketabex.iOS
{
    public partial class SignUpController : UIViewController
    {
        public SignUpController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            MessageBus.Default.Register<MessageBusPayload>((o, args) =>
            {
                var arg = args as MessageBusPayload;
                GlobalUtil.DismissProgress("UserSignUp");
                if (arg.BroadcastId == MessageBusPayload.BroadcastEnum.UserSignUp && arg.Succeeded)
                {
                    InvokeOnMainThread(() => { PerformSegue("SignUpToMainSegue", this); });
                }
                else
                {
                    GlobalUtil.NativeUtil.ShowMessage("خطا");
                }
            });

            base.ViewDidLoad();
        }

        partial void BtnSignUp_TouchUpInside(UIButton sender)
        {
            new Auth().Signup(TxtUsername.Text, TxtNickname.Text);
        }
    }
}