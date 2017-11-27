using Foundation;
using System;
using Ketabex.Shared.Api;
using UIKit;

namespace Ketabex.iOS
{
    public partial class FollowingPostsTabCOntroller : UIViewController
    {
        public FollowingPostsTabCOntroller (IntPtr handle) : base (handle)
        {
        }
        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            EmbededtabContentController.Mode = PostApi.DataMode.Following;
            this.NavigationController.TopViewController.Title = "پست هاس دنبال شوندگان";

        }
    }
}