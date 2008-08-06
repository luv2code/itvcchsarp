using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITVC.CSharp.Messages
{
    public class Width:MessageBase
    {
        public string Value { get; set; }

        public Width()
        {
            MsgType = MessageType.Width;
        }

        public static Width CreateFromXML(string XmlText)
        {
            return (Width)MessageBase.GetMessageFromText(XmlText);
        }

        public override string ToXML()
        {
            StringBuilder xml = new StringBuilder();
            xml.Append(MessageConstants.WIDTH_OPEN);
            xml.Append(Value);
            xml.Append(MessageConstants.WIDTH_CLOSE);
            return xml.ToString();
        }
    }
}
