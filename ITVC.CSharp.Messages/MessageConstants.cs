using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITVC.CSharp.Messages
{
    internal class MessageConstants
    {
        public const string FETCH_INFO_OPEN = "<fetch-info>";
        public const string FETCH_INFO_CLOSE = "</fetch-info>";
        public const string TRANSCODE_OPEN = "<transcode>";
        public const string TRANSCODE_CLOSE = "</transcode>";
        public const string VIDEO_CODEC_OPEN = "<video-codec>";
        public const string VIDEO_CODEC_CLOSE = "</video-codec>";
        public const string AUDIO_CODEC_OPEN = "<audio-codec>";
        public const string AUDIO_CODEC_CLOSE = "</audio-codec>";
        public const string FPS_OPEN = "<fps>";
        public const string FPS_CLOSE = "</fps>";
        public const string WIDTH_OPEN = "<width>";
        public const string WIDTH_CLOSE = "</width>";
        public const string HEIGHT_OPEN = "<height>";
        public const string HEIGHT_CLOSE = "</height>";
        public const string LENGTH_OPEN = "<length>";
        public const string LENGTH_CLOSE = "</length>";
        public const string FILE_SIZE_OPEN = "<file-size>";
        public const string FILE_SIZE_CLOSE = "</file-size>";
        public const string VIDEO_BIT_RATE_OPEN = "<video-bit-rate>";
        public const string VIDEO_BIT_RATE_CLOSE = "</video-bit-rate>";
        public const string PROGRESS_OPEN = "<progress>";
        public const string PROGRESS_CLOSE = "</progress>";
        public const string PROGRESS_REPLY_OPEN = "<progress-reply>";
        public const string PROGRESS_REPLY_CLOSE = "</progress-reply>";
        public const string RESULT_OPEN = "<result>";
        public const string RESULT_CLOSE = "</result>";
        public const string QUIT_OPEN = "<quit>";
        public const string QUIT_CLOSE = "</quit>";
        public const char PARAMETER_DELIMITER = '|';
    }
}
