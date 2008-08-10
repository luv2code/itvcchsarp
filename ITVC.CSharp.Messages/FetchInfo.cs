using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITVC.CSharp.Messages
{
    public class FetchInfo: MessageBase
    {
        public string FilePath { get; set; }
        public string ThumbnailPath { get; set; }

        public FetchInfo()
        {
            MsgType = MessageType.FetchInfo;
        }

        public static FetchInfo CreateFromXML(string XmlText)
        {
            return (FetchInfo)MessageBase.GetMessageFromText(XmlText);
        }
        public override string ToXML()
        {
            StringBuilder xml = new StringBuilder();
            xml.Append(MessageConstants.FETCH_INFO_OPEN);
            xml.Append(FilePath);
            if (!String.IsNullOrEmpty(ThumbnailPath))
            {
                xml.Append(MessageConstants.PARAMETER_DELIMITER);
                xml.Append(ThumbnailPath);
            }
            xml.Append(MessageConstants.FETCH_INFO_CLOSE);
            xml.Append("\n");
            return xml.ToString();
        }
    }
}
