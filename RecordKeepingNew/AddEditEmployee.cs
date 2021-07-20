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
    public partial class AddEditEmployee : Form
    {
        public String employee_name { get; set; }

        public long employee_id { get; set; }

        public bool edit { get; set; }
        public AddEditEmployee()
        {
            InitializeComponent();
            this.edit = false;
        }


        private void AddEditEmployee_Load(object sender, EventArgs e)
        {
            if (edit)
            {
                tbEmployee.Text = employee_name;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!edit)
            {
                EmployeeBD employee = new EmployeeBD();
                employee.employee_name = tbEmployee.Text;
                employee.Add();
            }
            else
            {
                EmployeeBD employee = new EmployeeBD();
                employee.employee_name = tbEmployee.Text;
                employee.Load(employee_id);
                employee.employee_name = tbEmployee.Text;
                employee.Update();
            }
            this.Close();
        }

        public static implicit operator AddEditEmployee(AddEditProject v)
        {
            throw new NotImplementedException();
        }
    }
}
