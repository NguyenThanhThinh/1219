using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quanlythuhocphi.DataAccess;
using Quanlythuhocphi.BusinessLogic;
namespace Quanlythuhocphi.Presentation
{
    public partial class frmMDI : Form
    {
        public frmMDI()
        {
            InitializeComponent();
        }

        private void frmMDI_Load(object sender, EventArgs e)
        {
            this.Text = Properties.Settings.Default.Tieude;
            //gọi màn hình login ngay khi ứng dụng chạy
            frmLogin frmlg = new frmLogin();
            frmlg.FM = this;
            frmlg.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //đóng form con hiện tại đang mở
            if (this.ActiveMdiChild != null)
                this.ActiveMdiChild.Close();
            else
                Application.Exit();//đóng ứng dụng
        }

        private void mnuClass_Click(object sender, EventArgs e)
        {
            //kiểm tra xem màn hình lớp học đã mở chưa, nếu mở rồi thì không mở nữa
            foreach (var item in this.MdiChildren)
            {
                if (item.Name == "frmLop")
                    return;
            }
            //gọi màn hình lớp học
            frmLop frmlop = new frmLop();
            frmlop.MdiParent = this;
            frmlop.Show();
        }

        private void btnLevel_Click(object sender, EventArgs e)
        {
            //kiểm tra xem màn hình miễn giảm đã mở chưa, nếu mở rồi thì không mở nữa
            foreach (var item in this.MdiChildren)
            {
                if (item.Name == "frmMiengiam")
                    return;
            }
            //gọi màn hình miễn giảm
            frmMiengiam frmmg = new frmMiengiam();
            frmmg.MdiParent = this;
            frmmg.Show();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            //kiểm tra xem màn hình thiết lập hệ thống đã mở chưa, nếu mở rồi thì không mở nữa
            foreach (var item in this.MdiChildren)
            {
                if (item.Name == "frmSetting")
                    return;
            }
            //gọi màn hình thiết lập hệ thống
            frmSetting frmht = new frmSetting();
            frmht.MdiParent = this;
            frmht.FM = this;
            frmht.Show();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            //kiểm tra xem màn hình nhân viên đã mở chưa, nếu mở rồi thì không mở nữa
            foreach (var item in this.MdiChildren)
            {
                if (item.Name == "frmNhanvien")
                    return;
            }
            //gọi màn hình nhân viên
            frmNhanvien frmnv = new frmNhanvien();
            frmnv.MdiParent = this;
            frmnv.Show();
        }

        private void btnReason_Click(object sender, EventArgs e)
        {
            //kiểm tra xem màn hình lý do thu đã mở chưa, nếu mở rồi thì không mở nữa
            foreach (var item in this.MdiChildren)
            {
                if (item.Name == "frmLydothu")
                    return;
            }
            //gọi màn hình lý do thu
            frmLydothu frmld = new frmLydothu();
            frmld.MdiParent = this;
            frmld.Show();
        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            //kiểm tra xem màn hình sinh viên đã mở chưa, nếu mở rồi thì không mở nữa
            foreach (var item in this.MdiChildren)
            {
                if (item.Name == "frmSinhvien")
                    return;
            }
            //gọi màn hình sinh viên
            frmSinhvien frmsv = new frmSinhvien();
            frmsv.MdiParent = this;
            frmsv.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //kiểm tra xem màn hình tìm kiếm đã mở chưa, nếu mở rồi thì không mở nữa
            foreach (var item in this.MdiChildren)
            {
                if (item.Name == "frmTimkiem")
                    return;
            }
            //gọi màn hình tìm kiếm
            frmTimkiem frmtk = new frmTimkiem();
            frmtk.MdiParent = this;
            frmtk.Show();
        }

        private void btnThuhocphi_Click(object sender, EventArgs e)
        {
            //kiểm tra xem màn hình thu học phí đã mở chưa, nếu mở rồi thì không mở nữa
            foreach (var item in this.MdiChildren)
            {
                if (item.Name == "frmThuhocphi")
                    return;
            }
            //gọi màn hình thu học phí
            frmThuhocphi frmthp = new frmThuhocphi();
            frmthp.MdiParent = this;
            frmthp.Show();
        }
    }
}
