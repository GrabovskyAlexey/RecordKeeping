using System;
using System.Windows.Forms;

namespace RecordKeeping
{
    public partial class frmSearch : Form
    {
        public string SearchText;
        public frmSearch()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchText = tbSearch.Text;
        }
    }
}
