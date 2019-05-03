---------------------PHẦN 1 TẠO CSDL và CÁC BẢNG---------------------
--------------------------Tạo cơ sở dữ liệu--------------------------
create database QLThuhocphi
go
use QLThuhocphi
go
--tạo bảng lớp
create table LOP
(
	MaLop int primary key identity
	,TenLop nvarchar(20) unique
)
go
--dữ liệu mẫu cho bảng lớp
insert into LOP values('C1207H')
insert into LOP values('C1208H1')
insert into LOP values('C1209G')
insert into LOP values('C1209G1')
go
--tạo bảng miễn giảm
create table MIENGIAM
(
	MaMienGiam int primary key identity
	,TenMienGiam nvarchar(100) unique
	,PhanTram int
)
go
--dữ liệu mẫu cho bảng miễn giảm
insert into MIENGIAM values (N'Không miễn giảm',0);
insert into MIENGIAM values (N'Con thương binh loại 1',30)
insert into MIENGIAM values (N'Con thương binh loại 2',40)
insert into MIENGIAM values (N'Con bệnh binh loại 1',30)
insert into MIENGIAM values (N'Con liệt sỹ',100)

go
--tạo bảng sinh viên
create table SINHVIEN 
(
	 MaSV char(10) primary key 
	,MaLop int foreign key references LOP(MaLop)
	,HoSV nvarchar(20)
	,TenSV nvarchar(20)
	,NgaySinh datetime
	,GioiTinh bit
	,DiaChi nvarchar(200)
	,DienThoai varchar(100)
	,Email varchar(100) 
	,SoCMT varchar(15) 
	,MaMienGiam int foreign key references MIENGIAM(MaMienGiam)
)
go
 insert into SINHVIEN values('SV00000001',1,N'Nguyễn Đăng',N'Khôi','07/20/1976',1,N'Trấn Yên - Yên Bái','0987655555','khoind@gmail.com','168495900',1)
 insert into SINHVIEN values('SV00000002',1,N'Lại Đức',N'Chung','07/20/1980',1,N'Thanh Liêm - Hà Nam','0987655555','chungld@gmail.com','1687876876',1)
 insert into SINHVIEN values('SV00000003',2,N'Tạ Văn',N'Hùng','07/20/1990',1,N'Thanh Xuân - Hà Nội','0987655555','hungtv@gmail.com','0986544433',2)
 insert into SINHVIEN values('SV00000004',1,N'Lê Thị',N'Thủy','07/20/1991',1,N'Thanh Xuân - Hà Nội','0987289787','thuylt@gmail.com','1684545454',2)
 go
 --tạo bảng nhân viên
 create table NHANVIEN 
 (
	MaNV char(10) primary key
	,HoNV nvarchar(20)
	,TenNV nvarchar(20)
	,NgaySinh datetime
	,GioiTinh bit
	,DiaChi nvarchar(200)
	,DienThoai varchar(100)
	,Email varchar(100)
	,Matkhau varchar(100)
 )
 go
 Insert into NHANVIEN values('NV00000001','admin','admin','1/1/1990',1,N'Hà Nội','0987654321','admin@gmail.com','123456')
 Insert into NHANVIEN values('NV00000002',N'Nguyễn Đăng','Khôi','1/1/1976',1,N'Hà Nội','0987654321','khoiit@gmail.com','123456')

 go
 --tạo bảng lý do thu tiền
create table LYDOTHU
(
	MaLyDo int primary key identity
	,TenLyDo nvarchar(100)unique
)
go
--dữ liệu mẫu
insert into LYDOTHU values(N'Thu học phí kỳ I')
insert into LYDOTHU values(N'Thu học phí kỳ II')
insert into LYDOTHU values(N'Thu học phí kỳ III')
insert into LYDOTHU values(N'Thu học phí kỳ IV')
insert into LYDOTHU values(N'Thu học phí kỳ V')
insert into LYDOTHU values(N'Thu học phí kỳ VI')
insert into LYDOTHU values(N'Thu học phí kỳ VII')
insert into LYDOTHU values(N'Thu học phí kỳ VIII')
go
--tạo bảng thu học phí
create table PHIEUTHU 
(
	SOPHIEU char(12) primary key
	,MaNV char(10) foreign key references NHANVIEN(MaNV)
	,MaSV char(10) foreign key references SINHVIEN(MaSV)
	,HocPhi int
	,MienGiam int
	,ThucThu int
	,NgayThu datetime
	,MaLyDoThu int foreign key references LYDOTHU(MaLyDo)
)
go 


-------------------PHẦN 2 TẠO CÁC THỦ TỤC TRUY XUẤT DỮ LIỆU--------------------------
---------------------------1. Các thủ tục cho bảng lớp-------------------------------
--Thêm lớp
Create proc [InsertLOP]
	 @TenLop	nvarchar(40),
	 @Err nvarchar(100) output
as
	 if(@TenLop in(Select [TenLop] from [LOP]))
	 begin
		 set @Err=N'Trùng giá trị trường tên lớp'
		 return 
	 end
	 Insert into [LOP] values(@TenLop)
	 set @Err=''
go
--cập nhật lớp
Create  proc [UpdateLOP]
	 @MaLop	int,
	 @TenLop	nvarchar(40),
	 @Err nvarchar(100) output
as
	 if(@TenLop in(Select [TenLop] from [LOP] where [MaLop]<>@MaLop))
	 begin
		 set @Err=N'Trùng giá trị trường tên lớp'
		 return
	 end
	 Update [LOP] set [TenLop]=@TenLop where [MaLop]=@MaLop 
	 set @Err=''
go
--xóa lớp
Create  proc [DeleteLOP]
	 @MaLop	int,
	 @Err nvarchar(100) output
as
	 if(@MaLop in(Select [MaLop] from [SINHVIEN]))
	 begin
		 set @Err= N'Bảng này đang có dữ liệu liên quan đến bảng SINHVIEN, không xóa được'
		 return
	 end
	 Delete from [LOP] where [MaLop]=@MaLop
	 set @Err=''
go
--lấy tất cả các lớp
Create proc [GetLOP]
as
	 Select * from [LOP] order by [TenLop] 
go
--lấy lớp theo ID
Create proc [GetLOPID]
	 @MaLop	 int
as
	 Select * from [LOP] where [MaLop]= @MaLop
go
---------------------------------2. Các thủ tục cho bảng Miễn giảm--------------------------------------
--thêm miễn giảm
Create proc InsertMIENGIAM
	@TenMienGiam nvarchar(100),
	@PhanTram int,
	@Err nvarchar(100) output
as
	if(@TenMienGiam in (select TenMienGiam from MIENGIAM))
	begin
		set @Err= N'Trùng tên'
		return
	end
	insert into MIENGIAM values(@TenMienGiam,@PhanTram)
	set @Err=''
go
--cập nhật miễn giảm
Create  proc UpdateMIENGIAM
	@MaMienGiam int,
	@TenMienGiam nvarchar(100),
	@PhanTram int,
	@Err nvarchar(100) output
as
	if(@TenMienGiam in (select TenMienGiam from MIENGIAM where MaMienGiam<>@MaMienGiam))
	begin
		set @Err=N'Trùng tên'
		return
	end
	update MIENGIAM set TenMienGiam=@TenMienGiam,PhanTram= @PhanTram where MaMienGiam=@MaMienGiam
	set @Err=''
go
--xóa miễn giảm
Create  proc DeleteMIENGIAM
	@mamiengiam int,
	@Err nvarchar(100) output
as
	if(@mamiengiam in(select MaMienGiam from SINHVIEN))
	begin
		set @Err= N'Loại này đang tồn tại trong bảng sinh viên không xóa được'
		return
	end
	delete from MIENGIAM where MaMienGiam=@mamiengiam
	set @Err=''
go
--lấy tất cả bảng miễn giảm
Create proc GetMIENGIAM
as
	select * from MIENGIAM
go
------------------------------------3 Các thủ tục cho bảng sinh viên--------------------------------------
--thêm sinh viên
Create  proc [InsertSINHVIEN]
	 @MaSV	char(10),
	 @MaLop	int, 
	 @HoSV	nvarchar(20),
	 @TenSV	nvarchar(20),
	 @NgaySinh	datetime,	 
	 @GioiTinh	bit,
	 @DiaChi	nvarchar(200),
	 @DienThoai	varchar(100),
	 @Email	varchar(100),
	 @SoCMT	varchar(15),
	 @MaMienGiam	int,
	 @Err nvarchar(100) output
as
	 if(@MaSV in(Select [MaSV] from [SINHVIEN]))
	 begin
		 set @Err=N'Trùng mã(khóa chính)'
		 return
	 end
	 if(@SoCMT in(Select [SoCMT] from [SINHVIEN]))
	 begin
		 set @Err=N'Trùng giá trị trường SoCMT'
		 return
	 end
	 if(@Email in(Select [Email] from [SINHVIEN]))
	 begin
		 set @Err=N'Trùng giá trị trường Email'
		 return
	 end
	 Insert into [SINHVIEN] values(@MaSV,@MaLop,@HoSV,@TenSV,@NgaySinh,@GioiTinh,@DiaChi,@DienThoai,@Email,@SoCMT,@MaMienGiam)
	 set @Err=''
go
--cập nhật sinh viên
Create proc [UpdateSINHVIEN]
	 @MaSV	char(10),
	 @MaLop	int, 
	 @HoSV	nvarchar(20),
	 @TenSV	nvarchar(20),
	 @NgaySinh	datetime,	 
	 @GioiTinh	bit,
	 @DiaChi	nvarchar(200),
	 @DienThoai	varchar(100),
	 @Email	varchar(100),
	 @SoCMT	varchar(15),
	 @MaMienGiam	int,
	 @Err nvarchar(100) output
as
	 if(@Email in(Select [Email] from [SINHVIEN] where MaSV<>@MaSV))
	 begin
		 set @Err= N'Trùng giá trị trường Email'
		 return
	 end
	 if(@SoCMT in(Select [SoCMT] from [SINHVIEN] where MaSV<>@MaSV))
	 begin
		 set @Err=N'Trùng giá trị trường SoCMT'
		 return
	 end
	 Update [SINHVIEN] set [MaMienGiam]=@MaMienGiam,[NgaySinh]=@NgaySinh,[GioiTinh]=@GioiTinh,[DienThoai]=@DienThoai,[Email]=@Email,[SoCMT]=@SoCMT,[DiaChi]=@DiaChi,[HoSV]=@HoSV,[TenSV]=@TenSV,[MaLop]=@MaLop where MaSV=@MaSV
	 set @Err=''
go
--Xóa sinh viên
Create  proc DeleteSINHVIEN
	@MaSV char(10),
	@Err nvarchar(100) output
as
	if(@masv in(select MaSV from PHIEUTHU))
	begin
		set @Err=N'Sinh viên này đang học không xóa được'
		return
	end
	delete from SINHVIEN where MaSV=@masv
	set @Err=''
go
--lấy sinh viên theo ID
Create proc GetSINHVIENById
	@Masv char(10)
as
	select * from SINHVIEN where  MaSV=@masv
go
--lấy sinh viên theo lớp
Create  proc GetSINHVIEN
@MaLop int
as
	select Masv, HoSV+' '+ TenSV as Hovaten, NgaySinh,
	(case GioiTinh when 1 then 'Nam' when 0 then N'Nữ' end) as Gioitinh,
	DiaChi, DienThoai,Email, SoCMT, TenMienGiam as Thuocdien
	 from SINHVIEN, MIENGIAM 
	 where SINHVIEN.MaMienGiam=MIENGIAM.MaMienGiam and SINHVIEN.MaLop=@MaLop
go
--lấy mã sinh viên cuối cùng
Create proc GetMaSV
@masv char(10) output
as
	select @masv=(select top 1 MaSV from SINHVIEN order by MaSV desc)
go
--tìm kiếm sinh viên theo lớp và tên
Create  proc SearchSinhVien
@MaLop int,
@Hovaten nvarchar(100)
as
	select MaSV, HoSV+' '+ TenSV as Hovaten, NgaySinh,
	(case GioiTinh when 1 then 'Nam' when 0 then N'Nữ' end) as Gioitinh,
	DiaChi, DienThoai,Email, SoCMT, TenMienGiam as Thuocdien
	 from SINHVIEN, MIENGIAM 
	 where SINHVIEN.MaMienGiam=MIENGIAM.MaMienGiam and SINHVIEN.MaLop=@MaLop and HoSV+' ' + TenSV like N'%' + @Hovaten + '%'
go
------------------------------------4. Các thủ tục cho bảng nhân viên-----------------------------------
--thêm nhân viên
Create proc [InsertNHANVIEN]
	 @MaNV	char(10),
	 @HoNV	nvarchar(20),
	 @TenNV	nvarchar(20),
	 @NgaySinh	datetime,	 
	 @GioiTinh	bit,
	 @DiaChi	nvarchar(200),
	 @DienThoai	varchar(100),
	 @Email	varchar(100),
	 @MatKhau varchar(100),
	 @Err nvarchar(100) output
as
	 if(@MaNV in(Select [MaNV] from [NHANVIEN]))
	 begin
		 set @Err=N'Trùng mã(khóa chính)'
		 return
	 end
	 if(@Email in(Select [Email] from [NHANVIEN]))
	 begin
		 set @Err=N'Trùng giá trị trường Email'
		 return
	 end
	 Insert into [NHANVIEN] values(@MaNV,@HoNV,@TenNV,@NgaySinh,@GioiTinh,@DiaChi,@DienThoai,@Email,@MatKhau)
	 set @Err=''
go
--cập nhật nhân viên
Create  proc [UpdateNHANVIEN]
	 @MaNV	char(10),
	 @HoNV	nvarchar(20),
	 @TenNV	nvarchar(20),
	 @NgaySinh	datetime,	 
	 @GioiTinh	bit,
	 @DiaChi	nvarchar(200),
	 @DienThoai	varchar(100),
	 @Email	varchar(100),
	 @MatKhau varchar(100),
	 @Err nvarchar(100) output
as
	 if(@Email in(Select [Email] from NHANVIEN where MaNV<>@MaNV))
	 begin
		 set @Err=N'Trùng giá trị trường Email '
		 return
	 end
	 Update [NHANVIEN] set Matkhau=@Matkhau,[NgaySinh]=@NgaySinh,[GioiTinh]=@GioiTinh,[DienThoai]=@DienThoai,[Email]=@Email,[DiaChi]=@DiaChi,[HoNV]=@HoNV,[TenNV]=@TenNV where MaNV=@MaNV
	 set @Err=''
go
--xóa nhân viên
Create   proc DeleteNHANVIEN
	@MaNV char(10),
	@Err nvarchar(100) output
as
	if((select Email from NHANVIEN where MaNV=@manv)='admin@gmail.com')
	begin
		set @Err=N'Không xóa được quản trị'
		return
	end
	if(@manv in(select MaNV from PHIEUTHU))
	begin
		set @Err=N'Nhan viên này đang thu học phí không xóa được'
		return
	end
	delete from NHANVIEN where MaNV=@manv
	set @Err=''
go
--lấy nhân viên theo id
Create proc GetNHANVIENById
	@Manv char(10)
as
	select * from NHANVIEN where  MaNV=@manv
go
--lấy danh sách nhân viên
Create  proc GetNHANVIEN
as
	select Manv, HoNV+' '+ TenNV as Hovaten, NgaySinh,
	(case GioiTinh when 1 then 'Nam' when 0 then N'Nữ' end) as Gioitinh,
	Diachi, Dienthoai,Email,Matkhau
	from NHANVIEN
go
--lấy mã nhân viên cuối cùng
Create proc GetMaNV
@manv char(10) output
as
	select @manv=(select top 1 MaNV from NHANVIEN order by MaNV desc)
go
--kiểm tra login
Create proc CheckLogin
@manv varchar(10),
@matkhau varchar(100),
@hovaten nvarchar(100) output
as
	if(exists(select * from NHANVIEN where MaNV=@manv and Matkhau=@matkhau))
	begin
		select @hovaten=(select HoNV + ' ' + TenNV from NHANVIEN where MaNV=@manv)
	end
	else
	begin
		set @hovaten=''
	end
go
-------------------------5. các thủ tục cho bảng lý do thu--------------------------------
--thêm lý do thu
Create proc InsertLyDoThu
	@TenLyDo nvarchar(100),
	@Err nvarchar(100) output
as
	if(@TenLyDo in(select TenLyDo from LYDOTHU))
	begin
		set @Err=N'Trùng tên lý do thu'
		return
	end
	insert into LYDOTHU values(@TenLyDo)
	set @Err=''
go
--cập nhật lý do thu
Create proc UpdateLyDothu
	@Malydo int,
	@Tenlydo nvarchar(100),
	@Err nvarchar(100) output
as
	if(@TenLyDo in(select TenLyDo from LYDOTHU where MaLyDo<>@Malydo))
	begin
		set @Err=N'Trùng tên lý do thu'
		return
	end
	update LYDOTHU set TenLyDo=@TenLyDo where MaLyDo=@malydo
	set @Err=''
go
--xóa lý do thu
Create proc DeleteLyDoThu
	@Malydo int,
	@Err nvarchar(100) output
as
	if(@malydo in(select MaLyDoThu from PHIEUTHU))
	begin
		set @Err=N'Ly do này đang có liên quan đến dữ liệu không xóa được'
		return
	end
	delete from LYDOTHU where MaLyDo=@malydo
	set @Err=''
go
--lấy tất cả ý do thu
Create proc GetLyDoThu
as
	select * from LYDOTHU
go
--lấy ly do thu theo id
Create proc GetLyDoThuById
@MaLyDo int
as
	select * from LYDOTHU where MalyDo=@MaLyDo
go
---------------------------6. Các thủ tục cho bảng thu học phí---------------------------
--lấy phiếu thu
Create proc GetPHIEUTHUBySV
@masv char(10)
as
	select SOPHIEU, nv.HoNV+' ' + nv.TenNV as nhanvienthu,
	TenLyDo, NgayThu,HocPhi,MienGiam,ThucThu
	from PHIEUTHU, NHANVIEN nv, LYDOTHU
	where PHIEUTHU.MaNV=nv.MaNV and LYDOTHU.MaLyDo=MaLyDoThu and MaSV=@masv
go
--thêm phiếu thu
Create  proc InsertPHIEUTHU
	@SOPHIEU char(12),
	@MaNV char(10),
	@MaSV char(10),
	@HocPhi int,
	@MienGiam int,
	@ThucThu int,
	@NgayThu datetime,
	@MaLyDoThu int,
	@Err nvarchar(100) output
as
	if(@SOPHIEU in(select SOPHIEU from PHIEUTHU))
	begin
		set @Err=N'Trùng số phiếu'
		return
	end
	if(@MaLyDoThu in(select MaLyDoThu from PHIEUTHU where MaSV=@MaSV))
	begin
		set @Err=N'Sinh viên đã đóng học phí kỳ này rồi'
		return
	end
	insert into PHIEUTHU values(@SOPHIEU,@MaNV,@MaSV,@HocPhi,@MienGiam,@ThucThu,@NgayThu,@MaLyDoThu)
	set @Err=''
go
--cập nhật phiếu thu
Create proc UpdatePHIEUTHU
	@SOPHIEU char(12),
	@MaNV char(10),
	@MaSV char(10),
	@HocPhi int,
	@MienGiam int,
	@ThucThu int,
	@NgayThu datetime,
	@MaLyDoThu int,
	@Err nvarchar(100) output
as
	if(@MaLyDoThu in(select MaLyDoThu from PHIEUTHU where MaSV=@MaSV and @SOPHIEU<>SOPHIEU))
	begin
		set @Err=N'Sinh viên đã đóng học phí kỳ này rồi'
		return
	end
	update PHIEUTHU set manv=@MaNV,masv=@MaSV,HocPhi=@HocPhi,MienGiam=@MienGiam,ThucThu=@ThucThu,NgayThu=@NgayThu,MaLyDoThu=@MaLyDoThu
	where SOPHIEU=@SOPHIEU
	set @Err=''
go
--xóa phiếu thu
Create proc DeletePHIEUTHU
	@SOPHIEU char(12)
as
	delete from PHIEUTHU where SOPHIEU=@SOPHIEU
go
--lấy phiếu thu từ ngày đến ngày theo nhân viên thu
Create proc GetPhieuThuByNgay
	@FromDate date,
	@ToDate date,
	@manv char(10)
as
	select SOPHIEU, nv.HoNV+' ' + nv.TenNV as nhanvienthu,
	TenLyDo, NgayThu,HocPhi,MienGiam,ThucThu,sv.HoSV+ ' ' + sv.TenSV as hovaten,sv.NgaySinh,TenLop
	from PHIEUTHU, NHANVIEN nv, LYDOTHU,SINHVIEN sv,LOP 
	where PHIEUTHU.MaNV=nv.MaNV and LYDOTHU.MaLyDo=MaLyDoThu and PHIEUTHU.MaSV=sv.MaSV and sv.MaLop=LOP.MaLop
	and NgayThu between @FromDate and @ToDate and nv.MaNV=@manv
go
--lấy phần trăm miễn giảm theo sinh viên
Create proc GetPhantrammiengiam
	@masv char(10)
as
	select masv,HoSV+' ' + TenSV as Hovaten, Phantram ,TenMienGiam
	from SINHVIEN,MIENGIAM where SINHVIEN.MaMienGiam=MIENGIAM.MaMienGiam
	and MaSV=@masv
go
--lấy phiếu thu theo ID
Create proc GetPHIEUTHUBySOPHIEU
	@sophieu char(12)
as
	select * from PHIEUTHU where SOPHIEU=@sophieu
go
--báo cáo
Create proc ReportPhieuThu
	@Sophieu char(12)
as
	select SOPHIEU,NgayThu,TenLyDo,sv.MaSV, sv.HoSV+ ' ' + sv.TenSV as Hovaten,nv.HoNV+ ' ' + nv.TenNV as Nhanvienthu,
	TenLop, TenMienGiam,HocPhi,pt.MienGiam,ThucThu
	from PHIEUTHU pt, SINHVIEN sv,LOP l, MIENGIAM mg,LYDOTHU lt,NHANVIEN nv
	where pt.MaSV=sv.MaSV and pt.MaLyDoThu=lt.MaLyDo and pt.MaNV=nv.MaNV and sv.MaMienGiam=mg.MaMienGiam
	and sv.MaLop=l.Malop and SOPHIEU=@sophieu
go