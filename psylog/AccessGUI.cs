namespace psylog
{
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Text;

    public static class AccessGUI
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        public static string GetActiveWindowTitle()
        {
            IntPtr handle;

            StringBuilder buffer = new StringBuilder(48000);

            handle = GetForegroundWindow();

            if (GetWindowText(handle, buffer, 48000) > 0)
            {
                return buffer.ToString();
            }

            return null;
        }
    }
}