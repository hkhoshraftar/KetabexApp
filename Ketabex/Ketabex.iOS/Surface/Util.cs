using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;

using BigTed;
using DSoft.Messaging;
using Foundation;
using Ketabex.iOS.CustomView;
using Ketabex.Shared;
using UIKit;
using Exception = System.Exception;


namespace Ketabex.IOS.Surface
{
    public class Util : IUtil
    {

        
      
        public void ShowMessage(string message)
        {
            try
            {
                new UIAlertView("ketabex",message,null,"باشه").Show();
//                BTProgressHUD.ShowToast(message, ProgressHUD.ToastPosition.Bottom,2000);
         
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public string GetDbPath()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ketabex.db");
        }

        public void SaveInLocal(string key, string value)
        {
            NSUserDefaults.StandardUserDefaults.SetString(value, key);
            NSUserDefaults.StandardUserDefaults.Synchronize();

            //appdelegate create disctinary
        }

        public string LoadFromLocal(string key)
        {
            return NSUserDefaults.StandardUserDefaults.StringForKey(key);
        }

        public string GetDeviceUid()
        {
            try
            {
                string uid =UIDevice.CurrentDevice.IdentifierForVendor.AsString();
//                uid = uid.Length > 10 ? uid.Substring(0, 9) : uid;
                return uid;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                if (string.IsNullOrWhiteSpace(LoadFromLocal("uid")))
                {
                    var uid = Guid.NewGuid().ToString().Substring(0, 10);
                    SaveInLocal("uid",uid);
                }
                return LoadFromLocal("uid");
            }
        }

        public void SendBroadcast(MessageBusPayload payload)
        {
            MessageBus.Default.Post(payload);
        }

        public void ShowProgress()
        {
           BTProgressHUD.Show("صبر کنید ...",maskType:ProgressHUD.MaskType.Gradient);
        }

        public void DismissProgress()
        {
            BTProgressHUD.Dismiss();
        }

        private OnScreenIndicatorView indicator;
        public void OnScreenProgress(UIView view)
        {
            indicator = new OnScreenIndicatorView(view);
            indicator.Show();
        }

        public void DismissOnScreenProgress()
        {
            indicator?.Hide();
        }
    }
}