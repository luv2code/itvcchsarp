using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PodcastConverter
{
    [Serializable]
    public class FeedStore
    {
        public List<Feed> Feeds { get; set; }
    }

    [Serializable]
    public class Feed
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
