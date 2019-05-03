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
    public partial class frmLydothu : Form
    {
        //khai báo và khởi tạo biến trạng thái, mặc định là sửa
        bool edit = true;
        LyDoThuBL ld;
        public frmLydothu()
        {
            InitializeComponent();
            ld = new LyDoThuBL();
        }

        private void frmLydothu_Load(object sender, EventArgs e)
        {
            //hiển thị danh sách lý do thu lên lưới
            Show_LyDo();
        }
        //phương thức hiển thị lý do thu lên lưới
        private void Show_LyDo()
        {
            try
            {
                dgvReason.DataSource = ld.GetAllLyDoThu();
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
            if (dgvReason.CurrentRow != null)
            {
                txtName.Text = dgvReason.CurrentRow.Cells[1].Value.ToString();
                edit = true;
            }
            else
                txtName.Text = "";
        }

        private void dgvReason_Click(object sender, EventArgs e)
        {
            Show_Record();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")//nếu tên trống thì thông báo
                MessageBox.Show("Hãy nhập tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                try
                {
                    string err = "";
                    if (edit)//nếu là sửa thì gọi phương thức udpate
                    {
                        LYDOTHU obj = new LYDOTHU() { MaLyDo = int.Parse(dgvReason.CurrentRow.Cells[0].Value.ToString()), TenLyDo = txtName.Text };
                        err = ld.Update(obj);
                    }
                    else
                    {
                        //ngược lại là ghi gọi phương thức insert
                        LYDOTHU obj = new LYDOTHU() { TenLyDo = txtName.Text };
                        ld.Insert(obj);
                        txtName.Text = "";
                    }
                    if (err != "")
                        MessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        Show_LyDo();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //hỏi người dùng xem có xóa không?
                if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string err = "";
                    //gọi hành động xóa
                    err = ld.Delete(int.Parse(dgvReason.CurrentRow.Cells[0].Value.ToString()));
                    txtName.Text = "";
                    if (err != "")
                        MessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        Show_LyDo();//hiển thị lại danh sách lý do
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
