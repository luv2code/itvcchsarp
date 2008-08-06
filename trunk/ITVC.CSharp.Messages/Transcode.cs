using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITVC.CSharp.Messages
{
    public class Transcode : MessageBase
    {

        public string InputPath { get; set; }
        public string OutputPath { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string VideoCodec { get; set; }
        public string VideoBitRate { get; set; }
        public string AudioBitRate { get; set; }
        public string FPS { get; set; }

        public const string VIDEO_CODEC_MPEG4 = "mpeg4";
        public const string VIDEO_CODEC_H264 = "h.264";
        public const string VIDEO_CODEC_THEORA = "theora";

        public Transcode()
        {
            MsgType = MessageType.Transcode;
        }
        public static Transcode CreateFromXML(string XmlText)
        {
            return (Transcode)MessageBase.GetMessageFromText(XmlText);
        }

        public override string ToXML()
        {
            StringBuilder xml = new StringBuilder();
            xml.Append(MessageConstants.TRANSCODE_OPEN);
            xml.Append(InputPath);
            xml.Append(MessageConstants.PARAMETER_DELIMITER);
            xml.Append(OutputPath);
            xml.Append(MessageConstants.PARAMETER_DELIMITER);
            xml.Append(Width);
            xml.Append(MessageConstants.PARAMETER_DELIMITER);
            xml.Append(Height);
            xml.Append(MessageConstants.PARAMETER_DELIMITER);
            xml.Append(VideoCodec);
            xml.Append(MessageConstants.PARAMETER_DELIMITER);
            xml.Append(VideoBitRate);
            xml.Append(MessageConstants.PARAMETER_DELIMITER);
            xml.Append(AudioBitRate);
            xml.Append(MessageConstants.PARAMETER_DELIMITER);
            xml.Append(FPS);
            xml.Append(MessageConstants.TRANSCODE_CLOSE);
            return xml.ToString();
        }
    }
}
