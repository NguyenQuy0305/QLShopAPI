create database QLCuaHang;
use QLCuaHang;
--Tạo bảng
CREATE TABLE KHACHHANG (
	MaKH int identity primary key,
	TenKH nvarchar(20),
	SDTKH char(10),
);

create table KHUYENMAI (
	MaKM int IDENTITY primary key,
	TenKM char(6),
	ChiTietKM nvarchar(50),
	Sotien int
);

create table DANHMUC (
	MaDM int IDENTITY primary key,
	TenDM nvarchar(20)
);

create table SANPHAM (
	MaSP int IDENTITY primary key,
	TenSP nvarchar(30),
	GiaSP int,
	MaDM int foreign key references DANHMUC (MaDM),
	SL int,
	Hinh nvarchar(200)
);

create table DONHANG(
	MaDH int IDENTITY primary key,
	MaKH int foreign key references KHACHHANG (MaKH),
	TongTien int default 0,
	TinhTrang nvarchar(20) default N'Chưa Giao',
	TienKM int default 0
);

create table CTDH(
	MaDH int foreign key references DONHANG (MaDH),
	MaSP int foreign key references SANPHAM (MaSP),
	Primary key (MaDH, MaSP)
);




--Thêm dữ liệu vào các bảng
insert into KHACHHANG values (N'Nguyễn Thành Công', '0123456789');
insert into KHACHHANG values (N'Nguyễn Thịnh', '0156487956');
insert into KHACHHANG values (N'Nguyễn Thành', '0123456789');

insert into KHUYENMAI values ('KM01', N'Khuyến mãi khách lâu năm', 20000);
insert into KHUYENMAI values ('KM02', N'Khuyến mãi khách hàng mua hàng thường xuyên', 10000);
insert into KHUYENMAI values ('KM03',N'Khuyến mãi khách hàng vip', 20000);



insert into DONHANG (MaKH) values ('17');

insert into DANHMUC values (N'Hoa Quả');
insert into DANHMUC values (N'Trái cây');
insert into DANHMUC values (N'Rau củ');
insert into DANHMUC values (N'Gia vị');



insert into SANPHAM values (N'Dưa hấu', 15000, 2, 10, 'dua_hau.jpg');
insert into SANPHAM values (N'Dưa leo', 30000, 2, 15, 'dua_leo.jpg');
insert into SANPHAM values (N'Dưa lưới', 12000, 2, 9, 'dua_luoi.jpg');

insert into SANPHAM values (N'Xà lách', 14000, 3, 5, 'xa_lach.jpg');
insert into SANPHAM values (N'Rau muống', 23000, 3, 7, 'rau_muong.jpg');
insert into SANPHAM values (N'Cải ngọt', 12000, 3, 9, 'cai_ngot.jpg');

insert into SANPHAM values (N'Nước mắm', 30000, 4, 5, 'nuoc_mam.jpg');
insert into SANPHAM values (N'Đường', 21000, 4, 7, 'duong.jpg');
insert into SANPHAM values (N'Bột ngọt', 15000, 4, 9, 'bot_ngot.jpg');


insert into CTDH values (47, 1)


--TẠO CÁC PROCEDURE CHO WEBAPI

--Procedure Cập nhật khách hàng
create procedure CapNhatKhachHang(@makh int, @tenkh nvarchar(20), @sdtkh char(10),@CurrentID int output)
as
begin try
update KHACHHANG
set TenKH=@tenkh, SDTKH = @sdtkh
where MaKH = @makh
set @CurrentID=@makh
end try
begin catch
set @CurrentID = 0
end catch

--Procedure Xóa Khách Hàng
create procedure XoaKhachHang(@makh int, @CurrentID int output)
as
begin try
delete KHACHHANG where MaKH = @makh
set @CurrentID=@makh
end try
begin catch
set @CurrentID = 0
end catch


--Procedure lấy doanh thu và số lượng đơn đã giao
go
create proc LayDoanhThuVaSLDHDG
as
begin
	select sum(TongTien) as DoanhThu, COUNT(MaDH) as SoDon from DONHANG where TinhTrang = N'Đã giao'
end

exec LayDoanhThuVaSLDHDG

select * from DONHANG
--Procedure cập nhật tình trạng giao hàng
go;
create proc CapNhatTinhTrangGiaoHang(@madh int, @CurrentID int output)
as
begin try
update DONHANG
set TinhTrang = N'Đã giao'
where MaDH = @madh
set @CurrentID=1
end try
begin catch
set @CurrentID=0
end catch


--Procedure cập nhật số tiền khuyến mãi
go
alter proc CapNhatTienKM(@tienkm int, @madh int , @CurrentID int output)
as
begin try
update DONHANG
set TienKM = @tienkm, TongTien = TongTien - @tienkm
where MaDH = @madh
set @CurrentID=1
end try
begin catch
set @CurrentID = 0
end catch
go;

declare @x int
exec CapNhatTienKM 5000, 32, @CurrentID = @x output
select @x

select * from DONHANG

--Procedure lấy đơn hàng mới tạo
GO
create proc LayDonHangMoi
as select top 1 * from DONHANG order by MaDH DESC
go;

--Procedure Lấy danh sách sản phẩm
alter procedure LayDSSanPham
as
select MaSP
      ,TenSP
      ,GiaSP
      ,MaDM
	  ,SL
      ,Hinh from SANPHAM
go;

--Procedure Thêm CTDH
create procedure ThemCTDH(@madh int, @masp int, @CurrentID int output)
as
begin try
insert into CTDH values (@madh, @masp)
set @CurrentID=1
end try
begin catch
set @CurrentID = 0
end catch
go;


--Procedure Thêm đơn hàng
create procedure ThemDonHang(@makh int, @CurrentID int output)
as
begin try
insert into DONHANG (MaKH) values (@makh)
set @CurrentID=@@IDENTITY
end try
begin catch
set @CurrentID = 0
end catch
go;


--Procedure lấy thông tin khách hàng
create procedure laythongtinkh
as
select * from KHACHHANG
GO;


--Procedure Thêm 1 khách hàng
create procedure ThemKhachHang(@tenkh nvarchar(20), @sdtkh char(10), @CurrentID int output)
as
begin try
insert into KHACHHANG values (@tenkh, @sdtkh)
set @CurrentID=@@IDENTITY
end try
begin catch
set @CurrentID = 0
end catch
go;



--Procedure lấy thông tin khuyến mãi khuyến mãi
create procedure laythongtinkm
as
select * from KHUYENMAI
GO;

--Procedure Thêm khuyến mãi
create proc Them_Khuyen_Mai_Nh(@tenkm nvarchar(200),@chitietkm nvarchar(50),@sotien money, @CurrentID int output)
as
begin try
insert into KHUYENMAI values(@tenkm, @chitietkm, @sotien)
set @CurrentID=@@IDENTITY
end try
begin catch
set @CurrentID=0
end catch
go;

--Procedure lấy khuyến mãi theo mã khuyến mãi
CREATE proc Laykmtheomakm(@makm int)
as
select MaKM
      ,TenKM
      ,ChiTietKM
      ,SoTien
from KHUYENMAI
where MaKM=@makm 

--Procedure Xóa khuyến mãi
create procedure XoaKM(@makm int, @CurrentID int output)
as
begin try
delete KHUYENMAI where MaKM = @makm
set @CurrentID=@makm
end try
begin catch
set @CurrentID = 0
end catch
go;

--Procedure cập nhật khuyến mãi
create procedure CapNhatKM(@makm int, @tenkm char(6), @chitietkm nvarchar(50), @sotien money,@CurrentID int output)
as
begin try
update KHUYENMAI 
	set TenKM=@tenkm, ChiTietKM=@chitietkm, SoTien = @sotien
	where MaKM = @makm
set @CurrentID=@makm
end try
begin catch
set @CurrentID = 0
end catch

--Procedure lấy thông tin danh mục
create procedure laythongtindm
as
select * from DANHMUC
GO;

--Procedure lấy sản phẩm theo danh mục
alter proc LaySPtheoDMuc(@madm int)
as
select MaSP
      ,TenSP
      ,GiaSP
      ,MaDM
	  ,SL
      ,Hinh
from SANPHAM
where MaDM=@madm

--Procedure cập nhật sản phẩm
create procedure CapNhatSanPham(@masp int, @tensp nvarchar(30), @giasp money, @sl int,@CurrentID int output)
as
begin try
update SANPHAM 
	set TenSP=@tensp, GiaSP = @giasp, SL = @sl
	where MaSP = @masp
set @CurrentID=@masp
end try
begin catch
set @CurrentID = 0
end catch

--Procedure lấy thông tin đơn hàng
create procedure LayThongTinDonHang
as
select * from DONHANG

--Tạo Trigger
--Trigger cập nhập số tiền khi thêm 1 CTHD
go
create trigger tinhtienhoadon
ON CTDH
after insert
as
begin
	declare @tienhang money
	declare @madh int
	select @tienhang = A.GiaSP from SANPHAM A join inserted B on A.MaSP = B.MaSP
	select @madh = MaDH from inserted
	update DONHANG
	set TongTien = TongTien + @tienhang
	where MaDH = @madh
end
go

--Trigger cập nhật số lượng sản phẩm (sau khi thêm sản phẩm vào đơn hàng)
go
create trigger CapNhatSLSP
ON CTDH
for insert
as
begin
	declare @masp int
	select @masp = MaSP from inserted
	UPDATE SANPHAM
	set SL = SL - 1
	where MaSP = @masp
end

