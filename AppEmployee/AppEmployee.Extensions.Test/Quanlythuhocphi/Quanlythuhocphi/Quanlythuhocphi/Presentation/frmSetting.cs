using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quanlythuhocphi.Presentation
{
    public partial class frmSetting : Form
    {
        public frmMDI FM { get; set; }
        public frmSetting()
        {
            InitializeComponent();
        }

        private void frmSetting_Load(object sender, EventArgs e)
        {
            //đọc thông tin cấu hình từ setting của hệ thống
            try
            {
                txtDiachi.Text = Properties.Settings.Default.Diachi;
                txtDienthoai.Text = Properties.Settings.Default.Dienthoai;
                txtTen.Text = Properties.Settings.Default.Tieude;
                txtEmail.Text = Properties.Settings.Default.Email;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //lưu thông tin cấu hình vào setting của hệ thống
            try
            {
                Properties.Settings.Default.Diachi = txtDiachi.Text;
                Properties.Settings.Default.Dienthoai = txtDienthoai.Text;
                Properties.Settings.Default.Tieude = txtTen.Text;
                Properties.Settings.Default.Email = txtEmail.Text;
                Properties.Settings.Default.Save();
                FM.Text = txtTen.Text;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
