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
    public partial class frmMiengiam : Form
    {
        bool edit = true;
        MienGiamBL mg;
        public frmMiengiam()
        {
            InitializeComponent();
            mg = new MienGiamBL();
        }

        private void frmMiengiam_Load(object sender, EventArgs e)
        {
            //gọi phương thức hiện thị dữ liệu trong bảng Miễn giảm lên lưới
            Show_MienGiam();
        }

        //hiển thị thông tin miễn giảm lên lưới
        private void Show_MienGiam()
        {
            try
            {
                dgvMiengiam.DataSource = mg.GetAllMienGiam();
                Show_Record();
                edit = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //hiển thị bản ghi hiện tại được chọn trên lưới
        private void Show_Record()
        {
            try
            {
                if (dgvMiengiam.CurrentRow != null)
                {
                    txtName.Text = dgvMiengiam.CurrentRow.Cells[1].Value.ToString();
                    txtTile.Value = int.Parse(dgvMiengiam.CurrentRow.Cells[2].Value.ToString());

                }
                else
                {
                    txtName.Text = "";
                }
                edit = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtTile.Value = 10;
            txtName.Focus();
            edit = false; //thay đổi trạng thái thành thêm
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //hỏi trước khi xóa
                if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //xóa bản ghi được chọn
                    string err = mg.Delete(int.Parse(dgvMiengiam.CurrentRow.Cells[0].Value.ToString()));
                    if (err != "")
                        MessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtName.Text = "";
                    txtTile.Value = 10;
                    Show_MienGiam();//hiển thị lại dữ liệu sau khi xóa
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "") //kiểm tra trống
                MessageBox.Show("Hãy nhập tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                try
                {
                    string err;
                    if (edit) //nếu là sửa thì update
                    {
                        MIENGIAM obj = new MIENGIAM() { MaMienGiam = int.Parse(dgvMiengiam.CurrentRow.Cells[0].Value.ToString()), TenMienGiam = txtName.Text, PhanTram = (int)txtTile.Value };
                        err = mg.Update(obj);
                    }
                    else
                    {
                        //nếu là thêm thi insert
                        MIENGIAM obj = new MIENGIAM() { TenMienGiam = txtName.Text, PhanTram = (int)txtTile.Value };
                        err = mg.Insert(obj);
                        txtName.Text = "";
                        txtTile.Value = 10;
                    }
                    if (err != "")
                        MessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        Show_MienGiam(); //hiển thị lại danh sách sau khi cập nhật
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvMiengiam_Click(object sender, EventArgs e)
        {
            //hiển thị thông tin khi kích vào lưới
            Show_Record();
        }
    }
}
