using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quanlythuhocphi.DataAccess;

namespace Quanlythuhocphi.BusinessLogic
{
    class PhieuThuBL
    {
        /// <summary>
        /// Phương thức thêm mới một phiếu thu
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        public string Insert(PHIEUTHU pt)
        {
            ObjectParameter err = new ObjectParameter("err", typeof(string));
            using (QLThuhocphiEntities ql = new QLThuhocphiEntities())
            {
                 ql.InsertPHIEUTHU(pt.SOPHIEU, pt.MaNV, pt.MaSV, pt.HocPhi, pt.MienGiam, pt.ThucThu, pt.NgayThu, pt.MaLyDoThu,err);
            }
            return err.Value.ToString();
        }
        /// <summary>
        /// Phương thức cập nhật một phiếu thu
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        public string Update(PHIEUTHU pt)
        {
            ObjectParameter err = new ObjectParameter("err", typeof(string));
            using (QLThuhocphiEntities ql = new QLThuhocphiEntities())
            {
                ql.UpdatePHIEUTHU(pt.SOPHIEU, pt.MaNV, pt.MaSV, pt.HocPhi, pt.MienGiam, pt.ThucThu, pt.NgayThu, pt.MaLyDoThu,err);
            }
            return err.Value.ToString();
        }
        /// <summary>
        /// Phương thức xóa một phiếu thu the mã
        /// </summary>
        /// <param name="sophieu"></param>
        /// <returns></returns>
        public int Delete(string sophieu)
        {
            using (QLThuhocphiEntities ql = new QLThuhocphiEntities())
            {
                return ql.DeletePHIEUTHU(sophieu);
            }
        }
        /// <summary>
        /// Phương thức lấy danh sách phiếu thu theo mã sinh viên
        /// </summary>
        /// <param name="masv"></param>
        /// <returns></returns>
        public List<GetPHIEUTHUBySV_Result> GetPhieuThuBySinhVien(string masv)
        {
            using (QLThuhocphiEntities ql = new QLThuhocphiEntities())
            {
                return ql.GetPHIEUTHUBySV(masv).ToList<GetPHIEUTHUBySV_Result>();
            }
        }
        /// <summary>
        /// Phương thức lấy danh sách phiếu thu từ ngày from đến ngày to và theo mã sinh viên
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public List<GetPhieuThuByNgay_Result> GetPhieuThuByNgay(DateTime from, DateTime to,string masv)
        {
            using (QLThuhocphiEntities ql = new QLThuhocphiEntities())
            {
                return ql.GetPhieuThuByNgay(from, to,masv).ToList<GetPhieuThuByNgay_Result>();
            }
        }
        /// <summary>
        /// Phương thức lấy phiếu thu theo mã số
        /// </summary>
        /// <param name="sophieu"></param>
        /// <returns></returns>
        public GetPHIEUTHUBySOPHIEU_Result GetPhieuThuBySOPHIEU(string sophieu)
        {
            using (QLThuhocphiEntities ql = new QLThuhocphiEntities())
            {
                return ql.GetPHIEUTHUBySOPHIEU(sophieu).FirstOrDefault();
            }
        }
        /// <summary>
        /// Phương thức lấy nguồn dữ liệu cho báo cáo
        /// </summary>
        /// <param name="sophieu"></param>
        /// <returns></returns>
        public ReportPhieuThu_Result GetReportPhieuThu(string sophieu)
        {
            using (QLThuhocphiEntities ql = new QLThuhocphiEntities())
            {
                return ql.ReportPhieuThu(sophieu).FirstOrDefault();
            }
        }
    }
}
