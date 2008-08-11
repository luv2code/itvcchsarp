using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITVC.CSharp.Messages
{
    public class VideoBitRate : MessageBase
    {
        public string Value { get; set; }

        public VideoBitRate()
        {
            MsgType = MessageType.VideoBitRate;
        }
        public static VideoBitRate CreateFromXML(string XmlText)
        {
            return (VideoBitRate)MessageBase.GetMessageFromText(XmlText);
        }

        public override string ToXML()
        {
            StringBuilder xml = new StringBuilder();
            xml.Append(MessageConstants.VIDEO_BIT_RATE_OPEN);
            xml.Append(Value);
            xml.Append(MessageConstants.VIDEO_BIT_RATE_CLOSE);
            xml.Append("\n");
            return xml.ToString();
        }
    }
}
