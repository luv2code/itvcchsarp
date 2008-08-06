using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITVC.CSharp.Messages
{
    public abstract class MessageBase
    {
        public MessageType MsgType { get; set; }

        public static MessageBase GetMessageFromText(string input)
        {
            Parsed p = Parser.GetTypeAndParameters(input);
            MessageBase retObj = null;

            switch (p.Type)
            {
                case MessageType.FetchInfo:
                    FetchInfo fi = new FetchInfo();
                    fi.FilePath = p.Parameters[0];
                    if(p.Parameters.Count > 1)//thumbnail is optional.
                        fi.ThumbnailPath = p.Parameters[1];
                    retObj = fi;
                    break;
                case MessageType.VideoCodec:
                    VideoCodec vc = new VideoCodec();
                    vc.Value = p.Parameters[0];
                    retObj = vc;
                    break;
                case MessageType.AudioCodec:
                    AudioCodec ac = new AudioCodec();
                    ac.Value = p.Parameters[0];
                    retObj = ac;
                    break;
                case MessageType.FPS:
                    FPS f = new FPS();
                    f.Value = p.Parameters[0];
                    retObj = f;
                    break;
                case MessageType.Width:
                    Width w = new Width();
                    w.Value = p.Parameters[0];
                    retObj = w;
                    break;
                case MessageType.Height:
                    Height h = new Height();
                    h.Value = p.Parameters[0];
                    retObj = h;
                    break;
                case MessageType.Length:
                    Length l = new Length();
                    l.Value = p.Parameters[0];
                    retObj = l;
                    break;
                case MessageType.FileSize:
                    FileSize fs = new FileSize();
                    fs.Value = p.Parameters[0];
                    retObj = fs;
                    break;
                case MessageType.VideoBitRate:
                    VideoBitRate vbr = new VideoBitRate();
                    vbr.Value = p.Parameters[0];
                    retObj = vbr;
                    break;
                case MessageType.Result:
                    Result r = new Result();
                    r.Value = p.Parameters[0];
                    retObj = r;
                    break;
                case MessageType.Transcode:
                    Transcode t = new Transcode();
                    t.InputPath = p.Parameters[0];
                    t.OutputPath = p.Parameters[1];
                    t.Width = p.Parameters[2];
                    t.Height = p.Parameters[3];
                    t.VideoCodec = p.Parameters[4];
                    t.VideoBitRate = p.Parameters[5];
                    t.AudioBitRate = p.Parameters[6];
                    t.FPS = p.Parameters[7];
                    retObj = t;
                    break;
                case MessageType.Progress:
                    Progress prog = new Progress();
                    prog.Number = p.Parameters[0];
                    retObj = prog;
                    break;
                case MessageType.ProgressReply:
                    ProgressReply pr = new ProgressReply();
                    pr.Value = p.Parameters[0];
                    retObj = pr;
                    break;
                case MessageType.Quit:
                    Quit q = new Quit();
                    retObj = q;
                    break;
            }

            return retObj;
        }
        public abstract string ToXML();
    }
}
