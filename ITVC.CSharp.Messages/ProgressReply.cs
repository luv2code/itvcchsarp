using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITVC.CSharp.Messages
{
    public class ProgressReply : MessageBase
    {
        public const string REPLY_ABORT = "abort";
        public const string REPLY_PROCEED = "proceed";

        public string Value { get; set; }

        public ProgressReply()
        {
            MsgType = MessageType.ProgressReply;
        }

        public static ProgressReply CreateFromXML(string XmlText)
        {
            return (ProgressReply)MessageBase.GetMessageFromText(XmlText);
        }
        public override string ToXML()
        {
            StringBuilder xml = new StringBuilder();
            xml.Append(MessageConstants.PROGRESS_REPLY_OPEN);
            xml.Append(Value);
            xml.Append(MessageConstants.PROGRESS_REPLY_CLOSE);
            xml.Append("\n");
            return xml.ToString();
        }
    }
}
