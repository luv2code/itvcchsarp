using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITVC.CSharp.Messages
{
    public class Height:MessageBase
    {
        public string Value { get; set; }

        public Height()
        {
            MsgType = MessageType.Height;
        }

        public static Height CreateFromXML(string XmlText)
        {
            return (Height)MessageBase.GetMessageFromText(XmlText);
        }

        public override string ToXML()
        {
            StringBuilder xml = new StringBuilder();
            xml.Append(MessageConstants.HEIGHT_OPEN);
            xml.Append(Value);
            xml.Append(MessageConstants.HEIGHT_CLOSE);
            xml.Append("\n");
            return xml.ToString();
        }
    }
}
