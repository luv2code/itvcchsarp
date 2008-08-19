using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using ITVC.CSharp.Client;
using ITVC.CSharp.Messages;

namespace ITVC.CSharp.Client
{
    public class cmdlinetest
    {

        private static MediaHandlerClient _client = null;

        static void Main(string[] args)
        {

            int port = int.Parse(ConfigurationManager.AppSettings["MediaHandlerPort"]);
            string path = ConfigurationManager.AppSettings["MediaHandlerPath"];

            using (_client = new MediaHandlerClient(port, path))//, System.Diagnostics.ProcessPriorityClass.High))
            {
                _client.Connect();
                FetchInfo fi = new FetchInfo();
                fi.FilePath = @"F:\Downloaded From RSS\gbtv-119700-07-23-2008.mp4";
                fi.ThumbnailPath = @"F:\Downloaded From RSS\gbtv-119700-07-23-2008.jpg";
                FetchInfoDetails fid = _client.FetchInfo(fi);
                String[] info = new string[] {  fid.AudioCodec, 
                                                fid.FileSize.ToString(), 
                                                fid.FPS.ToString(), 
                                                fid.Height.ToString(), 
                                                fid.Length.ToString(), 
                                                fid.VideoBitRate.ToString(), 
                                                fid.VideoCodec, 
                                                fid.Width.ToString() };
                Transcode transcodeRequest = new Transcode();
                transcodeRequest.AudioBitRate = "128000";
                transcodeRequest.FPS = "24";
                transcodeRequest.Height = "240";
                transcodeRequest.InputPath = fi.FilePath;
                transcodeRequest.OutputPath = @"F:\Converted Files\gbtv-119700-07-23-2008 n8x0.mp4";
                transcodeRequest.VideoBitRate = "700000";
                transcodeRequest.VideoCodec = Transcode.VIDEO_CODEC_MPEG4;
                transcodeRequest.Width = "400";
                _client.ProgressReceived += new EventHandler<ProgressReceivedEventArgs>(ProgressReceived);
                _client.Transcode(transcodeRequest);
                _client.Quit();
            }
        }

        public static void ProgressReceived(object sender, ProgressReceivedEventArgs args)
        {
            ProgressReply pr = new ProgressReply();
            pr.Value = ProgressReply.REPLY_PROCEED;
            _client.ProgressReply(pr);
            Console.WriteLine(args.Percent);
        }
    }
}
