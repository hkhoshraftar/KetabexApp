using Foundation;
using System;
using DSoft.Messaging;
using Ketabex.Shared;
using Ketabex.Shared.Api;
using UIKit;

namespace Ketabex.iOS
{
    public partial class MainTabLayoutController : UITabBarController
    {
        public MainTabLayoutController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            SelectedIndex = 1;

            MessageBus.Default.Register<MessageBusPayload>((sender, args) =>
            {
                var arg = args as MessageBusPayload;
                if (arg.BroadcastId == MessageBusPayload.BroadcastEnum.UpdatePostsMode && arg.Succeeded)
                {
                    GlobalUtil.DismissProgress("UpdatePostsMode");
                }
            });

            this.NavigationItem.SetRightBarButtonItem(new UIBarButtonItem(UIBarButtonSystemItem.Add, (s,e) => { }),true );
        }
    }
}