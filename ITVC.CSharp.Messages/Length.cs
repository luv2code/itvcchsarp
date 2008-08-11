using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITVC.CSharp.Messages
{
    public class Length : MessageBase
    {
        public string Value { get; set; }

        public Length()
        {
            MsgType = MessageType.Length;
        }

        public static Length CreateFromXML(string XmlText)
        {
            return (Length)MessageBase.GetMessageFromText(XmlText);
        }

        public override string ToXML()
        {
            StringBuilder xml = new StringBuilder();
            xml.Append(MessageConstants.LENGTH_OPEN);
            xml.Append(Value);
            xml.Append(MessageConstants.LENGTH_CLOSE);
            xml.Append("\n");
            return xml.ToString();
        }
    }
}
