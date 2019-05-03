using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quanlythuhocphi.BusinessLogic;

namespace Quanlythuhocphi.Presentation
{
    public partial class frmLogin : Form
    {
        public frmMDI FM { get; set; }
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit(); //thoát khỏi ứng dụng
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //Khởi tạo đối tượng nghiệp vụ nhân viên
            NhanVienBL sv = new NhanVienBL();
            //kiểm tra trống trường tên và mật khẩu
            if (txtP.Text.Trim() != "" && txtU.Text.Trim() != null)
            {
                string hovaten = "";
                //gọi phương thức kiểm tra login và trả về kết quả qua biến hovaten
                hovaten=sv.CheckLogin(txtU.Text, txtP.Text);
                //nếu hovaten vẫn bằng trống thì login sai
                if (hovaten == "")
                    MessageBox.Show("Đăng nhập sai", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    //trường hợp login đúng lưu thông tin mã nhân viên, tên để sử dụng sau nay
                    Properties.Settings.Default.MaNV = txtU.Text;
                    Properties.Settings.Default.HoVaTen = hovaten;
                    Properties.Settings.Default.Save();
                    //kiểm tra nếu hoten không là admin thì chỉ cho tìm kiếm và thu học phí
                    if (!hovaten.Contains("admin"))
                    {
                        FM.mnuClass.Enabled = false;
                        FM.btnEmployee.Enabled = false;
                        FM.btnLevel.Enabled = false;
                        FM.btnReason.Enabled = false;
                        FM.btnSetting.Enabled = false;
                        FM.btnStudent.Enabled = false;
                    }
                    else
                    {
                        //ngược lại là admin thì không cho thu học phí
                        FM.btnThuhocphi.Enabled = false;
                    }
                    //hiển thị tên người đăng nhập xuống thanh trạng thái ứng dụng
                    FM.lblNV.Text = "Xin chào:" + hovaten;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Hãy nhập tên đăng nhập và mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
