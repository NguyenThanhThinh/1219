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
using Quanlythuhocphi.DataAccess;
namespace Quanlythuhocphi.Presentation
{
    public partial class frmLop : Form
    {
        //khai báo và khởi tạo biến trạng thái, mặc định là sửa
        bool edit = true;
        LopBL lop;
        public frmLop()
        {
            InitializeComponent();
            lop = new LopBL();
        }

        private void frmLop_Load(object sender, EventArgs e)
        {
            Show_Lop();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtName.Focus();
            edit = false;//thay đổi trạng thái thành thêm
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //hỏi người dùng xem có xóa không?
                if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //gọi hành động xóa
                    var id = dgvClass.CurrentRow.Cells[0].Value.ToString();
                    string err = lop.Delete(int.Parse(id));
                    if (err != "")
                        MessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtName.Text = "";
                    Show_Lop();//hiển thị lại danh sách lớp
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Show_Lop()
        {
            try
            {
                dgvClass.DataSource = lop.GetAllLop();
                Show_Record();
                edit = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //phương thức hiển thị bản ghi được chọn trên lưới
        private void Show_Record()
        {
            if (dgvClass.CurrentRow != null) //nếu dòng chọn khác null
            {
                txtName.Text = dgvClass.CurrentRow.Cells[1].Value.ToString();
                edit = true; //trả lại trạng thái sửa
            }
            else
                txtName.Text = "";
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "") //nếu tên trống thì thông báo
                MessageBox.Show("Hãy nhập tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                try
                {
                    string err = "";
                    if (edit) //nếu là sửa thì gọi phương thức udpate
                    {
                        LOP obj = new LOP() { MaLop = int.Parse(dgvClass.CurrentRow.Cells[0].Value.ToString()), TenLop = txtName.Text };
                        err = lop.Update(obj);
                    }
                    else
                    {
                        //ngược lại là ghi gọi phương thức insert
                        LOP obj = new LOP() { MaLop = int.Parse(dgvClass.CurrentRow.Cells[0].Value.ToString()), TenLop = txtName.Text };
                        err = lop.Insert(obj);
                        txtName.Text = "";
                    }
                    if (err != "")
                        MessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        Show_Lop(); //hiển thị lớp
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvClass_Click(object sender, EventArgs e)
        {
            //hiển thị bản ghi khi kích lên lưới
            Show_Record();
        }
    }
}
