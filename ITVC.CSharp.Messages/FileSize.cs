using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITVC.CSharp.Messages
{
    public class FileSize : MessageBase
    {
        public string Value { get; set; }

        public FileSize()
        {
            MsgType = MessageType.FileSize;
        }

        public static FileSize CreateFromXML(string XmlText)
        {
            return (FileSize)MessageBase.GetMessageFromText(XmlText);
        }
        public override string ToXML()
        {
            StringBuilder xml = new StringBuilder();
            xml.Append(MessageConstants.FILE_SIZE_OPEN);
            xml.Append(Value);
            xml.Append(MessageConstants.FILE_SIZE_CLOSE);
            return xml.ToString();
        }
    }
}
