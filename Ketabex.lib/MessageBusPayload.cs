using System;
using System.Collections.Generic;
using System.Text;
using DSoft.Messaging;

namespace Ketabex.Shared
{
    public class MessageBusPayload : MessageBusEvent
    {
        public override string EventId { get; }
        public object Entities { get; set; }
        public object Entity { get; set; }
        public string StringResult { get; set; }
        public int IntResult { get; set; }
        public int BroadCastIntId { get; set; }
        public BroadcastEnum BroadcastId { get; set; }
        public bool Succeeded { get; set; } = true;
        public Exception Exception { get; set; }
        public enum BroadcastEnum
        {
            Exchange,
            UserIsSignedUp,
            RequestSmsCode,
            GetSmsCodeRsult,
            UserSignUp,
            UpdatePostsMode
        }

        public MessageBusPayload()
        { 
        }
        public MessageBusPayload(BroadcastEnum broadcastId)
        {
            BroadcastId = broadcastId;
        }

        public MessageBusPayload(BroadcastEnum broadcastId, bool succeeded)
        {
            BroadcastId = broadcastId;
            Succeeded = succeeded;
        }
    }
}
