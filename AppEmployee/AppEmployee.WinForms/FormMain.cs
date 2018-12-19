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

        private void FormMain_Load(object sender, EventArgs e)
        {
            DisplayEmployee();
        }

        private void DisplayEmployee()
        {

            var employees = db.Employees.Select(n => new
            {
                n.Id,
                n.FirstName,
                n.LastName,
                n.Sex,
                n.BirthDay

            }).ToList();

            dgvEmployee.DataSource = employees;
        }
    }
}
