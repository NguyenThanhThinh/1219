using AppEmployee.Data;
using AppEmployee.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppEmployee.WinForms
{
    public partial class frmEmployee : Form
    {
        public frmEmployee()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            DisplayEmployee();
        }

        private void DisplayEmployee()
        {
            AppEmployeeDbContext db = new AppEmployeeDbContext();

            var employees = db.Employees.Select(n => new Employee
            {
                Id = n.Id,
                FirstName = n.FirstName,
                LastName = n.LastName,
                Sex = n.Sex,
                BirthDay = n.BirthDay

            });

            dgvEmployee.DataSource = employees;
        }
    }
}
