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
    public partial class AddEditProject : Form
    {
        public String project_name { get; set; }

        public long project_id { get; set; }

        public bool edit { get; set; }
    public AddEditProject()
        {
            InitializeComponent();
            this.edit = false;
        }

        private void AddEditProject_Load(object sender, EventArgs e)
        {
            if (edit)
            {
                tbProject.Text = project_name;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!edit)
            {
                ProjectBD project = new ProjectBD();
                project.project_name = tbProject.Text;
                project.Add();
            }
            else
            {
                ProjectBD project = new ProjectBD();
                project.Load(project_id);
                project.project_name = tbProject.Text;
                project.Update();
            }
            this.Close();
        }
    }
}
