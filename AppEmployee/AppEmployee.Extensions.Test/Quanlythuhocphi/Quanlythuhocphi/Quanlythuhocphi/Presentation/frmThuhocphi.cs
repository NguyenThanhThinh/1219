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
    public partial class frmThuhocphi : Form
    {
        bool edit = true;
        SinhVienBL sinhvien;
        PhieuThuBL phieuthu;
        LyDoThuBL lydo;
        private string maSV;
        //khai báo thuộc tính masv
        public string MaSV
        {
            get { return maSV; }
            set //xử lý đọc thông tin sinh viên khi mã sinh viên được gán giá trị
            {
                GetPhantrammiengiam_Result phantram = sinhvien.GetPhanTramMienGiam(value);
                if (phantram != null)
                {
                    txtHovaten.Text = phantram.masv + "-" + phantram.Hovaten + "-" + phantram.TenMienGiam + "-" + phantram.Phantram + "%";
                    lblPT.Text = phantram.Phantram.Value.ToString();
                }
                maSV = value;
            }
        } 
        public frmThuhocphi()
        {
            InitializeComponent();
            sinhvien = new SinhVienBL();
            phieuthu=new PhieuThuBL();
            lydo = new LyDoThuBL();
        }

        private void frmThuhocphi_Load(object sender, EventArgs e)
        {
            //hiển thị lý do thu
            Show_lydothu();
            //hiển thị nhân viên thu tiền
            lblTenNV.Text = "Nhân viên lập phiếu:" + Properties.Settings.Default.HoVaTen;
            lblMaNV.Text = Properties.Settings.Default.MaNV;
            //hiển thị ngày tháng hiện tại
            DateTime d = DateTime.Now;
            txtFrom.Value = DateTime.Parse(d.Month + "/1/" + d.Year);
            txtTo.Value = DateTime.Parse(d.Month + "/1/" + d.Year).AddMonths(1);
            //hiển thị phiếu thu theo ngày tháng
            Show_phieuthu();
        }
        //phương thức hiển thị phiếu thu theo ngày tháng
        private void Show_phieuthu()
        {
            try
            {
                dgvPhieuthu.DataSource = phieuthu.GetPhieuThuByNgay(txtFrom.Value, txtTo.Value, lblMaNV.Text);
                if (dgvPhieuthu.CurrentRow != null)
                    Show_record();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //phương thức đọc lý do thu lên combobox
        private void Show_lydothu()
        {
            try
            {
                cboLydo.DataSource = lydo.GetAllLyDoThu();
                cboLydo.ValueMember = "Malydo";
                cboLydo.DisplayMember = "Tenlydo";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
         //hiển thị phiếu thu hiện tại lên form
        private void Show_record()
        {
            try
            {
                if (dgvPhieuthu.CurrentRow != null)
                {
                    //lấy phiếu thu theo mã
                    GetPHIEUTHUBySOPHIEU_Result pt = phieuthu.GetPhieuThuBySOPHIEU(dgvPhieuthu.CurrentRow.Cells[0].Value.ToString());
                    //nếu có
                    if (pt != null)
                    {
                        //hiển thị chi tiết lên control form
                        txtSophieu.Text = pt.SOPHIEU;
                        txtNgaythu.Value = pt.NgayThu.Value;
                        cboLydo.SelectedValue = pt.MaLyDoThu.Value;
                        txtSotien.Value = pt.HocPhi.Value;
                        txtMiengiam.Value = pt.MienGiam.Value;
                        txtthucthu.Text = pt.ThucThu.Value.ToString();

                        GetPhantrammiengiam_Result sv = sinhvien.GetPhanTramMienGiam(pt.MaSV);
                        if (sv != null)
                        {
                            txtHovaten.Text = sv.masv + "-" + sv.Hovaten + "-" + sv.TenMienGiam + "-" + sv.Phantram + "%";
                            lblPT.Text = sv.Phantram.Value.ToString();
                        }
                    }
                    edit = true;
                }
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

        private void dgvPhieuthu_Click(object sender, EventArgs e)
        {
            Show_record();
        }

        private void txtFrom_ValueChanged(object sender, EventArgs e)
        {
            Show_phieuthu();
        }

        private void txtTo_ValueChanged(object sender, EventArgs e)
        {
            Show_phieuthu();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
             //hỏi trước khi xóa
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    phieuthu.Delete(txtSophieu.Text);
                    Show_phieuthu();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string err = "";
                if (edit)//nếu là sửa thì update
                {
                    PHIEUTHU obj = new PHIEUTHU() {SOPHIEU= txtSophieu.Text,MaNV= lblMaNV.Text,MaSV= txtHovaten.Text.Substring(0, 10),HocPhi= (int)txtSotien.Value, MienGiam= (int)txtMiengiam.Value,ThucThu= int.Parse(txtthucthu.Text),NgayThu= txtNgaythu.Value,MaLyDoThu= (int)cboLydo.SelectedValue };
                    err=phieuthu.Update(obj);
                }
                else
                {
                    //ngược lại thì insert
                    PHIEUTHU obj = new PHIEUTHU() { SOPHIEU = txtSophieu.Text, MaNV = lblMaNV.Text, MaSV = txtHovaten.Text.Substring(0, 10), HocPhi = (int)txtSotien.Value, MienGiam = (int)txtMiengiam.Value, ThucThu = int.Parse(txtthucthu.Text), NgayThu = txtNgaythu.Value, MaLyDoThu = (int)cboLydo.SelectedValue };
                    err = phieuthu.Insert(obj);
                    btnSearch.Enabled = false;
                }
                if(err!="")
                    MessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    Show_phieuthu();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMiengiam_ValueChanged(object sender, EventArgs e)
        {
            //miễn giảm thay đổi thì tính lại thực thu
            try
            {
                txtthucthu.Text = (int.Parse(txtSotien.Value.ToString()) - int.Parse(txtMiengiam.Value.ToString())).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo tính tiền", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime d = DateTime.Now;
                txtNgaythu.Value = d;
                txtSophieu.Text = d.ToString("yyMMddhhmmss");
                cboLydo.SelectedIndex = 0;
                txtSotien.Value = 0;
                txtMiengiam.Value = 0;
                txtthucthu.Text = "0";
                txtHovaten.Text = "";
                btnSearch.Enabled = true;
                edit = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Show_record();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //gọi form tìm kiếm
            frmTimkiem frmtk = new frmTimkiem();
            frmtk.Status = true; //gán trạng thái cần lấy thông tin sinh viên khi tìm thấy
            frmtk.Thuhocphi = this;//truyền form thu học phí sang form tìm kiếm
            //hiển thị gợi ý cho người dùng
            frmtk.lblThongtin.Text = "Thông tin tìm thấy (Hãy kích đúp chuột vào sinh viên bạn muốn thu học phí)";
            //frmtk.WindowState = FormWindowState.Normal;
            frmtk.ShowDialog();
        }

        private void txtSotien_ValueChanged(object sender, EventArgs e)
        {
            //số tiền thay đổi thì tính lại phần trăm miễn giảm
            try
            {
                txtMiengiam.Value = txtSotien.Value * int.Parse(lblPT.Text) / 100;
                txtthucthu.Text = (int.Parse(txtSotien.Value.ToString()) - int.Parse(txtMiengiam.Value.ToString())).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo tính tiền", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (txtSophieu.Text != "")
            {
                //frmBaocao frmbc = new frmBaocao();
                //frmbc.SoPhieu = txtSophieu.Text;
                //frmbc.ShowDialog();
            }
            else
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
