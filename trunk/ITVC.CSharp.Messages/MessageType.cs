using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITVC.CSharp.Messages
{
    public enum MessageType
    {
        FetchInfo,
        VideoCodec,
        AudioCodec,
        FPS,
        Width,
        Height,
        Length,
        FileSize,
        VideoBitRate,
        Result,
        Transcode,
        Progress,
        ProgressReply,
        Quit
    }
}
