using Foundation;
using System;
using Ketabex.Shared.Api;
using UIKit;

namespace Ketabex.iOS
{
    public partial class TopPostsTabController : UIViewController
    {
        public TopPostsTabController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            EmbededtabContentController.Mode = PostApi.DataMode.Top;
            this.NavigationController.TopViewController.Title ="برترین پست ها";

        }
    }
}