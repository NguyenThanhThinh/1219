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
    public partial class frmSinhvien : Form
    {
        //khai báo biến
        bool edit = true;
        SinhVienBL sinhvien;
        MienGiamBL mg;
        LopBL lop;
        public frmSinhvien()
        {
            InitializeComponent();
            sinhvien = new SinhVienBL();
            mg = new MienGiamBL();
            lop = new LopBL();
        }

        private void frmSinhvien_Load(object sender, EventArgs e)
        {
            Show_Lop(); //gọi phương thức hiển thị lớp học
            Show_Miengiam(); //gọi phương thức hiển thị miễn giảm
        }
        //phương thức hiển thị miễn giảm lên combobox để chọn
        private void Show_Miengiam()
        {
            try
            {
                cboMG.DataSource = mg.GetAllMienGiam();
                cboMG.ValueMember = "MaMienGiam";
                cboMG.DisplayMember = "TenMienGiam";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //phương thức hiển thị lớp học lên treeview
        private void Show_Lop()
        {
            try
            {
                TreeNode root = new TreeNode();//tạo nút gốc
                root.Text = "Danh mục lớp";
                root.Tag = 0;
                root.ImageIndex = 0;
                //duyệt từng lớp
                foreach (var item in lop.GetAllLop())
                {
                    //tạo nút con
                    TreeNode child = new TreeNode();
                    child.Text = item.TenLop;
                    child.Tag = item.MaLop;
                    child.ImageIndex = 1;
                    child.SelectedImageIndex = 2;
                    //thêm nút con vào nút gốc
                    root.Nodes.Add(child);
                }
                //thêm nút gốc lên cây
                trvClass.Nodes.Add(root);
                //mở cây để xem
                trvClass.ExpandAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //sự kiện sau khi chọn tên lớp trên cây
        private void trvClass_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e.Node.Tag.ToString() == "0") //nếu chọn nút gốc thì ẩn khung sinh viên đi
                {
                    lblClass.Text = "Danh sách sinh viên";
                    dgvStudent.Rows.Clear();
                    ClearForm();
                    splitContainer1.Panel2.Enabled = false;
                }
                else
                {
                    //ngược lại hiển thị sinh viên theo lớp đã chọn
                    lblClass.Text = "Danh sách sinh viên lớp:" + e.Node.Text;
                    lblId.Text = e.Node.Tag.ToString();
                    dgvStudent.DataSource = sinhvien.GetSinhVienByLop(int.Parse(e.Node.Tag.ToString()));
                    splitContainer1.Panel2.Enabled = true;
                    Show_record();//hiện thị bản ghi hiện tại lên form
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //phương thức hiển thị bản ghi hiện tại trên lưới lên form
        private void Show_record()
        {
            try
            {
                if (dgvStudent.CurrentRow != null)
                {
                    GetSINHVIENById_Result sv = sinhvien.GetSinhVienById(dgvStudent.CurrentRow.Cells[0].Value.ToString());
                    if (sv != null)
                    {
                        txtMa.Text = sv.MaSV;
                        txtHo.Text = sv.HoSV;
                        txtTen.Text = sv.TenSV;
                        txtEmail.Text = sv.Email;
                        txtDiachi.Text = sv.DiaChi;
                        txtDienthoai.Text = sv.DienThoai;
                        txtCMT.Text = sv.SoCMT;
                        txtNgaysinh.Value = sv.NgaySinh.Value;
                        if (sv.GioiTinh.Value)
                            chkGioitinh.Checked = sv.GioiTinh.Value;
                        else
                            chkNu.Checked = true;
                        cboMG.SelectedValue = sv.MaMienGiam.Value;
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
        //xóa trắng form
        private void ClearForm()
        {
            txtMa.Text = txtEmail.Text = txtHo.Text = txtDiachi.Text = txtTen.Text = txtDienthoai.Text = txtCMT.Text = "";
            txtHo.Focus();
        }

        private void dgvStudent_Click(object sender, EventArgs e)
        {
            Show_record();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string masv = "";
                masv = sinhvien.GetLastMaSv(); //lấy mã sinh viên cuối cùng
                ClearForm();
                SinhMaTuDong(masv); //gọi phương thức sinh mã tự động
                edit = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //phương thức sinh mã tự động
        private void SinhMaTuDong(string masv)
        {
            string m = "SV";
            if (masv != null)
            {
                int number = int.Parse(masv.Substring(2));
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
                    m = "SV00000001";
            }
            else
                m = "SV00000001";
            txtMa.Text = m;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Show_record();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            try
            {
                //hỏi trước khi xóa
                if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (dgvStudent.SelectedRows.Count > 0)
                    {
                        //xóa các sinh viên được chọn
                        for (int i = 0; i < dgvStudent.SelectedRows.Count; i++)
                        {
                           string err=sinhvien.Delete(dgvStudent.SelectedRows[i].Cells[0].Value.ToString());
                           if(err!="")
                                MessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        //xóa sinh viên hiện tại
                        string err = sinhvien.Delete(txtMa.Text);
                        if (err != "")
                            MessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    //hiển thị lại danh sách sinh viên
                    dgvStudent.DataSource = sinhvien.GetSinhVienByLop(int.Parse(lblId.Text));
                    Show_record(); //hiển thị bản ghi hiện tại
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckForm())
                {
                    string err = "";
                    if (edit)
                    {
                       //update sinh viên nếu là sửa
                       SINHVIEN obj = new SINHVIEN() {MaSV= txtMa.Text,MaLop= int.Parse(lblId.Text),HoSV= txtHo.Text,TenSV= txtTen.Text,NgaySinh= txtNgaysinh.Value,GioiTinh= chkGioitinh.Checked,DiaChi= txtDiachi.Text,DienThoai= txtDienthoai.Text,Email= txtEmail.Text,SoCMT= txtCMT.Text,MaMienGiam= int.Parse(cboMG.SelectedValue.ToString()) };
                       err= sinhvien.Update(obj);
                    }
                    else
                    {
                        //insert sinh viên nếu là thêm
                        SINHVIEN obj = new SINHVIEN() { MaSV = txtMa.Text, MaLop = int.Parse(lblId.Text), HoSV = txtHo.Text, TenSV = txtTen.Text, NgaySinh = txtNgaysinh.Value, GioiTinh = chkGioitinh.Checked, DiaChi = txtDiachi.Text, DienThoai = txtDienthoai.Text, Email = txtEmail.Text, SoCMT = txtCMT.Text, MaMienGiam = int.Parse(cboMG.SelectedValue.ToString()) };
                        err = sinhvien.Insert(obj);
                        edit = true;
                    }
                    dgvStudent.DataSource = sinhvien.GetSinhVienByLop(int.Parse(lblId.Text));
                    Show_record();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //kiểm tra form trống
        private bool CheckForm()
        {
            if (txtHo.Text.Trim() == "")
            {
                MessageBox.Show("Hãy nhập họ sinh viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (txtCMT.Text.Trim() == "")
            {
                MessageBox.Show("Hãy nhập CMT sinh viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
