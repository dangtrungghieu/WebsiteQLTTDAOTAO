using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebApplicationProject.Models
{
    public partial class FinalProject : DbContext
    {
        public FinalProject()
            : base("name=FinalProject")
        {
        }

        public virtual DbSet<CAHOC> CAHOC { get; set; }
        public virtual DbSet<CATHI> CATHI { get; set; }
        public virtual DbSet<CHAMCONG> CHAMCONG { get; set; }
        public virtual DbSet<DANGKY> DANGKY { get; set; }
        public virtual DbSet<DANHGIAKHOAHOC> DANHGIAKHOAHOC { get; set; }
        public virtual DbSet<DonXinNghi> DonXinNghi { get; set; }
        public virtual DbSet<HOCVIEN> HOCVIEN { get; set; }
        public virtual DbSet<KETQUA> KETQUA { get; set; }
        public virtual DbSet<KETQUAKHAOSAT> KETQUAKHAOSAT { get; set; }
        public virtual DbSet<KHAOSAT> KHAOSAT { get; set; }
        public virtual DbSet<KHOAHOC> KHOAHOC { get; set; }
        public virtual DbSet<LOAI> LOAI { get; set; }
        public virtual DbSet<LOAICATHI> LOAICATHI { get; set; }
        public virtual DbSet<LOAINHANVIEN> LOAINHANVIEN { get; set; }
        public virtual DbSet<LOAITHONGBAO> LOAITHONGBAO { get; set; }
        public virtual DbSet<LOP> LOP { get; set; }
        public virtual DbSet<LUONG> LUONG { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIEN { get; set; }
        public virtual DbSet<NHAPHANG> NHAPHANG { get; set; }
        public virtual DbSet<PHIEUTHU> PHIEUTHU { get; set; }
        public virtual DbSet<PHONGHOC> PHONGHOC { get; set; }
        public virtual DbSet<PHONGTHI> PHONGTHI { get; set; }
        public virtual DbSet<TAIKHOAN> TAIKHOAN { get; set; }
        public virtual DbSet<THONGBAO> THONGBAO { get; set; }
        public virtual DbSet<YEUCAUHOCVIEN> YEUCAUHOCVIEN { get; set; }
        public virtual DbSet<YEUCAUNHANVIEN> YEUCAUNHANVIEN { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CAHOC>()
                .HasMany(e => e.LOP)
                .WithOptional(e => e.CAHOC)
                .HasForeignKey(e => e.MaCaHoc_Lop);

            modelBuilder.Entity<CATHI>()
                .HasMany(e => e.PHONGTHI)
                .WithOptional(e => e.CATHI)
                .HasForeignKey(e => e.MaCaThi_PhongThi);

            modelBuilder.Entity<CHAMCONG>()
                .Property(e => e.TinhTrang)
                .IsUnicode(false);

            modelBuilder.Entity<HOCVIEN>()
                .Property(e => e.TenHocVien)
                .IsUnicode(false);

            modelBuilder.Entity<HOCVIEN>()
                .Property(e => e.GioiTinh)
                .IsUnicode(false);

            modelBuilder.Entity<HOCVIEN>()
                .HasMany(e => e.DANGKY)
                .WithOptional(e => e.HOCVIEN)
                .HasForeignKey(e => e.MaHocVien_DangKy);

            modelBuilder.Entity<HOCVIEN>()
                .HasMany(e => e.DANHGIAKHOAHOC)
                .WithOptional(e => e.HOCVIEN)
                .HasForeignKey(e => e.MaHocVien_DanhGiaKhoaHoc);

            modelBuilder.Entity<HOCVIEN>()
                .HasMany(e => e.DonXinNghi)
                .WithOptional(e => e.HOCVIEN)
                .HasForeignKey(e => e.MaHocVien_DonXinNghi);

            modelBuilder.Entity<HOCVIEN>()
                .HasMany(e => e.KETQUA)
                .WithOptional(e => e.HOCVIEN)
                .HasForeignKey(e => e.MaHocVien_KetQua);

            modelBuilder.Entity<HOCVIEN>()
                .HasMany(e => e.KETQUAKHAOSAT)
                .WithOptional(e => e.HOCVIEN)
                .HasForeignKey(e => e.MaHocVien_KetQuaKhaoSat);

            modelBuilder.Entity<HOCVIEN>()
                .HasMany(e => e.PHIEUTHU)
                .WithOptional(e => e.HOCVIEN)
                .HasForeignKey(e => e.MaHocVien_PhieuThu);

            modelBuilder.Entity<HOCVIEN>()
                .HasMany(e => e.YEUCAUHOCVIEN)
                .WithOptional(e => e.HOCVIEN)
                .HasForeignKey(e => e.MaHocVien_YeuCau);

            modelBuilder.Entity<KETQUA>()
                .Property(e => e.XepLoai)
                .IsUnicode(false);

            modelBuilder.Entity<KHAOSAT>()
                .HasMany(e => e.KETQUAKHAOSAT)
                .WithOptional(e => e.KHAOSAT)
                .HasForeignKey(e => e.MaKhaoSat_KetQuaKhaoSat);

            modelBuilder.Entity<KHOAHOC>()
                .HasMany(e => e.DANHGIAKHOAHOC)
                .WithOptional(e => e.KHOAHOC)
                .HasForeignKey(e => e.MaKhoaHoc_DanhGiaKhoaHoc);

            modelBuilder.Entity<KHOAHOC>()
                .HasMany(e => e.KETQUA)
                .WithOptional(e => e.KHOAHOC)
                .HasForeignKey(e => e.MaKhoaHoc_KetQua);

            modelBuilder.Entity<KHOAHOC>()
                .HasMany(e => e.LOP)
                .WithOptional(e => e.KHOAHOC)
                .HasForeignKey(e => e.MaKhoaHoc_Lop);

            modelBuilder.Entity<KHOAHOC>()
                .HasMany(e => e.PHIEUTHU)
                .WithOptional(e => e.KHOAHOC)
                .HasForeignKey(e => e.MaKhoaHoc_PhieuThu);

            modelBuilder.Entity<KHOAHOC>()
                .HasMany(e => e.PHONGTHI)
                .WithOptional(e => e.KHOAHOC)
                .HasForeignKey(e => e.MaKhoaHoc_PhongThi);

            modelBuilder.Entity<LOAI>()
                .HasMany(e => e.LOP)
                .WithOptional(e => e.LOAI)
                .HasForeignKey(e => e.MaLoaiLop_Lop);

            modelBuilder.Entity<LOAI>()
                .HasMany(e => e.PHONGHOC)
                .WithOptional(e => e.LOAI)
                .HasForeignKey(e => e.MaLoaiPhong_PhongHoc);

            modelBuilder.Entity<LOAICATHI>()
                .HasMany(e => e.CATHI)
                .WithOptional(e => e.LOAICATHI)
                .HasForeignKey(e => e.MaLoai_CaThi);

            modelBuilder.Entity<LOAINHANVIEN>()
                .Property(e => e.TenLoaiNhanVien)
                .IsUnicode(false);

            modelBuilder.Entity<LOAINHANVIEN>()
                .HasMany(e => e.NHANVIEN)
                .WithOptional(e => e.LOAINHANVIEN)
                .HasForeignKey(e => e.MaLoai_NhanVien);

            modelBuilder.Entity<LOAITHONGBAO>()
                .HasMany(e => e.THONGBAO)
                .WithOptional(e => e.LOAITHONGBAO)
                .HasForeignKey(e => e.MaLoaiThongBao_ThongBao);

            modelBuilder.Entity<LOP>()
                .HasMany(e => e.DANGKY)
                .WithOptional(e => e.LOP)
                .HasForeignKey(e => e.MaLopHoc_DangKy);

            modelBuilder.Entity<LOP>()
                .HasMany(e => e.DonXinNghi)
                .WithOptional(e => e.LOP)
                .HasForeignKey(e => e.MaLop_DonXinNghi);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.TenNhanVien)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.GioiTinh)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.HocVi)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.ChuyenNganh)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.DonViCapBang)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.CHAMCONG)
                .WithOptional(e => e.NHANVIEN)
                .HasForeignKey(e => e.MaNhanVien_ChamCong);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.KHAOSAT)
                .WithOptional(e => e.NHANVIEN)
                .HasForeignKey(e => e.MaNhanVien_KhaoSat);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.LOP)
                .WithOptional(e => e.NHANVIEN)
                .HasForeignKey(e => e.MaGiangVien_Lop);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.LUONG)
                .WithRequired(e => e.NHANVIEN)
                .HasForeignKey(e => e.MaNhanVien_Luong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.NHAPHANG)
                .WithOptional(e => e.NHANVIEN)
                .HasForeignKey(e => e.MaNhanVien_NhapHang);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.PHONGTHI)
                .WithOptional(e => e.NHANVIEN)
                .HasForeignKey(e => e.MaNhanVien_PhongThi);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.THONGBAO)
                .WithOptional(e => e.NHANVIEN)
                .HasForeignKey(e => e.MaNhanVien_ThongBao);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.YEUCAUNHANVIEN)
                .WithOptional(e => e.NHANVIEN)
                .HasForeignKey(e => e.MaNhanVien_YeuCauNhanVien);

            modelBuilder.Entity<PHONGHOC>()
                .Property(e => e.TinhTrang)
                .IsUnicode(false);

            modelBuilder.Entity<PHONGHOC>()
                .HasMany(e => e.LOP)
                .WithOptional(e => e.PHONGHOC)
                .HasForeignKey(e => e.MaPhongHoc_Lop);

            modelBuilder.Entity<PHONGHOC>()
                .HasMany(e => e.PHONGTHI)
                .WithOptional(e => e.PHONGHOC)
                .HasForeignKey(e => e.MaPhongHoc_PhongThi);

            modelBuilder.Entity<TAIKHOAN>()
                .HasMany(e => e.NHANVIEN)
                .WithOptional(e => e.TAIKHOAN)
                .HasForeignKey(e => e.MaTaiKhoan_NhanVien);

            modelBuilder.Entity<YEUCAUHOCVIEN>()
                .Property(e => e.TinhTrang)
                .IsUnicode(false);
        }
    }
}
