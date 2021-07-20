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
    public partial class EmployeeManager : Form
    {
        public EmployeeManager()
        {
            InitializeComponent();
        }

        private void EmployeeManager_Load(object sender, EventArgs e)
        {
            ReloadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddEditEmployee employee = new AddEditEmployee();
            employee.edit = false;
            employee.ShowDialog();
            ReloadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            AddEditEmployee employee = new AddEditEmployee();
            employee.edit = true;
            employee.employee_id = (long)dgvEmployee.CurrentRow.Cells[0].Value;
            employee.employee_name = (String)dgvEmployee.CurrentRow.Cells[1].Value;
            employee.ShowDialog();
            ReloadData();
        }

        private void ReloadData()
        {
            DataTable dEmployee = new DataTable();

            String sqlQuery;

            try
            {
                sqlQuery = "SELECT * FROM Employee";
                SQLiteDataAdapter adapterEmployee = new SQLiteDataAdapter(sqlQuery, Settings.Conncetion);
                adapterEmployee.Fill(dEmployee);

                dgvEmployee.DataSource = dEmployee.DefaultView;
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            EmployeeBD employee = new EmployeeBD();
            employee.Load((long)dgvEmployee.CurrentRow.Cells[0].Value);
            DialogResult result = MessageBox.Show("Вы уверенны что хотите удалить сотрудника " + employee.employee_name + "?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                employee.Delete();
            }
            this.ReloadData();
        }
    }
}
