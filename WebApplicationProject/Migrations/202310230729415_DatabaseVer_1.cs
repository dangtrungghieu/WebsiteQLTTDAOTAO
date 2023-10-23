namespace WebApplicationProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseVer_1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CAHOC",
                c => new
                    {
                        MaCaHoc = c.Int(nullable: false, identity: true),
                        TenCaHoc = c.String(nullable: false, maxLength: 20),
                        ThoiGianBatDau = c.Time(nullable: false, precision: 7),
                        ThoiGianKetThuc = c.Time(nullable: false, precision: 7),
                        NgayHocTrongTuan = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.MaCaHoc);
            
            CreateTable(
                "dbo.LOP",
                c => new
                    {
                        MaLop = c.Int(nullable: false, identity: true),
                        TenLop = c.String(nullable: false, maxLength: 30),
                        NgayKhaiGiang = c.DateTime(nullable: false, storeType: "date"),
                        NgayKetThuc = c.DateTime(nullable: false, storeType: "date"),
                        MaKhoaHoc_Lop = c.Int(),
                        MaPhongHoc_Lop = c.Int(),
                        MaCaHoc_Lop = c.Int(),
                        MaGiangVien_Lop = c.Int(),
                        MaLoaiLop_Lop = c.Int(),
                    })
                .PrimaryKey(t => t.MaLop)
                .ForeignKey("dbo.KHOAHOC", t => t.MaKhoaHoc_Lop)
                .ForeignKey("dbo.NHANVIEN", t => t.MaGiangVien_Lop)
                .ForeignKey("dbo.LOAI", t => t.MaLoaiLop_Lop)
                .ForeignKey("dbo.PHONGHOC", t => t.MaPhongHoc_Lop)
                .ForeignKey("dbo.CAHOC", t => t.MaCaHoc_Lop)
                .Index(t => t.MaKhoaHoc_Lop)
                .Index(t => t.MaPhongHoc_Lop)
                .Index(t => t.MaCaHoc_Lop)
                .Index(t => t.MaGiangVien_Lop)
                .Index(t => t.MaLoaiLop_Lop);
            
            CreateTable(
                "dbo.DANGKY",
                c => new
                    {
                        MaDangKy = c.Int(nullable: false, identity: true),
                        NgayDangKy = c.DateTime(nullable: false, storeType: "date"),
                        LePhi = c.Int(nullable: false),
                        TinhTrang = c.String(maxLength: 20),
                        MaLopHoc_DangKy = c.Int(),
                        MaHocVien_DangKy = c.Int(),
                    })
                .PrimaryKey(t => t.MaDangKy)
                .ForeignKey("dbo.HOCVIEN", t => t.MaHocVien_DangKy)
                .ForeignKey("dbo.LOP", t => t.MaLopHoc_DangKy)
                .Index(t => t.MaLopHoc_DangKy)
                .Index(t => t.MaHocVien_DangKy);
            
            CreateTable(
                "dbo.HOCVIEN",
                c => new
                    {
                        MaHocVien = c.Int(nullable: false, identity: true),
                        TenHocVien = c.String(nullable: false, maxLength: 50, unicode: false),
                        GioiTinh = c.String(nullable: false, maxLength: 5, unicode: false),
                        NgaySinh = c.DateTime(nullable: false, storeType: "date"),
                        DiaChi = c.String(maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 100),
                        MaTaiKhoan_HocVien = c.Int(),
                        MaLop_HocVien = c.Int(),
                        AnhDaiDien = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.MaHocVien);
            
            CreateTable(
                "dbo.DANHGIAKHOAHOC",
                c => new
                    {
                        MaDanhGiaKhoaHoc = c.Int(nullable: false, identity: true),
                        NoiDung = c.String(nullable: false, maxLength: 100),
                        NgayDanhGia = c.DateTime(nullable: false, storeType: "date"),
                        MaHocVien_DanhGiaKhoaHoc = c.Int(),
                        MaKhoaHoc_DanhGiaKhoaHoc = c.Int(),
                    })
                .PrimaryKey(t => t.MaDanhGiaKhoaHoc)
                .ForeignKey("dbo.KHOAHOC", t => t.MaKhoaHoc_DanhGiaKhoaHoc)
                .ForeignKey("dbo.HOCVIEN", t => t.MaHocVien_DanhGiaKhoaHoc)
                .Index(t => t.MaHocVien_DanhGiaKhoaHoc)
                .Index(t => t.MaKhoaHoc_DanhGiaKhoaHoc);
            
            CreateTable(
                "dbo.KHOAHOC",
                c => new
                    {
                        MaKhoaHoc = c.Int(nullable: false, identity: true),
                        TenKhoaHoc = c.String(nullable: false, maxLength: 50),
                        MoTa = c.String(nullable: false, maxLength: 100),
                        LePhi = c.Int(),
                        AnhKhoaHoc = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.MaKhoaHoc);
            
            CreateTable(
                "dbo.KETQUA",
                c => new
                    {
                        MaKetQua = c.Int(nullable: false, identity: true),
                        DiemSo = c.Double(nullable: false),
                        XepLoai = c.String(nullable: false, maxLength: 20, unicode: false),
                        MaHocVien_KetQua = c.Int(),
                        MaKhoaHoc_KetQua = c.Int(),
                    })
                .PrimaryKey(t => t.MaKetQua)
                .ForeignKey("dbo.KHOAHOC", t => t.MaKhoaHoc_KetQua)
                .ForeignKey("dbo.HOCVIEN", t => t.MaHocVien_KetQua)
                .Index(t => t.MaHocVien_KetQua)
                .Index(t => t.MaKhoaHoc_KetQua);
            
            CreateTable(
                "dbo.PHIEUTHU",
                c => new
                    {
                        MaPhieuThu = c.Int(nullable: false, identity: true),
                        SoTien = c.Int(nullable: false),
                        NgayThu = c.DateTime(nullable: false, storeType: "date"),
                        MaHocVien_PhieuThu = c.Int(),
                        MaKhoaHoc_PhieuThu = c.Int(),
                    })
                .PrimaryKey(t => t.MaPhieuThu)
                .ForeignKey("dbo.KHOAHOC", t => t.MaKhoaHoc_PhieuThu)
                .ForeignKey("dbo.HOCVIEN", t => t.MaHocVien_PhieuThu)
                .Index(t => t.MaHocVien_PhieuThu)
                .Index(t => t.MaKhoaHoc_PhieuThu);
            
            CreateTable(
                "dbo.PHONGTHI",
                c => new
                    {
                        MaPhongThi = c.Int(nullable: false, identity: true),
                        SoLuong = c.Int(nullable: false),
                        NgayThi = c.DateTime(nullable: false, storeType: "date"),
                        MaNhanVien_PhongThi = c.Int(),
                        MaPhongHoc_PhongThi = c.Int(),
                        MaCaThi_PhongThi = c.Int(),
                        MaKhoaHoc_PhongThi = c.Int(),
                    })
                .PrimaryKey(t => t.MaPhongThi)
                .ForeignKey("dbo.CATHI", t => t.MaCaThi_PhongThi)
                .ForeignKey("dbo.NHANVIEN", t => t.MaNhanVien_PhongThi)
                .ForeignKey("dbo.PHONGHOC", t => t.MaPhongHoc_PhongThi)
                .ForeignKey("dbo.KHOAHOC", t => t.MaKhoaHoc_PhongThi)
                .Index(t => t.MaNhanVien_PhongThi)
                .Index(t => t.MaPhongHoc_PhongThi)
                .Index(t => t.MaCaThi_PhongThi)
                .Index(t => t.MaKhoaHoc_PhongThi);
            
            CreateTable(
                "dbo.CATHI",
                c => new
                    {
                        MaCaThi = c.Int(nullable: false, identity: true),
                        TenCaThi = c.String(nullable: false, maxLength: 20),
                        GioThi = c.Time(nullable: false, precision: 7),
                        GioTapTrung = c.Time(nullable: false, precision: 7),
                        MaLoai_CaThi = c.Int(),
                    })
                .PrimaryKey(t => t.MaCaThi)
                .ForeignKey("dbo.LOAICATHI", t => t.MaLoai_CaThi)
                .Index(t => t.MaLoai_CaThi);
            
            CreateTable(
                "dbo.LOAICATHI",
                c => new
                    {
                        MaLoaiCaThi = c.Int(nullable: false, identity: true),
                        TenLoaiCaThi = c.String(maxLength: 25),
                    })
                .PrimaryKey(t => t.MaLoaiCaThi);
            
            CreateTable(
                "dbo.NHANVIEN",
                c => new
                    {
                        MaNhanVien = c.Int(nullable: false, identity: true),
                        TenNhanVien = c.String(nullable: false, maxLength: 50, unicode: false),
                        GioiTinh = c.String(nullable: false, maxLength: 5, unicode: false),
                        NgaySinh = c.DateTime(nullable: false, storeType: "date"),
                        HocVi = c.String(maxLength: 50, unicode: false),
                        ChuyenNganh = c.String(maxLength: 50, unicode: false),
                        DonViCapBang = c.String(maxLength: 50, unicode: false),
                        DiaChi = c.String(maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 100),
                        MaTaiKhoan_NhanVien = c.Int(),
                        MaLoai_NhanVien = c.Int(),
                        AnhDaiDien = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.MaNhanVien)
                .ForeignKey("dbo.LOAINHANVIEN", t => t.MaLoai_NhanVien)
                .ForeignKey("dbo.TAIKHOAN", t => t.MaTaiKhoan_NhanVien)
                .Index(t => t.MaTaiKhoan_NhanVien)
                .Index(t => t.MaLoai_NhanVien);
            
            CreateTable(
                "dbo.CHAMCONG",
                c => new
                    {
                        MaChamCong = c.Int(nullable: false, identity: true),
                        NgayChamCong = c.DateTime(nullable: false, storeType: "date"),
                        TinhTrang = c.String(maxLength: 20, unicode: false),
                        MaNhanVien_ChamCong = c.Int(),
                    })
                .PrimaryKey(t => t.MaChamCong)
                .ForeignKey("dbo.NHANVIEN", t => t.MaNhanVien_ChamCong)
                .Index(t => t.MaNhanVien_ChamCong);
            
            CreateTable(
                "dbo.KHAOSAT",
                c => new
                    {
                        MaKhaoSat = c.Int(nullable: false, identity: true),
                        TenKhaoSat = c.String(nullable: false, maxLength: 50),
                        NoiDung = c.String(nullable: false, maxLength: 100),
                        NgayTaoKhaoSat = c.DateTime(nullable: false, storeType: "date"),
                        NgayKetThucKhaoSat = c.DateTime(nullable: false, storeType: "date"),
                        MaNhanVien_KhaoSat = c.Int(),
                    })
                .PrimaryKey(t => t.MaKhaoSat)
                .ForeignKey("dbo.NHANVIEN", t => t.MaNhanVien_KhaoSat)
                .Index(t => t.MaNhanVien_KhaoSat);
            
            CreateTable(
                "dbo.KETQUAKHAOSAT",
                c => new
                    {
                        MaKetQuaKhaoSat = c.Int(nullable: false, identity: true),
                        NoiDung = c.String(nullable: false, maxLength: 100),
                        NgayLamKhaoSat = c.DateTime(nullable: false, storeType: "date"),
                        MaHocVien_KetQuaKhaoSat = c.Int(),
                        MaKhaoSat_KetQuaKhaoSat = c.Int(),
                    })
                .PrimaryKey(t => t.MaKetQuaKhaoSat)
                .ForeignKey("dbo.KHAOSAT", t => t.MaKhaoSat_KetQuaKhaoSat)
                .ForeignKey("dbo.HOCVIEN", t => t.MaHocVien_KetQuaKhaoSat)
                .Index(t => t.MaHocVien_KetQuaKhaoSat)
                .Index(t => t.MaKhaoSat_KetQuaKhaoSat);
            
            CreateTable(
                "dbo.LOAINHANVIEN",
                c => new
                    {
                        MaLoaiNhanVien = c.Int(nullable: false, identity: true),
                        TenLoaiNhanVien = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.MaLoaiNhanVien);
            
            CreateTable(
                "dbo.LUONG",
                c => new
                    {
                        MaLuong = c.Int(nullable: false, identity: true),
                        SoNgayCong = c.Int(nullable: false),
                        TienBaoHiem = c.Int(nullable: false),
                        TienThuong = c.Int(nullable: false),
                        NgayLap = c.DateTime(nullable: false, storeType: "date"),
                        MaNhanVien_Luong = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaLuong)
                .ForeignKey("dbo.NHANVIEN", t => t.MaNhanVien_Luong)
                .Index(t => t.MaNhanVien_Luong);
            
            CreateTable(
                "dbo.NHAPHANG",
                c => new
                    {
                        MaNhapHang = c.Int(nullable: false, identity: true),
                        LoaiVatTu = c.String(nullable: false, maxLength: 30),
                        SoLuong = c.Int(nullable: false),
                        DonGia = c.Int(nullable: false),
                        NgayNhap = c.DateTime(nullable: false, storeType: "date"),
                        MaNhanVien_NhapHang = c.Int(),
                    })
                .PrimaryKey(t => t.MaNhapHang)
                .ForeignKey("dbo.NHANVIEN", t => t.MaNhanVien_NhapHang)
                .Index(t => t.MaNhanVien_NhapHang);
            
            CreateTable(
                "dbo.TAIKHOAN",
                c => new
                    {
                        MaTaiKhoan = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 50),
                        PassWord = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.MaTaiKhoan);
            
            CreateTable(
                "dbo.THONGBAO",
                c => new
                    {
                        MaThongBao = c.Int(nullable: false, identity: true),
                        NoiDung = c.String(nullable: false, maxLength: 100),
                        NguoiNhan = c.String(nullable: false, maxLength: 20),
                        NgayGui = c.DateTime(nullable: false, storeType: "date"),
                        MaNhanVien_ThongBao = c.Int(),
                        MaLoaiThongBao_ThongBao = c.Int(),
                    })
                .PrimaryKey(t => t.MaThongBao)
                .ForeignKey("dbo.LOAITHONGBAO", t => t.MaLoaiThongBao_ThongBao)
                .ForeignKey("dbo.NHANVIEN", t => t.MaNhanVien_ThongBao)
                .Index(t => t.MaNhanVien_ThongBao)
                .Index(t => t.MaLoaiThongBao_ThongBao);
            
            CreateTable(
                "dbo.LOAITHONGBAO",
                c => new
                    {
                        MaLoaiThongBao = c.Int(nullable: false, identity: true),
                        TenLoaiThongBao = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.MaLoaiThongBao);
            
            CreateTable(
                "dbo.YEUCAUNHANVIEN",
                c => new
                    {
                        MaYeuCauNhanVien = c.Int(nullable: false, identity: true),
                        TenYeuCauNhanVien = c.String(nullable: false, maxLength: 100),
                        NoiDung = c.String(nullable: false, maxLength: 100),
                        TinhTrang = c.String(maxLength: 20),
                        MaNhanVien_YeuCauNhanVien = c.Int(),
                    })
                .PrimaryKey(t => t.MaYeuCauNhanVien)
                .ForeignKey("dbo.NHANVIEN", t => t.MaNhanVien_YeuCauNhanVien)
                .Index(t => t.MaNhanVien_YeuCauNhanVien);
            
            CreateTable(
                "dbo.PHONGHOC",
                c => new
                    {
                        MaPhongHoc = c.Int(nullable: false, identity: true),
                        TenPhongHoc = c.String(nullable: false, maxLength: 20),
                        SucChua = c.Int(nullable: false),
                        TinhTrang = c.String(nullable: false, maxLength: 20, unicode: false),
                        MaLoaiPhong_PhongHoc = c.Int(),
                    })
                .PrimaryKey(t => t.MaPhongHoc)
                .ForeignKey("dbo.LOAI", t => t.MaLoaiPhong_PhongHoc)
                .Index(t => t.MaLoaiPhong_PhongHoc);
            
            CreateTable(
                "dbo.LOAI",
                c => new
                    {
                        MaLoai = c.Int(nullable: false, identity: true),
                        TenLoai = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.MaLoai);
            
            CreateTable(
                "dbo.DonXinNghi",
                c => new
                    {
                        MaDonXinNghi = c.Int(nullable: false, identity: true),
                        LyDo = c.String(nullable: false, maxLength: 200),
                        NgayXinNghi = c.DateTime(nullable: false, storeType: "date"),
                        MinhChung = c.String(nullable: false, maxLength: 50),
                        TinhTrang = c.String(maxLength: 20),
                        MaHocVien_DonXinNghi = c.Int(),
                        MaLop_DonXinNghi = c.Int(),
                    })
                .PrimaryKey(t => t.MaDonXinNghi)
                .ForeignKey("dbo.HOCVIEN", t => t.MaHocVien_DonXinNghi)
                .ForeignKey("dbo.LOP", t => t.MaLop_DonXinNghi)
                .Index(t => t.MaHocVien_DonXinNghi)
                .Index(t => t.MaLop_DonXinNghi);
            
            CreateTable(
                "dbo.YEUCAUHOCVIEN",
                c => new
                    {
                        MaYeuCau = c.Int(nullable: false, identity: true),
                        TenYeuCau = c.String(nullable: false, maxLength: 50),
                        NoiDungYeuCau = c.String(nullable: false, maxLength: 100),
                        NgayYeuCau = c.DateTime(nullable: false, storeType: "date"),
                        TinhTrang = c.String(maxLength: 20, unicode: false),
                        MaHocVien_YeuCau = c.Int(),
                    })
                .PrimaryKey(t => t.MaYeuCau)
                .ForeignKey("dbo.HOCVIEN", t => t.MaHocVien_YeuCau)
                .Index(t => t.MaHocVien_YeuCau);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LOP", "MaCaHoc_Lop", "dbo.CAHOC");
            DropForeignKey("dbo.DonXinNghi", "MaLop_DonXinNghi", "dbo.LOP");
            DropForeignKey("dbo.DANGKY", "MaLopHoc_DangKy", "dbo.LOP");
            DropForeignKey("dbo.YEUCAUHOCVIEN", "MaHocVien_YeuCau", "dbo.HOCVIEN");
            DropForeignKey("dbo.PHIEUTHU", "MaHocVien_PhieuThu", "dbo.HOCVIEN");
            DropForeignKey("dbo.KETQUAKHAOSAT", "MaHocVien_KetQuaKhaoSat", "dbo.HOCVIEN");
            DropForeignKey("dbo.KETQUA", "MaHocVien_KetQua", "dbo.HOCVIEN");
            DropForeignKey("dbo.DonXinNghi", "MaHocVien_DonXinNghi", "dbo.HOCVIEN");
            DropForeignKey("dbo.DANHGIAKHOAHOC", "MaHocVien_DanhGiaKhoaHoc", "dbo.HOCVIEN");
            DropForeignKey("dbo.PHONGTHI", "MaKhoaHoc_PhongThi", "dbo.KHOAHOC");
            DropForeignKey("dbo.PHONGTHI", "MaPhongHoc_PhongThi", "dbo.PHONGHOC");
            DropForeignKey("dbo.LOP", "MaPhongHoc_Lop", "dbo.PHONGHOC");
            DropForeignKey("dbo.PHONGHOC", "MaLoaiPhong_PhongHoc", "dbo.LOAI");
            DropForeignKey("dbo.LOP", "MaLoaiLop_Lop", "dbo.LOAI");
            DropForeignKey("dbo.YEUCAUNHANVIEN", "MaNhanVien_YeuCauNhanVien", "dbo.NHANVIEN");
            DropForeignKey("dbo.THONGBAO", "MaNhanVien_ThongBao", "dbo.NHANVIEN");
            DropForeignKey("dbo.THONGBAO", "MaLoaiThongBao_ThongBao", "dbo.LOAITHONGBAO");
            DropForeignKey("dbo.NHANVIEN", "MaTaiKhoan_NhanVien", "dbo.TAIKHOAN");
            DropForeignKey("dbo.PHONGTHI", "MaNhanVien_PhongThi", "dbo.NHANVIEN");
            DropForeignKey("dbo.NHAPHANG", "MaNhanVien_NhapHang", "dbo.NHANVIEN");
            DropForeignKey("dbo.LUONG", "MaNhanVien_Luong", "dbo.NHANVIEN");
            DropForeignKey("dbo.LOP", "MaGiangVien_Lop", "dbo.NHANVIEN");
            DropForeignKey("dbo.NHANVIEN", "MaLoai_NhanVien", "dbo.LOAINHANVIEN");
            DropForeignKey("dbo.KHAOSAT", "MaNhanVien_KhaoSat", "dbo.NHANVIEN");
            DropForeignKey("dbo.KETQUAKHAOSAT", "MaKhaoSat_KetQuaKhaoSat", "dbo.KHAOSAT");
            DropForeignKey("dbo.CHAMCONG", "MaNhanVien_ChamCong", "dbo.NHANVIEN");
            DropForeignKey("dbo.PHONGTHI", "MaCaThi_PhongThi", "dbo.CATHI");
            DropForeignKey("dbo.CATHI", "MaLoai_CaThi", "dbo.LOAICATHI");
            DropForeignKey("dbo.PHIEUTHU", "MaKhoaHoc_PhieuThu", "dbo.KHOAHOC");
            DropForeignKey("dbo.LOP", "MaKhoaHoc_Lop", "dbo.KHOAHOC");
            DropForeignKey("dbo.KETQUA", "MaKhoaHoc_KetQua", "dbo.KHOAHOC");
            DropForeignKey("dbo.DANHGIAKHOAHOC", "MaKhoaHoc_DanhGiaKhoaHoc", "dbo.KHOAHOC");
            DropForeignKey("dbo.DANGKY", "MaHocVien_DangKy", "dbo.HOCVIEN");
            DropIndex("dbo.YEUCAUHOCVIEN", new[] { "MaHocVien_YeuCau" });
            DropIndex("dbo.DonXinNghi", new[] { "MaLop_DonXinNghi" });
            DropIndex("dbo.DonXinNghi", new[] { "MaHocVien_DonXinNghi" });
            DropIndex("dbo.PHONGHOC", new[] { "MaLoaiPhong_PhongHoc" });
            DropIndex("dbo.YEUCAUNHANVIEN", new[] { "MaNhanVien_YeuCauNhanVien" });
            DropIndex("dbo.THONGBAO", new[] { "MaLoaiThongBao_ThongBao" });
            DropIndex("dbo.THONGBAO", new[] { "MaNhanVien_ThongBao" });
            DropIndex("dbo.NHAPHANG", new[] { "MaNhanVien_NhapHang" });
            DropIndex("dbo.LUONG", new[] { "MaNhanVien_Luong" });
            DropIndex("dbo.KETQUAKHAOSAT", new[] { "MaKhaoSat_KetQuaKhaoSat" });
            DropIndex("dbo.KETQUAKHAOSAT", new[] { "MaHocVien_KetQuaKhaoSat" });
            DropIndex("dbo.KHAOSAT", new[] { "MaNhanVien_KhaoSat" });
            DropIndex("dbo.CHAMCONG", new[] { "MaNhanVien_ChamCong" });
            DropIndex("dbo.NHANVIEN", new[] { "MaLoai_NhanVien" });
            DropIndex("dbo.NHANVIEN", new[] { "MaTaiKhoan_NhanVien" });
            DropIndex("dbo.CATHI", new[] { "MaLoai_CaThi" });
            DropIndex("dbo.PHONGTHI", new[] { "MaKhoaHoc_PhongThi" });
            DropIndex("dbo.PHONGTHI", new[] { "MaCaThi_PhongThi" });
            DropIndex("dbo.PHONGTHI", new[] { "MaPhongHoc_PhongThi" });
            DropIndex("dbo.PHONGTHI", new[] { "MaNhanVien_PhongThi" });
            DropIndex("dbo.PHIEUTHU", new[] { "MaKhoaHoc_PhieuThu" });
            DropIndex("dbo.PHIEUTHU", new[] { "MaHocVien_PhieuThu" });
            DropIndex("dbo.KETQUA", new[] { "MaKhoaHoc_KetQua" });
            DropIndex("dbo.KETQUA", new[] { "MaHocVien_KetQua" });
            DropIndex("dbo.DANHGIAKHOAHOC", new[] { "MaKhoaHoc_DanhGiaKhoaHoc" });
            DropIndex("dbo.DANHGIAKHOAHOC", new[] { "MaHocVien_DanhGiaKhoaHoc" });
            DropIndex("dbo.DANGKY", new[] { "MaHocVien_DangKy" });
            DropIndex("dbo.DANGKY", new[] { "MaLopHoc_DangKy" });
            DropIndex("dbo.LOP", new[] { "MaLoaiLop_Lop" });
            DropIndex("dbo.LOP", new[] { "MaGiangVien_Lop" });
            DropIndex("dbo.LOP", new[] { "MaCaHoc_Lop" });
            DropIndex("dbo.LOP", new[] { "MaPhongHoc_Lop" });
            DropIndex("dbo.LOP", new[] { "MaKhoaHoc_Lop" });
            DropTable("dbo.YEUCAUHOCVIEN");
            DropTable("dbo.DonXinNghi");
            DropTable("dbo.LOAI");
            DropTable("dbo.PHONGHOC");
            DropTable("dbo.YEUCAUNHANVIEN");
            DropTable("dbo.LOAITHONGBAO");
            DropTable("dbo.THONGBAO");
            DropTable("dbo.TAIKHOAN");
            DropTable("dbo.NHAPHANG");
            DropTable("dbo.LUONG");
            DropTable("dbo.LOAINHANVIEN");
            DropTable("dbo.KETQUAKHAOSAT");
            DropTable("dbo.KHAOSAT");
            DropTable("dbo.CHAMCONG");
            DropTable("dbo.NHANVIEN");
            DropTable("dbo.LOAICATHI");
            DropTable("dbo.CATHI");
            DropTable("dbo.PHONGTHI");
            DropTable("dbo.PHIEUTHU");
            DropTable("dbo.KETQUA");
            DropTable("dbo.KHOAHOC");
            DropTable("dbo.DANHGIAKHOAHOC");
            DropTable("dbo.HOCVIEN");
            DropTable("dbo.DANGKY");
            DropTable("dbo.LOP");
            DropTable("dbo.CAHOC");
        }
    }
}
