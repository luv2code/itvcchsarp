﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITVC.CSharp.Client
{
    public class FetchInfoDetails
    {
        public string VideoCodec { get; set; }
        public string AudioCodec { get; set; }
        public int FPS { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Length { get; set; }
        public int FileSize { get; set; }
        public int VideoBitRate { get; set; }

    }
}
