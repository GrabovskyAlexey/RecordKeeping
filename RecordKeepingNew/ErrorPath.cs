using System;
using System.Windows.Forms;

namespace RecordKeeping
{
    public partial class ErrorPath : Form
    {
        public string Path { get; set; }
        public ErrorPath()
        {
            InitializeComponent();
        }

        private void ErrorPath_Load(object sender, EventArgs e)
        {
            tbPath.Text = Path;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
