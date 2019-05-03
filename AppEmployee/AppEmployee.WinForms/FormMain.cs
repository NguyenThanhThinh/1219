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
                n.Address,
                n.Email,
                n.DepartmentId
            }).ToList();

            dgvEmployee.DataSource = employees;

           // DisplayEmployeeDetail();
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

        private void DisplayEmployeeDetail()
        {
            if (dgvEmployee.CurrentRow != null)
            {
                DataGridViewRow row = dgvEmployee.CurrentRow;

                txtFirstName.Text = row.Cells[0].Value.ToString();

                txtLastName.Text = row.Cells[1].Value.ToString();

                chkSex.Checked = (bool)row.Cells[2].Value;

                txtBirthDay.Value = (DateTime)row.Cells["BirthDay"].Value==null?(DateTime)row.Cells["BirthDay"].Value:DateTime.Now;

                txtPhone.Text = row.Cells[4].Value.ToString()!=null? row.Cells[4].Value.ToString():string.Empty;

                txtAddress.Text = row.Cells[5].Value.ToString()!=null? row.Cells[5].Value.ToString():string.Empty;

                txtEmail.Text = row.Cells[6].Value.ToString()!=null? row.Cells[6].Value.ToString():string.Empty;

                cboDepartment.SelectedValue = row.Cells[7].Value;

                position = dgvEmployee.CurrentRow.Index;

                edit = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //txtFirstName.Text = txtLastName.Text = txtPhone.Text = txtAddress.Text = txtEmail.Text = "";
            //txtFirstName.Focus();
            //edit = false;
            ShowHideSaveCacel(true);
        }

        private void dgvEmployee_Click(object sender, EventArgs e)
        {
           // DisplayEmployeeDetail();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvEmployee.CurrentRow != null)
            {
                if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var emp = db.Employees.FirstOrDefault(x => x.Email == txtEmail.Text);
                    if (emp != null)
                    {

                        db.Employees.Remove(emp);
                        db.SaveChanges();

                        DisplayEmployee();
                    }
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy dữ liệu", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
           // DisplayEmployeeDetail();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (edit)
            {
                var emp = db.Employees.FirstOrDefault(x => x.Email == txtEmail.Text);
                if (emp != null)
                {
                    emp.FirstName = txtFirstName.Text;
                    emp.LastName = txtLastName.Text;
                    emp.BirthDay = txtBirthDay.Value;
                    emp.Sex = chkSex.Checked;
                    emp.Phone = txtPhone.Text;
                    emp.Address = txtAddress.Text; emp.Email = txtEmail.Text;
                    emp.DepartmentId = Convert.ToInt32(cboDepartment.SelectedValue);
                    db.SaveChanges();
                    DisplayEmployee();
                    dgvEmployee.Rows[0].Selected = false;
                    dgvEmployee.Rows[position].Selected = true;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy dữ liệu", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                
                var emp = new Employee();      
                emp.FirstName = txtFirstName.Text;
                emp.LastName = txtLastName.Text;
                emp.BirthDay = txtBirthDay.Value;
                emp.Sex = chkSex.Checked;
                emp.Phone = txtPhone.Text;
                emp.Address = txtAddress.Text;
                emp.Email = txtEmail.Text;
                emp.DepartmentId = (int)cboDepartment.SelectedValue;
                db.Employees.Add(emp);
                db.SaveChanges();
                DisplayEmployee();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text.Trim()))
            {
                DisplayEmployee();
                return;
            }

            var data = db.Employees.Select(n => new
            {
                n.FirstName,
                n.LastName,
                n.Sex,
                n.BirthDay,
                n.Phone,
                n.Address,
                n.Email,
                n.DepartmentId
            }).Where(n => n.FirstName.Contains(txtSearch.Text.Trim()) || n.LastName.Contains(txtSearch.Text.Trim()));

            dgvEmployee.DataSource = data.ToList();
        }

        private void dgvEmployee_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvEmployee["STT", e.RowIndex].Value = (e.RowIndex < 9 ? "0" : "") + (e.RowIndex + 1);
        }

        private void dgvEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvEmployee_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvEmployee.Rows[e.RowIndex];

            txtFirstName.Text = row.Cells["FirstName"].Value.ToString();

            //txtLastName.Text = row.Cells[1].Value.ToString();

            //chkSex.Checked = (bool)row.Cells[2].Value;

            //txtBirthDay.Value = (DateTime)row.Cells["BirthDay"].Value == null ? (DateTime)row.Cells["BirthDay"].Value : DateTime.Now;

            //txtPhone.Text = row.Cells[4].Value.ToString() != null ? row.Cells[4].Value.ToString() : string.Empty;

            //txtAddress.Text = row.Cells[5].Value.ToString() != null ? row.Cells[5].Value.ToString() : string.Empty;

            //txtEmail.Text = row.Cells[6].Value.ToString() != null ? row.Cells[6].Value.ToString() : string.Empty;

            //cboDepartment.SelectedValue = row.Cells[7].Value;


            edit = true;
        }

        private void ShowHideSaveCacel(bool isShow)
        {
            btnSave.Visible = btnCancel.Visible = isShow;
            btnAdd.Visible = btnUpdate.Visible = btnDelete.Visible=btnExit.Visible = !isShow;

            if(isShow && !edit)
            {
                txtFirstName.Text = txtLastName.Text = txtPhone.Text = txtAddress.Text = txtEmail.Text = "";
                txtFirstName.Focus();
                edit = false;
            }
        }
    }
}
