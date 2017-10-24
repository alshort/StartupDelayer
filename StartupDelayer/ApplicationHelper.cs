using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace startup_delayer
{
    public static class ApplicationHelper
    {
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        private static extern bool IsIconic(IntPtr hWnd);


        private const int SW_HIDE = 0;
        private const int SW_SHOWNORMAL = 1;
        private const int SW_SHOWMINIMIZED = 2;
        private const int SW_SHOWMAXIMIZED = 3;
        private const int SW_SHOWNOACTIVATE = 4;
        private const int SW_RESTORE = 9;
        private const int SW_SHOWDEFAULT = 10;

        /// <summary>
        /// Check if current process already running. if running, set focus to existing process and returns <see langword="true"/> otherwise returns <see langword="false"/>.
        /// </summary>
        /// <returns><see langword="true"/> if it succeeds, <see langword="false"/> if it fails.</returns>
        public static bool IsAlreadyRunning()
        {
            Process me = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(me.ProcessName);

            if (processes.Length <= 1) return false;
           
            for (var i = 0; i < processes.Length; i++)
            {
                if (processes[i].Id == me.Id) continue;
                
                // Get the window handle
                IntPtr hWnd = processes[i].MainWindowHandle;

                // If iconic, we need to restore the window
                if (IsIconic(hWnd))
                {
                    ShowWindowAsync(hWnd, SW_RESTORE);
                }

                // Bring it to the foreground
                SetForegroundWindow(hWnd);
                break;                
            }

            return true;
        }
    }
}
