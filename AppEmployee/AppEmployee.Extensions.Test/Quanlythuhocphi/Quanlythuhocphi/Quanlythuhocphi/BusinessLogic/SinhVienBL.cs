using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quanlythuhocphi.DataAccess;

namespace Quanlythuhocphi.BusinessLogic
{
    class SinhVienBL
    {
        /// <summary>
        /// Phương thức thêm sinh viên
        /// </summary>
        /// <param name="sv"></param>
        /// <returns></returns>
        public string Insert(SINHVIEN sv)
        {
            ObjectParameter err = new ObjectParameter("err", typeof(string));
            using (QLThuhocphiEntities ql = new QLThuhocphiEntities())
            {
                 ql.InsertSINHVIEN(sv.MaSV, sv.MaLop, sv.HoSV, sv.TenSV, sv.NgaySinh, sv.GioiTinh, sv.DiaChi, sv.DienThoai, sv.Email, sv.SoCMT, sv.MaMienGiam,err);
            }
            return err.Value.ToString();
        }
        /// <summary>
        /// Phương thức cập  nhật sinh viên
        /// </summary>
        /// <param name="sv"></param>
        /// <returns></returns>
        public string Update(SINHVIEN sv)
        {
            ObjectParameter err = new ObjectParameter("err", typeof(string));
            using (QLThuhocphiEntities ql = new QLThuhocphiEntities())
            {
                 ql.UpdateSINHVIEN(sv.MaSV, sv.MaLop, sv.HoSV, sv.TenSV, sv.NgaySinh, sv.GioiTinh, sv.DiaChi, sv.DienThoai, sv.Email, sv.SoCMT, sv.MaMienGiam,err);
            }
            return err.Value.ToString();
        }
        /// <summary>
        /// Phương thức xóa sinh viên
        /// </summary>
        /// <param name="masv"></param>
        /// <returns></returns>
        public string Delete(string masv)
        {
            ObjectParameter err = new ObjectParameter("err", typeof(string));
            using (QLThuhocphiEntities ql = new QLThuhocphiEntities())
            {
                 ql.DeleteSINHVIEN(masv,err);
            }
            return err.Value.ToString();
        }
        /// <summary>
        /// Phương thức lấy mã sinh viên cuối cùng
        /// </summary>
        /// <returns></returns>
        public string GetLastMaSv()
        {
            //khai báo tham số đầu ra
            ObjectParameter masv = new ObjectParameter("masv", typeof(string));
            using (QLThuhocphiEntities ql = new QLThuhocphiEntities())
            {
                ql.GetMaSV(masv);
            }
            return masv.Value.ToString();
        }
        /// <summary>
        /// Phương thức lấy danh sách sinh viên theo lớp
        /// </summary>
        /// <param name="malop"></param>
        /// <returns></returns>
        public List<GetSINHVIEN_Result> GetSinhVienByLop(int malop)
        {
            using (QLThuhocphiEntities ql = new QLThuhocphiEntities())
            {
                return ql.GetSINHVIEN(malop).ToList<GetSINHVIEN_Result>();
            }
        }
        /// <summary>
        /// Phương thức lấy sinh viên theo mã số
        /// </summary>
        /// <param name="masv"></param>
        /// <returns></returns>
        public GetSINHVIENById_Result GetSinhVienById(string masv)
        {
            using (QLThuhocphiEntities ql = new QLThuhocphiEntities())
            {
                return ql.GetSINHVIENById(masv).FirstOrDefault();
            }
        }
        /// <summary>
        /// Phương thức lấy phần trăm miễn giảm học phí của sinh viên
        /// </summary>
        /// <param name="masv"></param>
        /// <returns></returns>
        public GetPhantrammiengiam_Result GetPhanTramMienGiam(string masv)
        {
            using (QLThuhocphiEntities ql = new QLThuhocphiEntities())
            {
                return ql.GetPhantrammiengiam(masv).FirstOrDefault();
            }
        }
        /// <summary>
        /// Phương thức tìm kiếm sinh viên theo lớp và tên
        /// </summary>
        /// <param name="malop"></param>
        /// <param name="hovaten"></param>
        /// <returns></returns>
        public List<SearchSinhVien_Result> SearchSinhVien(int malop,string hovaten)
        {
            using (QLThuhocphiEntities ql = new QLThuhocphiEntities())
            {
                return ql.SearchSinhVien(malop, hovaten).ToList<SearchSinhVien_Result>();
            }
        }
    }
}
