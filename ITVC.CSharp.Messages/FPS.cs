using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITVC.CSharp.Messages
{
    public class FPS:MessageBase
    {
        public string Value { get; set; }

        public FPS()
        {
            MsgType = MessageType.FPS;
        }

        public static FPS CreateFromXML(string XmlText)
        {
            return (FPS)MessageBase.GetMessageFromText(XmlText);
        }
        public override string ToXML()
        {
            StringBuilder xml = new StringBuilder();
            xml.Append(MessageConstants.FPS_OPEN);
            xml.Append(Value);
            xml.Append(MessageConstants.FPS_CLOSE);
            xml.Append("\n");
            return xml.ToString();
        }
    }
}
