using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quanlythuhocphi.DataAccess;
namespace Quanlythuhocphi.BusinessLogic
{
    class NhanVienBL
    {
        /// <summary>
        /// Phương thức kiểm tra đăng nhập của nhân viên
        /// </summary>
        /// <param name="manv"></param>
        /// <param name="matkhau"></param>
        /// <returns>họ và tên nhân viên đăng nhập</returns>
        public string CheckLogin(string manv, string matkhau)
        {
            //khai báo tham số nhận giá trị đầu ra
            ObjectParameter hovaten = new ObjectParameter("hovaten",typeof(string));
            using (QLThuhocphiEntities ql = new QLThuhocphiEntities())
            {
                ql.CheckLogin(manv, matkhau, hovaten);
            }
            return hovaten.Value.ToString();
        }
        /// <summary>
        /// Phương thức thêm nhân viên
        /// </summary>
        /// <param name="nv"></param>
        /// <returns></returns>
        public string Insert(NHANVIEN nv)
        {
            ObjectParameter err = new ObjectParameter("err", typeof(string));
            using (QLThuhocphiEntities ql = new QLThuhocphiEntities())
            {
                 ql.InsertNHANVIEN(nv.MaNV, nv.HoNV, nv.TenNV, nv.NgaySinh, nv.GioiTinh, nv.DiaChi, nv.DienThoai, nv.Email, nv.Matkhau,err);
            }
            return err.Value.ToString();
        }
        /// <summary>
        /// Phương thức cập nhật lại thông tin nhân viên
        /// </summary>
        /// <param name="nv"></param>
        /// <returns></returns>
        public string Update(NHANVIEN nv)
        {
            ObjectParameter err = new ObjectParameter("err", typeof(string));
            using (QLThuhocphiEntities ql = new QLThuhocphiEntities())
            {
                ql.UpdateNHANVIEN(nv.MaNV, nv.HoNV, nv.TenNV, nv.NgaySinh, nv.GioiTinh, nv.DiaChi, nv.DienThoai, nv.Email, nv.Matkhau,err);
            }
            return err.Value.ToString();
        }
        /// <summary>
        /// Phương thức xóa nhân viên với mã nhân viên đưa vào
        /// </summary>
        /// <param name="manv"></param>
        /// <returns></returns>
        public string Delete(string manv)
        {
            ObjectParameter err = new ObjectParameter("err", typeof(string));
            using (QLThuhocphiEntities ql = new QLThuhocphiEntities())
            {
                 ql.DeleteNHANVIEN(manv,err);
            }
            return err.Value.ToString();
        }
        /// <summary>
        /// Phương thức lấy mã nhân viên cuối cùng trong danh sách
        /// </summary>
        /// <returns></returns>
        public string GetLastMaNv()
        {
            //khai báo tham số đầu ra
            ObjectParameter manv = new ObjectParameter("manv", typeof(string));
            using (QLThuhocphiEntities ql = new QLThuhocphiEntities())
            {
                ql.GetMaNV(manv);
            }
            return manv.Value.ToString();
        }
        /// <summary>
        /// Phương thức lấy tất cả các nhân viên
        /// </summary>
        /// <returns></returns>
        public List<GetNHANVIEN_Result> GetAllNhanVien()
        {
            using (QLThuhocphiEntities ql = new QLThuhocphiEntities())
            {
                return ql.GetNHANVIEN().ToList<GetNHANVIEN_Result>();
            }
        }
        /// <summary>
        /// Phương thức lấy ra một nhân viên theo ma số truyền vào
        /// </summary>
        /// <param name="manv"></param>
        /// <returns></returns>
        public GetNHANVIENById_Result GetNhanVienById(string manv)
        {
            using (QLThuhocphiEntities ql = new QLThuhocphiEntities())
            {
                return ql.GetNHANVIENById(manv).FirstOrDefault();
            }
        }
    }
}
