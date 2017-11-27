using System;
using System.Collections.Generic;
using System.Text;

namespace Ketabex.Shared
{
    public static class Extensions
    {
        public static void Post(this MessageBusPayload payload)
        {
            GlobalUtil.NativeUtil.SendBroadcast(payload);
        }
    }
}
