using Foundation;
using System;
using Ketabex.Shared.Api;
using UIKit;

namespace Ketabex.iOS
{
    public partial class LatestPostsTabController : UIViewController
    {
        public LatestPostsTabController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            EmbededtabContentController.Mode = PostApi.DataMode.Latest;

            this.NavigationController.TopViewController.Title = "آخرین پست های ارسالی";
        }
    }
}