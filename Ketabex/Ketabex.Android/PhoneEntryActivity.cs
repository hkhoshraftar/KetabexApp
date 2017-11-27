using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;
using DSoft.Messaging;
using Ketabex.Droid.Surface;
using Ketabex.Shared;
using Ketabex.Shared.Api;

namespace Ketabex.Droid
{
    [Activity(Label = "PhoneEntryActivity")]
    public class PhoneEntryActivity : Activity
    {
        private EditText etPhonenumber;
        private Button bSubmit;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            this.SetAsActiveContext();

           SetContentView(Resource.Layout.actitvity_phonenumber_entry);


            etPhonenumber = FindViewById<EditText>(Resource.Id.etPhoneEntry);
            bSubmit = FindViewById<Button>(Resource.Id.bSubmitNumber);


            bSubmit.Click += delegate(object sender, EventArgs args)
            {
                new Auth().RequestSmsCode(etPhonenumber.Text);
            };

            //Receive RequestSmsCode
            MessageBus.Default.Register<MessageBusPayload>((o, args) =>
            {
                var arg = args as MessageBusPayload;
                if (arg.BroadcastId == MessageBusPayload.BroadcastEnum.RequestSmsCode && arg.Succeeded)
                {
                    GlobalUtil.DismissProgress("RequestSmsCode");
//                    InvokeOnMainThread(() =>
//                    {
//                        PerformSegue("PhoneEntryToCoedEntrySegue", this);
//
//                    });
                }
                else if (arg.BroadcastId == MessageBusPayload.BroadcastEnum.RequestSmsCode && !arg.Succeeded)
                {
                    GlobalUtil.NativeUtil.ShowMessage("خطا");
                }
            });

        }
    }
}