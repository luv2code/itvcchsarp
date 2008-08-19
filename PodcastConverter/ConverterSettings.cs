using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PodcastConverter
{
    [Serializable]
    public class ConverterSettings
    {
        public string DownloadFolder { get; set; }
        public string ConvertedFolder { get; set; }
        public bool DeleteOriginals { get; set; }
        public List<FeedStore> Feeds { get; set; }
    }
}
