﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppEmployee.Extensions.Test.Quanlythuhocphi.Quanlythuhocphi.Quanlythuhocphi.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class QLThuhocphiEntities : DbContext
    {
        public QLThuhocphiEntities()
            : base("name=QLThuhocphiEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<LOP> LOPs { get; set; }
        public virtual DbSet<LYDOTHU> LYDOTHUs { get; set; }
        public virtual DbSet<MIENGIAM> MIENGIAMs { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIENs { get; set; }
        public virtual DbSet<PHIEUTHU> PHIEUTHUs { get; set; }
        public virtual DbSet<SINHVIEN> SINHVIENs { get; set; }
    
        public virtual int CheckLogin(string manv, string matkhau, ObjectParameter hovaten)
        {
            var manvParameter = manv != null ?
                new ObjectParameter("manv", manv) :
                new ObjectParameter("manv", typeof(string));
    
            var matkhauParameter = matkhau != null ?
                new ObjectParameter("matkhau", matkhau) :
                new ObjectParameter("matkhau", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CheckLogin", manvParameter, matkhauParameter, hovaten);
        }
    
        public virtual int DeleteLOP(Nullable<int> maLop, ObjectParameter err)
        {
            var maLopParameter = maLop.HasValue ?
                new ObjectParameter("MaLop", maLop) :
                new ObjectParameter("MaLop", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteLOP", maLopParameter, err);
        }
    
        public virtual int DeleteLyDoThu(Nullable<int> malydo, ObjectParameter err)
        {
            var malydoParameter = malydo.HasValue ?
                new ObjectParameter("Malydo", malydo) :
                new ObjectParameter("Malydo", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteLyDoThu", malydoParameter, err);
        }
    
        public virtual int DeleteMIENGIAM(Nullable<int> mamiengiam, ObjectParameter err)
        {
            var mamiengiamParameter = mamiengiam.HasValue ?
                new ObjectParameter("mamiengiam", mamiengiam) :
                new ObjectParameter("mamiengiam", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteMIENGIAM", mamiengiamParameter, err);
        }
    
        public virtual int DeleteNHANVIEN(string maNV, ObjectParameter err)
        {
            var maNVParameter = maNV != null ?
                new ObjectParameter("MaNV", maNV) :
                new ObjectParameter("MaNV", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteNHANVIEN", maNVParameter, err);
        }
    
        public virtual int DeletePHIEUTHU(string sOPHIEU)
        {
            var sOPHIEUParameter = sOPHIEU != null ?
                new ObjectParameter("SOPHIEU", sOPHIEU) :
                new ObjectParameter("SOPHIEU", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeletePHIEUTHU", sOPHIEUParameter);
        }
    
        public virtual int DeleteSINHVIEN(string maSV, ObjectParameter err)
        {
            var maSVParameter = maSV != null ?
                new ObjectParameter("MaSV", maSV) :
                new ObjectParameter("MaSV", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteSINHVIEN", maSVParameter, err);
        }
    
        public virtual ObjectResult<GetLOP_Result> GetLOP()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetLOP_Result>("GetLOP");
        }
    
        public virtual ObjectResult<GetLOPID_Result> GetLOPID(Nullable<int> maLop)
        {
            var maLopParameter = maLop.HasValue ?
                new ObjectParameter("MaLop", maLop) :
                new ObjectParameter("MaLop", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetLOPID_Result>("GetLOPID", maLopParameter);
        }
    
        public virtual ObjectResult<GetLyDoThu_Result> GetLyDoThu()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetLyDoThu_Result>("GetLyDoThu");
        }
    
        public virtual ObjectResult<GetLyDoThuById_Result> GetLyDoThuById(Nullable<int> maLyDo)
        {
            var maLyDoParameter = maLyDo.HasValue ?
                new ObjectParameter("MaLyDo", maLyDo) :
                new ObjectParameter("MaLyDo", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetLyDoThuById_Result>("GetLyDoThuById", maLyDoParameter);
        }
    
        public virtual int GetMaNV(ObjectParameter manv)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetMaNV", manv);
        }
    
        public virtual int GetMaSV(ObjectParameter masv)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetMaSV", masv);
        }
    
        public virtual ObjectResult<GetMIENGIAM_Result> GetMIENGIAM()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetMIENGIAM_Result>("GetMIENGIAM");
        }
    
        public virtual ObjectResult<GetNHANVIEN_Result> GetNHANVIEN()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetNHANVIEN_Result>("GetNHANVIEN");
        }
    
        public virtual ObjectResult<GetNHANVIENById_Result> GetNHANVIENById(string manv)
        {
            var manvParameter = manv != null ?
                new ObjectParameter("Manv", manv) :
                new ObjectParameter("Manv", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetNHANVIENById_Result>("GetNHANVIENById", manvParameter);
        }
    
        public virtual ObjectResult<GetPhantrammiengiam_Result> GetPhantrammiengiam(string masv)
        {
            var masvParameter = masv != null ?
                new ObjectParameter("masv", masv) :
                new ObjectParameter("masv", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetPhantrammiengiam_Result>("GetPhantrammiengiam", masvParameter);
        }
    
        public virtual ObjectResult<GetPhieuThuByNgay_Result> GetPhieuThuByNgay(Nullable<System.DateTime> fromDate, Nullable<System.DateTime> toDate, string manv)
        {
            var fromDateParameter = fromDate.HasValue ?
                new ObjectParameter("FromDate", fromDate) :
                new ObjectParameter("FromDate", typeof(System.DateTime));
    
            var toDateParameter = toDate.HasValue ?
                new ObjectParameter("ToDate", toDate) :
                new ObjectParameter("ToDate", typeof(System.DateTime));
    
            var manvParameter = manv != null ?
                new ObjectParameter("manv", manv) :
                new ObjectParameter("manv", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetPhieuThuByNgay_Result>("GetPhieuThuByNgay", fromDateParameter, toDateParameter, manvParameter);
        }
    
        public virtual ObjectResult<GetPHIEUTHUBySOPHIEU_Result> GetPHIEUTHUBySOPHIEU(string sophieu)
        {
            var sophieuParameter = sophieu != null ?
                new ObjectParameter("sophieu", sophieu) :
                new ObjectParameter("sophieu", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetPHIEUTHUBySOPHIEU_Result>("GetPHIEUTHUBySOPHIEU", sophieuParameter);
        }
    
        public virtual ObjectResult<GetPHIEUTHUBySV_Result> GetPHIEUTHUBySV(string masv)
        {
            var masvParameter = masv != null ?
                new ObjectParameter("masv", masv) :
                new ObjectParameter("masv", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetPHIEUTHUBySV_Result>("GetPHIEUTHUBySV", masvParameter);
        }
    
        public virtual ObjectResult<GetSINHVIEN_Result> GetSINHVIEN(Nullable<int> maLop)
        {
            var maLopParameter = maLop.HasValue ?
                new ObjectParameter("MaLop", maLop) :
                new ObjectParameter("MaLop", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetSINHVIEN_Result>("GetSINHVIEN", maLopParameter);
        }
    
        public virtual ObjectResult<GetSINHVIENById_Result> GetSINHVIENById(string masv)
        {
            var masvParameter = masv != null ?
                new ObjectParameter("Masv", masv) :
                new ObjectParameter("Masv", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetSINHVIENById_Result>("GetSINHVIENById", masvParameter);
        }
    
        public virtual int InsertLOP(string tenLop, ObjectParameter err)
        {
            var tenLopParameter = tenLop != null ?
                new ObjectParameter("TenLop", tenLop) :
                new ObjectParameter("TenLop", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertLOP", tenLopParameter, err);
        }
    
        public virtual int InsertLyDoThu(string tenLyDo, ObjectParameter err)
        {
            var tenLyDoParameter = tenLyDo != null ?
                new ObjectParameter("TenLyDo", tenLyDo) :
                new ObjectParameter("TenLyDo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertLyDoThu", tenLyDoParameter, err);
        }
    
        public virtual int InsertMIENGIAM(string tenMienGiam, Nullable<int> phanTram, ObjectParameter err)
        {
            var tenMienGiamParameter = tenMienGiam != null ?
                new ObjectParameter("TenMienGiam", tenMienGiam) :
                new ObjectParameter("TenMienGiam", typeof(string));
    
            var phanTramParameter = phanTram.HasValue ?
                new ObjectParameter("PhanTram", phanTram) :
                new ObjectParameter("PhanTram", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertMIENGIAM", tenMienGiamParameter, phanTramParameter, err);
        }
    
        public virtual int InsertNHANVIEN(string maNV, string hoNV, string tenNV, Nullable<System.DateTime> ngaySinh, Nullable<bool> gioiTinh, string diaChi, string dienThoai, string email, string matKhau, ObjectParameter err)
        {
            var maNVParameter = maNV != null ?
                new ObjectParameter("MaNV", maNV) :
                new ObjectParameter("MaNV", typeof(string));
    
            var hoNVParameter = hoNV != null ?
                new ObjectParameter("HoNV", hoNV) :
                new ObjectParameter("HoNV", typeof(string));
    
            var tenNVParameter = tenNV != null ?
                new ObjectParameter("TenNV", tenNV) :
                new ObjectParameter("TenNV", typeof(string));
    
            var ngaySinhParameter = ngaySinh.HasValue ?
                new ObjectParameter("NgaySinh", ngaySinh) :
                new ObjectParameter("NgaySinh", typeof(System.DateTime));
    
            var gioiTinhParameter = gioiTinh.HasValue ?
                new ObjectParameter("GioiTinh", gioiTinh) :
                new ObjectParameter("GioiTinh", typeof(bool));
    
            var diaChiParameter = diaChi != null ?
                new ObjectParameter("DiaChi", diaChi) :
                new ObjectParameter("DiaChi", typeof(string));
    
            var dienThoaiParameter = dienThoai != null ?
                new ObjectParameter("DienThoai", dienThoai) :
                new ObjectParameter("DienThoai", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var matKhauParameter = matKhau != null ?
                new ObjectParameter("MatKhau", matKhau) :
                new ObjectParameter("MatKhau", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertNHANVIEN", maNVParameter, hoNVParameter, tenNVParameter, ngaySinhParameter, gioiTinhParameter, diaChiParameter, dienThoaiParameter, emailParameter, matKhauParameter, err);
        }
    
        public virtual int InsertPHIEUTHU(string sOPHIEU, string maNV, string maSV, Nullable<int> hocPhi, Nullable<int> mienGiam, Nullable<int> thucThu, Nullable<System.DateTime> ngayThu, Nullable<int> maLyDoThu, ObjectParameter err)
        {
            var sOPHIEUParameter = sOPHIEU != null ?
                new ObjectParameter("SOPHIEU", sOPHIEU) :
                new ObjectParameter("SOPHIEU", typeof(string));
    
            var maNVParameter = maNV != null ?
                new ObjectParameter("MaNV", maNV) :
                new ObjectParameter("MaNV", typeof(string));
    
            var maSVParameter = maSV != null ?
                new ObjectParameter("MaSV", maSV) :
                new ObjectParameter("MaSV", typeof(string));
    
            var hocPhiParameter = hocPhi.HasValue ?
                new ObjectParameter("HocPhi", hocPhi) :
                new ObjectParameter("HocPhi", typeof(int));
    
            var mienGiamParameter = mienGiam.HasValue ?
                new ObjectParameter("MienGiam", mienGiam) :
                new ObjectParameter("MienGiam", typeof(int));
    
            var thucThuParameter = thucThu.HasValue ?
                new ObjectParameter("ThucThu", thucThu) :
                new ObjectParameter("ThucThu", typeof(int));
    
            var ngayThuParameter = ngayThu.HasValue ?
                new ObjectParameter("NgayThu", ngayThu) :
                new ObjectParameter("NgayThu", typeof(System.DateTime));
    
            var maLyDoThuParameter = maLyDoThu.HasValue ?
                new ObjectParameter("MaLyDoThu", maLyDoThu) :
                new ObjectParameter("MaLyDoThu", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertPHIEUTHU", sOPHIEUParameter, maNVParameter, maSVParameter, hocPhiParameter, mienGiamParameter, thucThuParameter, ngayThuParameter, maLyDoThuParameter, err);
        }
    
        public virtual int InsertSINHVIEN(string maSV, Nullable<int> maLop, string hoSV, string tenSV, Nullable<System.DateTime> ngaySinh, Nullable<bool> gioiTinh, string diaChi, string dienThoai, string email, string soCMT, Nullable<int> maMienGiam, ObjectParameter err)
        {
            var maSVParameter = maSV != null ?
                new ObjectParameter("MaSV", maSV) :
                new ObjectParameter("MaSV", typeof(string));
    
            var maLopParameter = maLop.HasValue ?
                new ObjectParameter("MaLop", maLop) :
                new ObjectParameter("MaLop", typeof(int));
    
            var hoSVParameter = hoSV != null ?
                new ObjectParameter("HoSV", hoSV) :
                new ObjectParameter("HoSV", typeof(string));
    
            var tenSVParameter = tenSV != null ?
                new ObjectParameter("TenSV", tenSV) :
                new ObjectParameter("TenSV", typeof(string));
    
            var ngaySinhParameter = ngaySinh.HasValue ?
                new ObjectParameter("NgaySinh", ngaySinh) :
                new ObjectParameter("NgaySinh", typeof(System.DateTime));
    
            var gioiTinhParameter = gioiTinh.HasValue ?
                new ObjectParameter("GioiTinh", gioiTinh) :
                new ObjectParameter("GioiTinh", typeof(bool));
    
            var diaChiParameter = diaChi != null ?
                new ObjectParameter("DiaChi", diaChi) :
                new ObjectParameter("DiaChi", typeof(string));
    
            var dienThoaiParameter = dienThoai != null ?
                new ObjectParameter("DienThoai", dienThoai) :
                new ObjectParameter("DienThoai", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var soCMTParameter = soCMT != null ?
                new ObjectParameter("SoCMT", soCMT) :
                new ObjectParameter("SoCMT", typeof(string));
    
            var maMienGiamParameter = maMienGiam.HasValue ?
                new ObjectParameter("MaMienGiam", maMienGiam) :
                new ObjectParameter("MaMienGiam", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertSINHVIEN", maSVParameter, maLopParameter, hoSVParameter, tenSVParameter, ngaySinhParameter, gioiTinhParameter, diaChiParameter, dienThoaiParameter, emailParameter, soCMTParameter, maMienGiamParameter, err);
        }
    
        public virtual ObjectResult<ReportPhieuThu_Result> ReportPhieuThu(string sophieu)
        {
            var sophieuParameter = sophieu != null ?
                new ObjectParameter("Sophieu", sophieu) :
                new ObjectParameter("Sophieu", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ReportPhieuThu_Result>("ReportPhieuThu", sophieuParameter);
        }
    
        public virtual ObjectResult<SearchSinhVien_Result> SearchSinhVien(Nullable<int> maLop, string hovaten)
        {
            var maLopParameter = maLop.HasValue ?
                new ObjectParameter("MaLop", maLop) :
                new ObjectParameter("MaLop", typeof(int));
    
            var hovatenParameter = hovaten != null ?
                new ObjectParameter("Hovaten", hovaten) :
                new ObjectParameter("Hovaten", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SearchSinhVien_Result>("SearchSinhVien", maLopParameter, hovatenParameter);
        }
    
        public virtual int UpdateLOP(Nullable<int> maLop, string tenLop, ObjectParameter err)
        {
            var maLopParameter = maLop.HasValue ?
                new ObjectParameter("MaLop", maLop) :
                new ObjectParameter("MaLop", typeof(int));
    
            var tenLopParameter = tenLop != null ?
                new ObjectParameter("TenLop", tenLop) :
                new ObjectParameter("TenLop", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateLOP", maLopParameter, tenLopParameter, err);
        }
    
        public virtual int UpdateLyDothu(Nullable<int> malydo, string tenlydo, ObjectParameter err)
        {
            var malydoParameter = malydo.HasValue ?
                new ObjectParameter("Malydo", malydo) :
                new ObjectParameter("Malydo", typeof(int));
    
            var tenlydoParameter = tenlydo != null ?
                new ObjectParameter("Tenlydo", tenlydo) :
                new ObjectParameter("Tenlydo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateLyDothu", malydoParameter, tenlydoParameter, err);
        }
    
        public virtual int UpdateMIENGIAM(Nullable<int> maMienGiam, string tenMienGiam, Nullable<int> phanTram, ObjectParameter err)
        {
            var maMienGiamParameter = maMienGiam.HasValue ?
                new ObjectParameter("MaMienGiam", maMienGiam) :
                new ObjectParameter("MaMienGiam", typeof(int));
    
            var tenMienGiamParameter = tenMienGiam != null ?
                new ObjectParameter("TenMienGiam", tenMienGiam) :
                new ObjectParameter("TenMienGiam", typeof(string));
    
            var phanTramParameter = phanTram.HasValue ?
                new ObjectParameter("PhanTram", phanTram) :
                new ObjectParameter("PhanTram", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateMIENGIAM", maMienGiamParameter, tenMienGiamParameter, phanTramParameter, err);
        }
    
        public virtual int UpdateNHANVIEN(string maNV, string hoNV, string tenNV, Nullable<System.DateTime> ngaySinh, Nullable<bool> gioiTinh, string diaChi, string dienThoai, string email, string matKhau, ObjectParameter err)
        {
            var maNVParameter = maNV != null ?
                new ObjectParameter("MaNV", maNV) :
                new ObjectParameter("MaNV", typeof(string));
    
            var hoNVParameter = hoNV != null ?
                new ObjectParameter("HoNV", hoNV) :
                new ObjectParameter("HoNV", typeof(string));
    
            var tenNVParameter = tenNV != null ?
                new ObjectParameter("TenNV", tenNV) :
                new ObjectParameter("TenNV", typeof(string));
    
            var ngaySinhParameter = ngaySinh.HasValue ?
                new ObjectParameter("NgaySinh", ngaySinh) :
                new ObjectParameter("NgaySinh", typeof(System.DateTime));
    
            var gioiTinhParameter = gioiTinh.HasValue ?
                new ObjectParameter("GioiTinh", gioiTinh) :
                new ObjectParameter("GioiTinh", typeof(bool));
    
            var diaChiParameter = diaChi != null ?
                new ObjectParameter("DiaChi", diaChi) :
                new ObjectParameter("DiaChi", typeof(string));
    
            var dienThoaiParameter = dienThoai != null ?
                new ObjectParameter("DienThoai", dienThoai) :
                new ObjectParameter("DienThoai", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var matKhauParameter = matKhau != null ?
                new ObjectParameter("MatKhau", matKhau) :
                new ObjectParameter("MatKhau", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateNHANVIEN", maNVParameter, hoNVParameter, tenNVParameter, ngaySinhParameter, gioiTinhParameter, diaChiParameter, dienThoaiParameter, emailParameter, matKhauParameter, err);
        }
    
        public virtual int UpdatePHIEUTHU(string sOPHIEU, string maNV, string maSV, Nullable<int> hocPhi, Nullable<int> mienGiam, Nullable<int> thucThu, Nullable<System.DateTime> ngayThu, Nullable<int> maLyDoThu, ObjectParameter err)
        {
            var sOPHIEUParameter = sOPHIEU != null ?
                new ObjectParameter("SOPHIEU", sOPHIEU) :
                new ObjectParameter("SOPHIEU", typeof(string));
    
            var maNVParameter = maNV != null ?
                new ObjectParameter("MaNV", maNV) :
                new ObjectParameter("MaNV", typeof(string));
    
            var maSVParameter = maSV != null ?
                new ObjectParameter("MaSV", maSV) :
                new ObjectParameter("MaSV", typeof(string));
    
            var hocPhiParameter = hocPhi.HasValue ?
                new ObjectParameter("HocPhi", hocPhi) :
                new ObjectParameter("HocPhi", typeof(int));
    
            var mienGiamParameter = mienGiam.HasValue ?
                new ObjectParameter("MienGiam", mienGiam) :
                new ObjectParameter("MienGiam", typeof(int));
    
            var thucThuParameter = thucThu.HasValue ?
                new ObjectParameter("ThucThu", thucThu) :
                new ObjectParameter("ThucThu", typeof(int));
    
            var ngayThuParameter = ngayThu.HasValue ?
                new ObjectParameter("NgayThu", ngayThu) :
                new ObjectParameter("NgayThu", typeof(System.DateTime));
    
            var maLyDoThuParameter = maLyDoThu.HasValue ?
                new ObjectParameter("MaLyDoThu", maLyDoThu) :
                new ObjectParameter("MaLyDoThu", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdatePHIEUTHU", sOPHIEUParameter, maNVParameter, maSVParameter, hocPhiParameter, mienGiamParameter, thucThuParameter, ngayThuParameter, maLyDoThuParameter, err);
        }
    
        public virtual int UpdateSINHVIEN(string maSV, Nullable<int> maLop, string hoSV, string tenSV, Nullable<System.DateTime> ngaySinh, Nullable<bool> gioiTinh, string diaChi, string dienThoai, string email, string soCMT, Nullable<int> maMienGiam, ObjectParameter err)
        {
            var maSVParameter = maSV != null ?
                new ObjectParameter("MaSV", maSV) :
                new ObjectParameter("MaSV", typeof(string));
    
            var maLopParameter = maLop.HasValue ?
                new ObjectParameter("MaLop", maLop) :
                new ObjectParameter("MaLop", typeof(int));
    
            var hoSVParameter = hoSV != null ?
                new ObjectParameter("HoSV", hoSV) :
                new ObjectParameter("HoSV", typeof(string));
    
            var tenSVParameter = tenSV != null ?
                new ObjectParameter("TenSV", tenSV) :
                new ObjectParameter("TenSV", typeof(string));
    
            var ngaySinhParameter = ngaySinh.HasValue ?
                new ObjectParameter("NgaySinh", ngaySinh) :
                new ObjectParameter("NgaySinh", typeof(System.DateTime));
    
            var gioiTinhParameter = gioiTinh.HasValue ?
                new ObjectParameter("GioiTinh", gioiTinh) :
                new ObjectParameter("GioiTinh", typeof(bool));
    
            var diaChiParameter = diaChi != null ?
                new ObjectParameter("DiaChi", diaChi) :
                new ObjectParameter("DiaChi", typeof(string));
    
            var dienThoaiParameter = dienThoai != null ?
                new ObjectParameter("DienThoai", dienThoai) :
                new ObjectParameter("DienThoai", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var soCMTParameter = soCMT != null ?
                new ObjectParameter("SoCMT", soCMT) :
                new ObjectParameter("SoCMT", typeof(string));
    
            var maMienGiamParameter = maMienGiam.HasValue ?
                new ObjectParameter("MaMienGiam", maMienGiam) :
                new ObjectParameter("MaMienGiam", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateSINHVIEN", maSVParameter, maLopParameter, hoSVParameter, tenSVParameter, ngaySinhParameter, gioiTinhParameter, diaChiParameter, dienThoaiParameter, emailParameter, soCMTParameter, maMienGiamParameter, err);
        }
    }
}
