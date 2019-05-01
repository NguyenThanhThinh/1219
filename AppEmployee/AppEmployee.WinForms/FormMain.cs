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

        AppEmployeeDbContext db = new AppEmployeeDbContext();
        int position;
        bool edit = true;

        private void FormMain_Load(object sender, EventArgs e)
        {
            DisplayEmployee();

            DisplayDepartment();
        }

        private void DisplayEmployee()
        {

            var employees = db.Employees.Select(n => new
            {
                n.FirstName,
                n.LastName,
                n.Sex,
                n.BirthDay,
                n.Phone,
                n.Address
            }).ToList();

            dgvEmployee.DataSource = employees;
        }

        private void DisplayDepartment()
        {
            var departments = db.Departments.Select(n => new
            {
                n.Id,
                n.Name
            });

            cboDepartment.DataSource = departments.ToList();

            cboDepartment.DisplayMember = "Name";

            cboDepartment.ValueMember = "Id";
        }
    }
}
