using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Acr.UserDialogs;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Ketabex.Droid.Surface;
using Ketabex.lib;
using Ketabex.Shared.Api;
using Environment = System.Environment;

namespace Ketabex.Droid
{
    
    [Application]
    public class TheApplication  : Application
    {
        protected TheApplication(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {

        }

        public override void OnCreate()
        {
            base.OnCreate();
            GlobalUtil.NativeUtil = new Util(ApplicationContext);
            Database.GetInstance();

            new Auth().Exchange();

            UserDialogs.Init(this);
        }

    }
}