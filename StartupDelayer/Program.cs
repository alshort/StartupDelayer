using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace startup_delayer
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
#if DEBUG
            // args = new String[] { "-nogui" };
#endif

            if (ApplicationHelper.IsAlreadyRunning()) return;

            StartupManager manager = new StartupManager();
            manager.Load();

            List<StartupItem> startupItems = new List<StartupItem>(manager.GetItems());

            if (args.Length == 0)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                MainForm frm = new MainForm(manager);
                frm.PopulateListView(startupItems);

                Application.Run(frm);
            }
            else if (args.Length == 1 && args[0].Equals("-startup"))
            {
                int currentOffset = 0;

                foreach (StartupItem item in startupItems)
                {
                    Thread.Sleep((item.Offset - currentOffset) * 1000);

                    ProcessStartInfo processInfo = new ProcessStartInfo();
                    processInfo.FileName = "cmd";
                    processInfo.Arguments = CommandFormat(item.Item, item.WindowState, item.Arguments);
                    processInfo.WindowStyle = ProcessWindowStyle.Hidden;

                    string workingDirectory = item.WorkingDirectory;
                    if (workingDirectory == "" || string.IsNullOrEmpty(workingDirectory))
                    {
                        workingDirectory = Environment.SystemDirectory;
                    }
                    processInfo.WorkingDirectory = workingDirectory;

                    Process.Start(processInfo);

                    currentOffset = item.Offset;
                }
            }
        }

        private static string CommandFormat(
            string item, 
            ProcessWindowStyle state = ProcessWindowStyle.Normal, 
            string arguments = "")
        {
            string baseFormat = "/c start \"\"{0} \"{1}{2}\"";

            string stateStr = "";
            switch (state)
            {
                case ProcessWindowStyle.Minimized:
                    stateStr = " /min";
                    break;
                case ProcessWindowStyle.Maximized:
                    stateStr = " /max";
                    break;
                default:
                    break;
            }

            return string.Format(baseFormat, stateStr, item, arguments);
        }
    }
}
