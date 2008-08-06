using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ITVC.CSharp.Messages;

namespace ITVC.CSharp.Server
{
    public class MediaHandlerEventArgs: EventArgs
    {
        public MessageType MsgType { get; private set; }
        public String RawText { get; private set; }
        public MessageBase MessageObject { get; private set; }

        public MediaHandlerEventArgs(MessageType type, String rawText, MessageBase messageObject)
        {
            MsgType = type;
            RawText = rawText;
            MessageObject = messageObject;
        }
    }
}
