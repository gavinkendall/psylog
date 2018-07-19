namespace psylog
{
    using System;
    using System.Windows.Forms;

    static class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Application.Run(new frmPsylog(args));
        }
    }
}
