using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ITVC.CSharp.Client;
using ITVC.CSharp.Messages;

namespace PodcastConverter
{
    public partial class Form1 : Form
    {
        private MediaHandlerClient _client = null;

        public Form1()
        {
            InitializeComponent();

            btnFeedSave.Enabled = false;

            int port = int.Parse(ConfigurationManager.AppSettings["MediaHandlerPort"]);
            string path = ConfigurationManager.AppSettings["MediaHandlerPath"];
            
            using (_client = new MediaHandlerClient(port, path));//, System.Diagnostics.ProcessPriorityClass.High))
            {
                _client.Connect();
                FetchInfo fi = new FetchInfo();
                fi.FilePath = @"C:\Documents and Settings\Matt\My Documents\Projects\pickle.mp4";
                fi.ThumbnailPath = @"C:\Documents and Settings\Matt\My Documents\Projects\pickle.jpg";
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
                transcodeRequest.OutputPath = @"C:\Documents and Settings\Matt\My Documents\Projects\pickle n8x0.mp4";
                transcodeRequest.VideoBitRate = "350000";
                transcodeRequest.VideoCodec = Transcode.VIDEO_CODEC_MPEG4;
                transcodeRequest.Width = "400";
                _client.ProgressReceived += new EventHandler<ProgressReceivedEventArgs>(ProgressReceived);
                _client.Transcode(transcodeRequest);
                _client.Quit();
            }
        }

        public void ProgressReceived(object sender, ProgressReceivedEventArgs args)
        {
            ProgressReply pr = new ProgressReply();
            pr.Value = ProgressReply.REPLY_PROCEED;
            _client.ProgressReply(pr);
        }

        private void lstFeeds_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnFeedSave.Enabled = true;
        }
    }
}
