using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITVC.CSharp.Messages
{
    public class AudioCodec:MessageBase
    {
        public string Value { get; set; }

        public AudioCodec()
        {
            MsgType = MessageType.AudioCodec;
        }

        public static AudioCodec CreateFromXML(string XmlText)
        {
            return (AudioCodec)MessageBase.GetMessageFromText(XmlText);
        }
        public override string ToXML()
        {
            StringBuilder xml = new StringBuilder();
            xml.Append(MessageConstants.AUDIO_CODEC_OPEN);
            xml.Append(Value);
            xml.Append(MessageConstants.AUDIO_CODEC_CLOSE);
            xml.Append("\n");
            return xml.ToString();
        }
    }
}
