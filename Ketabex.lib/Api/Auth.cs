using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Ketabex.Shared.Api
{
    public class Auth : BaseApi
    {
        protected const string EXCHANGE_URL = "user/exchange";
        protected const string REQUEST_SMS_URL = "user/getauthcode";
        protected const string CHECK_SMS_URL = "user/chekcauthcode";
        protected const string SIGNUP_URL = "user/signup";


        public void Exchange()
        {
            GlobalUtil.ShowProgress("Exchange");
            Task.Run(async () =>
            {
                var result = await CallUnAuth(SITE_BASE_API + EXCHANGE_URL, new NameValueCollection()
                {
                    {"uid", GlobalUtil.NativeUtil.GetDeviceUid()}
                });
                var token = JObject.Parse(result)["result"]["token"]?.ToString();
                if (token != null)
                {
                    GlobalUtil.Values["isSignedUp"] =
                        Convert.ToBoolean(JObject.Parse(result)["result"]["isSignedUp"]?.ToString());
                    //Save api Token
                    GlobalUtil.NativeUtil.SaveInLocal("apiToken", token);
                }

                //Post Broadcast
                new MessageBusPayload(MessageBusPayload.BroadcastEnum.Exchange)
                    {
                        Succeeded = token != null
                    }
                    .Post();
            });
        }


        public void RequestSmsCode(string phonenumber)
        {
            GlobalUtil.ShowProgress("RequestSmsCode");

            GlobalUtil.NativeUtil.SaveInLocal("phonenumber", phonenumber);
            Task.Run(async () =>
            {
                var result = await Call(SITE_BASE_API + REQUEST_SMS_URL, new NameValueCollection()
                {
                    {"phoneNumber", phonenumber}
                });
                var parsed = JObject.Parse(result);
                if (parsed["preferedMessage"].ToString().Length > 0)
                    GlobalUtil.NativeUtil.ShowMessage(parsed["preferedMessage"].ToString());

                new MessageBusPayload(MessageBusPayload.BroadcastEnum.RequestSmsCode, (bool) parsed["result"])
                    .Post();
            });
        }

        public void CheckSmsCode(string code)
        {
            GlobalUtil.ShowProgress("GetSmsCodeRsult");

            Task.Run(async () =>
            {
                var result = await Call(SITE_BASE_API + CHECK_SMS_URL, new NameValueCollection()
                {
                    {"phoneNumber", GlobalUtil.NativeUtil.LoadFromLocal("phonenumber")},
                    {"code",code }
                });
                var parsed = JObject.Parse(result);
                if (parsed["preferedMessage"].ToString().Length > 0)
                    GlobalUtil.NativeUtil.ShowMessage(parsed["preferedMessage"].ToString());

                new MessageBusPayload(MessageBusPayload.BroadcastEnum.GetSmsCodeRsult, (bool) parsed["result"])
                    .Post();
            });
        }

        public void Signup(string username,string nickname)
        {
            GlobalUtil.ShowProgress("UserSignUp");

            Task.Run(async () =>
            {
                var result = await Call(SITE_BASE_API + SIGNUP_URL, new NameValueCollection()
                {
                    {"username", username},
                    {"nickname",nickname }
                });
                var parsed = JObject.Parse(result);
                if (parsed["preferedMessage"].ToString().Length > 0)
                    GlobalUtil.NativeUtil.ShowMessage(parsed["preferedMessage"].ToString());

                new MessageBusPayload(MessageBusPayload.BroadcastEnum.UserSignUp, (bool)parsed["result"])
                    .Post();
            });
        }
    }
}