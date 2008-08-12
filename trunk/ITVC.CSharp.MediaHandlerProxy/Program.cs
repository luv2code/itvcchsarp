using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.IO;
using System.Text;
using ITVC.CSharp.Client;
using ITVC.CSharp.Messages;
using ITVC.CSharp.Server;

namespace ITVC.CSharp.MediaHandlerProxy
{
    class Program
    {
        private static MediaHandler server;
        private static MediaHandlerClient client;
        private static StreamWriter sw;

        static void Main(string[] args)
        {
            int port = 0;
            if (args.Length == 0 || !int.TryParse(args[0], out port))
                port = int.Parse(ConfigurationManager.AppSettings["ListenOnPort"]);
            string mhPath = ConfigurationManager.AppSettings["MediaHandlerPath"];
            int mhPort = int.Parse(ConfigurationManager.AppSettings["MediaHandlerPort"]);

            sw = new StreamWriter(ConfigurationManager.AppSettings["LogFilePath"]);
            sw.AutoFlush = true;

            client = new MediaHandlerClient(mhPort, mhPath);//, System.Diagnostics.ProcessPriorityClass.Normal);
            server = new MediaHandler(port);

            client.ProgressReceived += new EventHandler<ProgressReceivedEventArgs>(client_ProgressReceived);

            client.Connect();

            server.FetchInfoReceived += new EventHandler<MediaHandlerEventArgs>(server_FetchInfoReceived);
            server.ProgressReplyReceived += new EventHandler<MediaHandlerEventArgs>(server_ProgressReplyReceived);
            server.QuitReceived += new EventHandler<MediaHandlerEventArgs>(server_QuitReceived);
            server.TranscodeReceived += new EventHandler<MediaHandlerEventArgs>(server_TranscodeReceived);
            sw.WriteLine("starting proxy");
            server.Start();

            client.Close();
            client.Dispose();
            sw.WriteLine("shutting down");
            sw.Close();
            sw.Dispose();
        }

        static void client_ProgressReceived(object sender, ProgressReceivedEventArgs e)
        {
            Progress msg = new Progress();
            msg.Number = (e.Percent * 100).ToString();
            sw.WriteLine(msg.ToXML());
            server.Send(msg);
        }

        static void server_TranscodeReceived(object sender, MediaHandlerEventArgs e)
        {
            sw.WriteLine(e.RawText);
            Transcode msg = (Transcode)e.MessageObject;
            client.Transcode(msg);
        }

        static void server_QuitReceived(object sender, MediaHandlerEventArgs e)
        {
            sw.WriteLine(e.RawText);
            Quit msg = (Quit)e.MessageObject;
            client.Quit();
            Console.WriteLine("Stopping Proxy");
            server.Stop();
        }

        static void server_ProgressReplyReceived(object sender, MediaHandlerEventArgs e)
        {
            sw.WriteLine(e.RawText);
            ProgressReply msg = (ProgressReply)e.MessageObject;
            client.ProgressReply(msg);
        }

        static void server_FetchInfoReceived(object sender, MediaHandlerEventArgs e)
        {
            sw.WriteLine(e.RawText);
            FetchInfo msg = (FetchInfo)e.MessageObject;
            FetchInfoDetails fid = client.FetchInfo(msg);

            FPS fps = new FPS();
            fps.Value = fid.FPS.ToString();
            server.Send(fps);

            AudioCodec ac = new AudioCodec();
            ac.Value = fid.AudioCodec;
            server.Send(ac);

            FileSize fs = new FileSize();
            fs.Value = fid.FileSize.ToString();
            server.Send(fs);

            Height h = new Height();
            h.Value = fid.Height.ToString();
            server.Send(h);

            Length l = new Length();
            l.Value = fid.Length.ToString();
            server.Send(l);

            VideoBitRate vbr = new VideoBitRate();
            vbr.Value = fid.VideoBitRate.ToString();
            server.Send(vbr);

            VideoCodec vc = new VideoCodec();
            vc.Value = fid.VideoCodec;
            server.Send(vc);

            Width w = new Width();
            w.Value = fid.Width.ToString();
            server.Send(w);

            Result res = new Result();
            res.Value = Result.RESULT_OK;
            server.Send(res);
        }
    }
}
