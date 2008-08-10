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
            int port = int.Parse(ConfigurationManager.AppSettings["MediaHandlerPort"]);
            string path = ConfigurationManager.AppSettings["MediaHandlerPath"];
            
            using (_client = new MediaHandlerClient(port, path))
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
                textBox1.Text = String.Join(" ", info);
            }
        }
    }
}
