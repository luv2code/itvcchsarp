using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using System.Timers;
using ITVC.CSharp.Client;
using ITVC.CSharp.Messages;
using System.Threading;

namespace PodcastConverter
{
    public class ConversionEngine: IDisposable
    {
        public string PathToWatch { get; set; }
        public string PathConvertedFiles { get; set; }
        public bool DeleteOriginals { get; set; }
        public bool Converting { get; private set; }
        public float Progress { get; private set; }

        public event EventHandler<ProgressReceivedEventArgs> ProgressReceived;

        public event EventHandler<EventArgs> ConvertComplete;

        private Queue<string> _filePathsToConvert = new Queue<string>();
        private FileSystemWatcher _watcher = new FileSystemWatcher();
        private System.Timers.Timer _timer;
        private MediaHandlerClient _mhclient;

        public ConversionEngine(string PathToWatch, string PathConvertedFiles, bool DeleteOriginals)
        {
            this.Converting = false;
            this.PathToWatch = PathToWatch;
            this.PathConvertedFiles = PathConvertedFiles;
            this.DeleteOriginals = DeleteOriginals;

            int mhPort = int.Parse(ConfigurationManager.AppSettings["MediaHandlerPort"]);
            string mhPath = ConfigurationManager.AppSettings["MediaHandlerPath"];

            _mhclient = new MediaHandlerClient(mhPort, mhPath);
            _mhclient.ProgressReceived += new EventHandler<ProgressReceivedEventArgs>(_mhclient_ProgressReceived);
            _mhclient.Connect();

            _timer = new System.Timers.Timer(10000);
            _timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);
            _timer.Start();

            _watcher.Path = PathToWatch;
            _watcher.IncludeSubdirectories = true;
            _watcher.EnableRaisingEvents = true;
            _watcher.Created += new FileSystemEventHandler(_watcher_Created);
        }

        void _mhclient_ProgressReceived(object sender, ProgressReceivedEventArgs e)
        {
            Progress = e.Percent;
            _mhclient.ProgressReply(new ProgressReply() { Value = ProgressReply.REPLY_PROCEED });
            if (this.ProgressReceived != null)
                ProgressReceived(this, e);
        }

        void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (!Converting && _filePathsToConvert.Count > 0)
            {
                Converting = true;
                //start converting and dequeue item.
                string path = _filePathsToConvert.Dequeue();

                Transcode transcodeRequest = new Transcode();
                transcodeRequest.AudioBitRate = "128000";
                transcodeRequest.FPS = "24";
                transcodeRequest.Height = "240";
                transcodeRequest.InputPath = path;
                transcodeRequest.OutputPath = Path.Combine(PathConvertedFiles, Path.GetFileNameWithoutExtension(path) + "_converted.mp4");
                transcodeRequest.VideoBitRate = "640000";
                transcodeRequest.VideoCodec = Transcode.VIDEO_CODEC_MPEG4;
                transcodeRequest.Width = "400";
                Result res = _mhclient.Transcode(transcodeRequest);
                if (ConvertComplete != null)
                    ConvertComplete(this, new EventArgs());
                string result = res.Value;
                if (DeleteOriginals)
                    File.Delete(path);
                Converting = false;
            }
        }

        void _watcher_Created(object sender, FileSystemEventArgs e)
        {
            string path = Path.Combine(PathToWatch, e.Name);
            if(! _filePathsToConvert.Contains(path))
                _filePathsToConvert.Enqueue(Path.Combine(PathToWatch, e.Name));
        }


        public void Enqueue(string filePath)
        {
            if (!_filePathsToConvert.Contains(filePath))
                _filePathsToConvert.Enqueue(filePath);
        }

        #region IDisposable Members

        public void Dispose()
        {
            _timer.Stop();

            if (Converting)
                _mhclient.ProgressReply(new ProgressReply() { Value = ProgressReply.REPLY_ABORT });

            while (Converting)
                Thread.Sleep(500);
            _mhclient.Close();
        }

        #endregion
    }
}
