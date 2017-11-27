using System;
using System.IO;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Ketabex.lib;
using Ketabex.Shared.Api;
using Environment = System.Environment;

namespace Ketabex.Droid
{
	[Activity (Label = "Ketabex.Android", Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);



		    FindViewById<Button>(Resource.Id.myButton).Click += delegate
		    {
                new Auth().RequestSmsCode("09129329989");
		    };
		    //    Database.GetInstance();
		}
	}
}


