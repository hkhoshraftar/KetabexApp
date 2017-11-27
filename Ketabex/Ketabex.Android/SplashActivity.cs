using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DSoft.Messaging;
using Ketabex.Droid.Surface;
using Ketabex.Shared;
using Ketabex.Shared.Api;

namespace Ketabex.Droid
{
 
    [Activity(Label = "SplashActivity", MainLauncher = true, Theme = "@style/Theme1")]
    public class SplashActivity : AppcompatBaseActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
          this.SetAsActiveContext();

            SetContentView(Resource.Layout.activity_splash);


        
            MessageBus.Default.Register<MessageBusPayload>((sender, args) =>
            {
                var payload = args as MessageBusPayload;
                if (payload.BroadcastId == MessageBusPayload.BroadcastEnum.Exchange && payload.Succeeded)
                {
                    GlobalUtil.DismissProgress("Exchange");


                    if (GlobalUtil.GetGlobalValue("isSignedUp", false) &&
                        Convert.ToBoolean(GlobalUtil.NativeUtil.LoadFromLocal("isAuth")))
                    {
                        new PostApi().UpdateAllPosts();

//                        InvokeOnMainThread(() =>
//                        {
//                            PerformSegue("SplashToMainSegue", this);
//                        });
                    }
                    else
                    {
                        StartActivity(typeof(PhoneEntryActivity));
                        Finish();
                    }
                }


            });

            new Auth().Exchange();

        }
    }
}