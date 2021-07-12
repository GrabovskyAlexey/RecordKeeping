using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
