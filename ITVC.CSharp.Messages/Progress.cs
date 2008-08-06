using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITVC.CSharp.Messages
{
    public class Progress : MessageBase
    {
        public string Number { get; set; }

        public Progress()
        {
            MsgType = MessageType.Progress;
        }

        public static Progress CreateFromXML(string XmlText)
        {
            return (Progress)MessageBase.GetMessageFromText(XmlText);
        }
        public override string ToXML()
        {
            StringBuilder xml = new StringBuilder();
            xml.Append(MessageConstants.PROGRESS_OPEN);
            xml.Append(Number);
            xml.Append(MessageConstants.PROGRESS_CLOSE);
            return xml.ToString();
        }
    }
}
