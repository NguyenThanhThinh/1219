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
    public partial class frmNhanvien : Form
    {
        NhanVienBL nhanvien;
        bool edit = true;
        public frmNhanvien()
        {
            InitializeComponent();
            nhanvien = new NhanVienBL();
        }

        private void frmNhanvien_Load(object sender, EventArgs e)
        {
            //hiển thị nhân viên lên lưới khi form chạy
            Show_nhanvien();
        }
        //phương thức đọc nhân viên hiện thị lên lưới
        private void Show_nhanvien()
        {
            try
            {
                dgvNhanvien.DataSource = nhanvien.GetAllNhanVien();
                //hiển thị bản ghi hiện tại đang chọn trên lưới
                Show_record();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //phương thức hiển thị bản ghi hiện tại đang chọn trên lưới
        private void Show_record()
        {
            try
            {
                if (dgvNhanvien.CurrentRow != null)
                {
                    var nv = nhanvien.GetNhanVienById(dgvNhanvien.CurrentRow.Cells[0].Value.ToString());
                    if (nv != null)
                    {
                        txtManv.Text = nv.MaNV;
                        txtHo.Text = nv.HoNV;
                        txtTen.Text = nv.TenNV;
                        txtEmail.Text = nv.Email;
                        txtDiachi.Text = nv.DiaChi;
                        txtDienthoai.Text = nv.DienThoai;
                        txtNgaysinh.Value = nv.NgaySinh.Value;
                        if (nv.GioiTinh.Value)
                            chkGioitinh.Checked = nv.GioiTinh.Value;
                        else
                            chkNu.Checked = true;
                        txtMatkhau.Text = nv.Matkhau;
                    }
                }
                else
                {
                    ClearForm();
                }
                edit = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //phương thức xóa trằng form
        private void ClearForm()
        {
            txtManv.Text = txtEmail.Text = txtHo.Text = txtDiachi.Text = txtTen.Text = txtDienthoai.Text = txtMatkhau.Text = "";
            txtHo.Focus();
        }

        private void dgvNhanvien_Click(object sender, EventArgs e)
        {
            //hiển thị thông tin lên form
            Show_record();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string manv = "";
                //lấy mã nhân viên cuối cùng
                manv=nhanvien.GetLastMaNv();
                ClearForm();
                //gọi phương thức sinh mã nhân viên tự động
               AutoGenerateId(manv);
                edit = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo thêm", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //phương thức sinh mã nhân viên tự động
        private void AutoGenerateId(string manv)
        {
            string m = "NV";
            if (manv != null)
            {
                int number = int.Parse(manv.Substring(2));
                number++;

                if (number < 10)
                    m += "0000000" + number;
                else if (number < 100)
                    m += "000000" + number;
                else if (number < 1000)
                    m += "00000" + number;
                else if (number < 10000)
                    m += "0000" + number;
                else if (number < 100000)
                    m += "000" + number;
                else if (number < 1000000)
                    m += "00" + number;
                else if (number < 10000000)
                    m += "0" + number;
                else if (number < 100000000)
                    m += number;
                else
                    m = "NV00000001";
            }
            else
                m = "NV00000001";
            txtManv.Text = m;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Show_record();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string err = "";
                //gọi phương thức kiểm tra trống trước khi sửa, ghi
                if (CheckForm())
                {
                    if (edit)
                    {
                        //update nếu là sửa
                        NHANVIEN obj = new NHANVIEN() {MaNV= txtManv.Text,HoNV= txtHo.Text,TenNV= txtTen.Text,NgaySinh= txtNgaysinh.Value,GioiTinh= chkGioitinh.Checked,DiaChi= txtDiachi.Text,DienThoai= txtDienthoai.Text,Email= txtEmail.Text,Matkhau= txtMatkhau.Text };
                        err= nhanvien.Update(obj);
                    }
                    else
                    {
                        //insert nếu là ghi
                        NHANVIEN obj = new NHANVIEN() { MaNV = txtManv.Text, HoNV = txtHo.Text, TenNV = txtTen.Text, NgaySinh = txtNgaysinh.Value, GioiTinh = chkGioitinh.Checked, DiaChi = txtDiachi.Text, DienThoai = txtDienthoai.Text, Email = txtEmail.Text, Matkhau = txtMatkhau.Text };
                        err=  nhanvien.Insert(obj);
                    }
                    if (err != "")
                        MessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        dgvNhanvien.DataSource = nhanvien.GetAllNhanVien();
                        Show_record();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //phương thức kiểm tra form trống
        private bool CheckForm()
        {
            if (txtHo.Text.Trim() == "")
            {
                MessageBox.Show("Hãy nhập họ nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtTen.Text.Trim() == "")
            {
                MessageBox.Show("Hãy nhập tên sinh viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (DateTime.Now.Year - txtNgaysinh.Value.Year < 18)
            {
                MessageBox.Show("Sinh viên chưa đủ 18 tuổi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtDiachi.Text.Trim() == "")
            {
                MessageBox.Show("Hãy nhập địa chỉ sinh viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtEmail.Text.Trim() == "")
            {
                MessageBox.Show("Hãy nhập email sinh viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                //hỏi trước khi xóa
                if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //xóa nhân viên đang chọn
                    string err = nhanvien.Delete(txtManv.Text);
                    if (err != "")
                        MessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //hiển thị lại danh sách nhân viên sau khi xóa
                    dgvNhanvien.DataSource = nhanvien.GetAllNhanVien();
                    //hiển thị bản thi hiện tại trên lưới
                    Show_record();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
