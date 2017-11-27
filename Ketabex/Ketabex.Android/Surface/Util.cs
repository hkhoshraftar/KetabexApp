using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidHUD;
using DSoft.Messaging;
using Ketabex.Shared;

namespace Ketabex.Droid.Surface
{
    public class Util : IUtil
    {
        private readonly Context _context;
        public static Activity CurrentnActivity;

        public Util(Context context)
        {
            _context = context;
        }

        public void ShowMessage(string message)
        {
            Toast.MakeText(_context, message, ToastLength.Short).Show();
        }

        public string GetDbPath()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ketabex.db");
        }

        public void SaveInLocal(string key, string value)
        {
            var pref = _context.GetSharedPreferences("ketabex", FileCreationMode.Private).Edit();
            pref.PutString(key, value);
            pref.Commit();
        }

        public string LoadFromLocal(string key)
        {
            var pref = _context.GetSharedPreferences("ketabex", FileCreationMode.Private);
            return pref.GetString(key, "");
        }

        public string GetDeviceUid()
        {
            return Android.OS.Build.Serial;
        }

        public void SendBroadcast(MessageBusPayload payload)
        {
            MessageBus.Default.Post(payload);
        }


        private ProgressDialog alert;
        public void ShowProgress()
        {
            if (CurrentnActivity != null)
            {
                alert = new ProgressDialog(CurrentnActivity);
                alert.SetTitle("صبر کنید");
                alert.Show();
            }
        }

        public void DismissProgress()
        {
            alert?.Dismiss();
        }
    }
}