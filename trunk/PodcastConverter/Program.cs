using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PodcastConverter
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SettingsForm settings = new SettingsForm();
            Application.Run(settings);
        }
    }
}
