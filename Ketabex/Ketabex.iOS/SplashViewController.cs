using System;
using BigTed;
using DSoft.Messaging;
using Foundation;
using Ketabex.lib;
using Ketabex.Shared;
using Ketabex.Shared.Api;
using UIKit;

namespace Ketabex.iOS
{
	public partial class SplashViewController : UIViewController
	{


		public SplashViewController (IntPtr handle) : base (handle)
		{

		}

	public override void ViewDidAppear(bool animated)
	    {
	        base.ViewDidAppear(animated);
	        MessageBus.Default.Register<MessageBusPayload>((sender, args) =>
	        {
	            var payload = args as MessageBusPayload;

	            if (payload.BroadcastId  == MessageBusPayload.BroadcastEnum.Exchange && payload.Succeeded)
	            {
	                GlobalUtil.DismissProgress("Exchange");


                    if (GlobalUtil.GetGlobalValue("isSignedUp",false) && Convert.ToBoolean(GlobalUtil.NativeUtil.LoadFromLocal("isAuth")))
	                {
	                    new PostApi().UpdateAllPosts();

                        InvokeOnMainThread(() =>
	                   {
	                       PerformSegue("SplashToMainSegue",this);
	                   });
	                }
	                else
	                {
                        InvokeOnMainThread(() =>
                        {
                            PerformSegue("SplashToPhoneNumberSegue", this);
                        });
	                }
	            }
	        });


	        new Auth().Exchange();
        }

	}
}

