using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PodcastConverter
{
    [Serializable]
    public class FeedStore
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public int NumberOfEntries { get; set; }
    }

}
