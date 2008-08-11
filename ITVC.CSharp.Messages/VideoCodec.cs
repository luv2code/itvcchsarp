using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITVC.CSharp.Messages
{
    public class VideoCodec:MessageBase
    {
        public string Value { get; set; }

        public VideoCodec()
        {
            MsgType = MessageType.VideoCodec;
        }

        public static VideoCodec CreateFromXML(string XmlText)
        {
            return (VideoCodec)MessageBase.GetMessageFromText(XmlText);
        }

        public override string ToXML()
        {
            StringBuilder xml = new StringBuilder();
            xml.Append(MessageConstants.VIDEO_CODEC_OPEN);
            xml.Append(Value);
            xml.Append(MessageConstants.VIDEO_CODEC_CLOSE);
            xml.Append("\n");
            return xml.ToString();
        }
    }
}
