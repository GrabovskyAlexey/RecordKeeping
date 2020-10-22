using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecordKeeping
{
    public partial class ProjectManager : Form
    {
        public ProjectManager()
        {
            InitializeComponent();
        }

        private void ProjectManager_Load(object sender, EventArgs e)
        {

            ReloadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddEditProject project = new AddEditProject();
            project.edit = false;
            project.ShowDialog();
            ReloadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            AddEditProject project = new AddEditProject();
            project.edit = true;
            project.project_id = (long)dgvProject.CurrentRow.Cells[0].Value;
            project.project_name = (String)dgvProject.CurrentRow.Cells[1].Value;
            project.ShowDialog();
            ReloadData();
        }

        private void ReloadData()
        {
            DataTable dProjects = new DataTable();

            String sqlQuery;

            try
            {
                sqlQuery = "SELECT * FROM projects";
                SQLiteDataAdapter adapterProjects = new SQLiteDataAdapter(sqlQuery, Settings.Conncetion);
                adapterProjects.Fill(dProjects);

                dgvProject.DataSource = dProjects.DefaultView;
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ProjectBD project = new ProjectBD();
            project.Load((long)dgvProject.CurrentRow.Cells[0].Value);
            DialogResult result = MessageBox.Show("Вы уверенны что хотите удалить проект " + project.project_name + "?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                project.Delete();
            }
            this.ReloadData();
        }
    }
}
