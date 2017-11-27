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

namespace Ketabex.Droid.Surface
{
    public static class Extenstions
    {

        public static void SetAsActiveContext(this Activity activity)
        {
            Util.CurrentnActivity = activity;
        }
    }
}