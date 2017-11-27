using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Ketabex.Shared.Models;
using Newtonsoft.Json.Linq;

namespace Ketabex.Shared.Api
{
    public class BaseApi
    {
//        protected const string SITE_BASE_ADDRESS = "http://192.168.6.1:62443/";
        protected const string SITE_BASE_ADDRESS = "https://ketabex.mecadium.ir/";
        protected const string SITE_BASE_API = SITE_BASE_ADDRESS + "api/";
        protected const string SITE_CONNECT_API = SITE_BASE_API +"connect";


        private WebClient _client;

        protected Task<string> CallUnAuth(string url, NameValueCollection pairs)
        {
            CheckConnection();


            _client = new WebClient();
           return  Task.Run(()=>
           {
               return Encoding.UTF8.GetString(_client.UploadValues(url, pairs));
           });

        }

        protected Task<string> Call(string url, NameValueCollection pairs)
        {
            try
            {
                CheckConnection();

                _client = new WebClient();
                _client.Headers["uid"] = GlobalUtil.NativeUtil.GetDeviceUid();
                _client.Headers["token"] = GlobalUtil.NativeUtil.LoadFromLocal("apiToken");

                return Task.Run(() => Encoding.UTF8.GetString(_client.UploadValues(url, pairs)));
            }
            catch (Exception e)
            {
                return Task.Run(() => "{}");
            }
           
        }

        private static void CheckConnection()
        {
            WebRequest request = WebRequest.Create(SITE_CONNECT_API);
            HttpWebResponse response = (HttpWebResponse) request.GetResponse();
            if (response == null || response.StatusCode != HttpStatusCode.OK)
            {
                GlobalUtil.NativeUtil.ShowMessage("اتصال به سرور برقرار نمی باشد");
                throw new Exception("Could not connecto to web api");
            }
        }

        protected bool AnalyzeBoolResult(string json)
        {
            return (bool) JObject.Parse(json)["result"];
        }
        protected JObject AnalyzeObjectResult(string json)
        {
            return JObject.Parse(JObject.Parse(json)["result"].ToString());
        }
        protected JArray AnalyzeArrayResult(string json)
        {
            return JArray.Parse(JObject.Parse(json)["result"].ToString());
        }
    }
}