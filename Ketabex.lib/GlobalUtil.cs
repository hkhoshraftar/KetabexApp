using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ketabex
{
    public static class GlobalUtil
    {
        public static IUtil NativeUtil;
        public static Dictionary<string, object> Values = new Dictionary<string, object>();
        public static List<string> ProgressRefs = new List<string>();

        public static void ShowProgress(string progressId = "default")
        {
            if (!ProgressRefs.Any())
                NativeUtil.ShowProgress();

            if (ProgressRefs.All(q => q != progressId))
            {
                ProgressRefs.Add(progressId);
            }
        }

        public static void DismissProgress(string progressId = "default")
        {
            if (ProgressRefs.All(q => q == progressId))
            {
                ProgressRefs.Remove(progressId);
            }
            if (!ProgressRefs.Any())
                NativeUtil.DismissProgress();
        }

        public static void AddOrUpdateGlobalValue(string key, object value)
        {
            if (Values.Any(q => q.Key == key))
            {
                Values["Key"] = value;
            }
            else
            {
                Values.Add(key,value);
            }
        }

        public static T GetGlobalValue<T>(string key,T defaultValue)
        {
            if (Values.Any(q => q.Key == key))
            {
                return (T) Values[key];
            }
            return defaultValue;
        }
    }
}