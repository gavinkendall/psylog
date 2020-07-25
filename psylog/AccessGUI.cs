//-----------------------------------------------------------------------
// Psylog
// A simple keylogger for Windows.
// Copyright (C) 2020 Gavin Kendall
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program. If not, see <https://www.gnu.org/licenses/>.
//-----------------------------------------------------------------------
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace psylog
{
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