﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITVC.CSharp.Client
{
    public class ProgressReceivedEventArgs:EventArgs
    {
        public float Percent { get; private set; }

        public ProgressReceivedEventArgs(String number)
        {
            int num = int.Parse(number);
            Percent = num / 100;
        }
    }
}
