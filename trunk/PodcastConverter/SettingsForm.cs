using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Timers;
using System.Windows.Forms;
using ITVC.CSharp.Client;
using ITVC.CSharp.Messages;
using System.Net;

namespace PodcastConverter
{
    public partial class SettingsForm : Form
    {

        const string ICON_TEXT_IDLE = "Podcast Converter - Idle";
        const string ICON_TEXT_DOWNLOADING = "Podcast Converter - Downloading";
        const string ICON_TEXT_CONVERTING = "Podcast Converter - Converting";

        private ConverterSettings _store;
        private string _settingsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "FeedSettings.xml");
        private ConversionEngine _conversionEngine;
        private System.Timers.Timer _timer;

        private List<string> _fileHistory;
        private string _fileHistoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "FeedHistory.xml");

        public SettingsForm()
        {
            InitializeComponent();
            btnFeedDelete.Enabled = false;
            btnFeedSave.Enabled = false;
            this.ControlBox = false;
            mnuShowSettingsForm.Enabled = false;

            SysTrayIcon.Text = ICON_TEXT_IDLE;

            lstFeeds.DisplayMember = "Name";

            if (File.Exists(_settingsPath))
            {
                _store = (ConverterSettings) LoadObject<ConverterSettings>(_settingsPath);
            }
            else
            {
                //create file.
                _store = new ConverterSettings();
                _store.Feeds = new List<FeedStore>();
                SaveObject<ConverterSettings>(_store, _settingsPath);
            }


            if (File.Exists(_fileHistoryPath))
            {
                _fileHistory = (List<string>)LoadObject<List<string>>(_fileHistoryPath);
            }
            else
            {
                _fileHistory = new List<string>();
                SaveObject<List<string>>(_fileHistory, _fileHistoryPath);
            }

            PopulateForm();

            _timer = new System.Timers.Timer(1000); //1800000);//30 minutes

            _timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);
        }

        void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            foreach (object o in _store.Feeds)
            {
                FeedStore fs = (FeedStore)o;
                XElement feed = XElement.Load(fs.Url);

                var query = from f in feed.Element("channel").Elements("item").Take(fs.NumberOfEntries)
                            select new { Url = f.Element("enclosure").Attribute("url").Value };
                foreach (var url in query)
                {
                    if (!_fileHistory.Contains(url.Url))
                    {
                        _fileHistory.Add(url.Url);
                        WebClient wc = new WebClient();
                        wc.DownloadFileCompleted += new AsyncCompletedEventHandler(wc_DownloadFileCompleted);
                        wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(wc_DownloadProgressChanged);
                        string filePath = Path.Combine(_store.DownloadFolder, Path.GetFileName(url.Url));
                        filePath = filePath.Replace(".m4v", ".mp4");
                        wc.DownloadFileAsync(new Uri(url.Url), filePath, filePath);
                    }
                }
            }
        }

        void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            SysTrayIcon.Text = ICON_TEXT_DOWNLOADING + " " + e.ProgressPercentage.ToString() + "%";
        }

        void wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            SysTrayIcon.Text = ICON_TEXT_IDLE;
            _conversionEngine.Enqueue((string)e.UserState);
        }

        private void PopulateForm()
        {

            txtConvertFolder.Text = _store.ConvertedFolder;
            txtDownloadFolder.Text = _store.DownloadFolder;
            chkDeleteOriginals.Checked = _store.DeleteOriginals;

            lstFeeds.Items.Clear();
            foreach (FeedStore fs in _store.Feeds)
            {
                lstFeeds.Items.Add(fs);
            }

        }

        private void lstFeeds_SelectedIndexChanged(object sender, EventArgs e)
        {
            FeedStore fs = (FeedStore)lstFeeds.SelectedItem;
            if (fs != null)
            {
                txtFeedUrl.Text = fs.Url; ;
                cboNumberItems.Text = fs.NumberOfEntries.ToString();
                btnFeedSave.Enabled = true;
                btnFeedDelete.Enabled = true;
            }
        }

        private void mnuShowSettingsForm_Click(object sender, EventArgs e)
        {
            _timer.Stop();
            this.Show();
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            _timer.Stop();
            _conversionEngine.Dispose();
            SaveObject<List<String>>(_fileHistory, _fileHistoryPath);
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            if (_conversionEngine != null)
                _conversionEngine.Dispose();

            PutValuesInStore();

            SaveObject<ConverterSettings>(_store, _settingsPath);

            this.Hide();
            mnuShowSettingsForm.Enabled = true;

            _timer.Start();
            string watchFolder = Path.Combine(_store.DownloadFolder, @"watch\");
            if (!Directory.Exists(watchFolder))
                Directory.CreateDirectory(watchFolder);
            _conversionEngine = new ConversionEngine(watchFolder, _store.ConvertedFolder, _store.DeleteOriginals);
            _conversionEngine.ProgressReceived += new EventHandler<ProgressReceivedEventArgs>(_conversionEngine_ProgressReceived);
            _conversionEngine.ConvertComplete += new EventHandler<EventArgs>(_conversionEngine_ConvertComplete);
        }

        void _conversionEngine_ConvertComplete(object sender, EventArgs e)
        {
            SysTrayIcon.Text = ICON_TEXT_IDLE;
        }

        void _conversionEngine_ProgressReceived(object sender, ProgressReceivedEventArgs e)
        {
            SysTrayIcon.Text = ICON_TEXT_CONVERTING + " " + e.Percent.ToString() + "%";
        }

        private void PutValuesInStore()
        {
            _store.ConvertedFolder = txtConvertFolder.Text;
            _store.DownloadFolder = txtDownloadFolder.Text;
            _store.DeleteOriginals = chkDeleteOriginals.Checked;
            List<FeedStore> feeds = new List<FeedStore>();
            foreach (object o in lstFeeds.Items)
            {
                FeedStore fs = (FeedStore)o;
                feeds.Add(fs);
            }
            _store.Feeds = feeds;
        }

        private void btnAddFeed_Click(object sender, EventArgs e)
        {
            FeedStore fs = new FeedStore();
            fs.Url = txtFeedUrl.Text;
            int number;
            int.TryParse(cboNumberItems.Text, out number);
            fs.NumberOfEntries = number;

            XElement feeds = XElement.Load(fs.Url);
            if (feeds.Element("channel") != null && feeds.Element("channel").Element("title") != null)
                fs.Name = feeds.Element("channel").Element("title").Value;

            lstFeeds.Items.Add(fs);
            ClearFeedForm();
        }

        private void ClearFeedForm()
        {
            txtFeedUrl.Text = string.Empty;
            cboNumberItems.Text = string.Empty;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            //retrieve settings from disk and reload form.
            this.Hide();

        }

        private void btnFeedSave_Click(object sender, EventArgs e)
        {
            FeedStore fs = (FeedStore)lstFeeds.SelectedItem;
            fs.Url = txtFeedUrl.Text;
            int number;
            int.TryParse(cboNumberItems.Text, out number);
            fs.NumberOfEntries = number;

            XElement feeds = XElement.Load(fs.Url);
            if (feeds.Element("channel") != null && feeds.Element("channel").Element("title") != null)
                fs.Name = feeds.Element("channel").Element("title").Value;
            btnFeedDelete.Enabled = false;
            btnFeedSave.Enabled = false;
            ClearFeedForm();
        }

        private void btnFeedDelete_Click(object sender, EventArgs e)
        {
            lstFeeds.Items.Remove(lstFeeds.SelectedItem);
            btnFeedDelete.Enabled = false;
            btnFeedSave.Enabled = false;
            ClearFeedForm();
        }

        private void SaveObject<t>(t obj, string path)
        {
            StreamWriter sr = new StreamWriter(path);
            XmlSerializer xsr = new XmlSerializer(typeof(t));
            xsr.Serialize(sr, obj);
            sr.Close();
        }

        private object LoadObject<t>(string path)
        {
            object ret;
            StreamReader sr = new StreamReader(path);
            XmlSerializer xsr = new XmlSerializer(typeof(t));
            ret = xsr.Deserialize(sr);
            sr.Close();
            return ret;
        }
    }
}
