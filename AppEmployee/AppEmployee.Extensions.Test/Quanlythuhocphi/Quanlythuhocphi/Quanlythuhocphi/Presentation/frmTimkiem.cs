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
    public partial class frmTimkiem : Form
    {
        SinhVienBL sinhvien;
        LopBL lop;
        PhieuThuBL phieuthu;
        //khai báo thuộc tính SV để xác định xem khi kích đúp chuột thì có lấy thông tin sang form phiếu thu không
        public bool Status { get; set; }
        //khai báo thuộc tính tham chiếu tới form học phí
        public frmThuhocphi Thuhocphi { get; set; }
        public frmTimkiem()
        {
            InitializeComponent();
            sinhvien=new SinhVienBL();
            lop=new LopBL();
            phieuthu = new PhieuThuBL();
            Status = false;
        }

        private void frmTimkiem_Load(object sender, EventArgs e)
        {
            Show_Lop();
        }
        //đọc danh sách lớp lên combobox
        private void Show_Lop()
        {
            try
            {
                cboLop.DataSource = lop.GetAllLop();
                cboLop.DisplayMember = "TenLop";
                cboLop.ValueMember = "MaLop";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvSinhvien_Click(object sender, EventArgs e)
        {
            //kích chuột vào dòng trên lưới sinh viên thì hiện thị thông tin học phí xuống lưới 2
            if (dgvSinhvien.CurrentRow != null)
                dgvHocphi.DataSource = phieuthu.GetPhieuThuBySinhVien(dgvSinhvien.CurrentRow.Cells[0].Value.ToString());
        }

        private void dgvSinhvien_DoubleClick(object sender, EventArgs e)
        {
            //nếu người dùng tìm kiếm từ form thu học phí thì chuyển giá trị masv sang form thu học phí
            if (dgvSinhvien.CurrentRow != null && Status)
            {
                Thuhocphi.MaSV = dgvSinhvien.CurrentRow.Cells[0].Value.ToString();
                this.Close(); //đóng cửa sổ
            }
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            try
            {
                //nếu lớp được chọn
                if (cboLop.SelectedItem != null)
                {
                    //gọi phương thức tìm kiếm và hiển thị lên lưới 1
                    dgvSinhvien.DataSource = sinhvien.SearchSinhVien(int.Parse(cboLop.SelectedValue.ToString()), txtHoten.Text);
                    //nếu sinh viên tìm thấy thì hiển thị thông tin học phí xuống lưới thứ 2
                    if (dgvSinhvien.CurrentRow != null)
                        dgvHocphi.DataSource = phieuthu.GetPhieuThuBySinhVien(dgvSinhvien.CurrentRow.Cells[0].Value.ToString());
                    else
                        dgvHocphi.DataSource = phieuthu.GetPhieuThuBySinhVien("");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
