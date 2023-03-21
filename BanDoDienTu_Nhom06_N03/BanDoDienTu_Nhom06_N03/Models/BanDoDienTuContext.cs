using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BanDoDienTu_Nhom06_N03.Models;

public partial class BanDoDienTuContext : DbContext
{
    public BanDoDienTuContext()
    {
    }

    public BanDoDienTuContext(DbContextOptions<BanDoDienTuContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChiTietHdb> ChiTietHdbs { get; set; }

    public virtual DbSet<ChiTietHdn> ChiTietHdns { get; set; }

    public virtual DbSet<ChiTietSp> ChiTietSps { get; set; }

    public virtual DbSet<DangNhap> DangNhaps { get; set; }

    public virtual DbSet<DanhMuc> DanhMucs { get; set; }

    public virtual DbSet<HoaDonBan> HoaDonBans { get; set; }

    public virtual DbSet<HoaDonNhap> HoaDonNhaps { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<SanPham> SanPhams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=TIEN-CAU-GIAY;Initial Catalog=BanDoDienTu;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChiTietHdb>(entity =>
        {
            entity.HasKey(e => new { e.MaHdb, e.MaSp, e.MaDm }).HasName("PK__ChiTietH__81C59DFD451065A8");

            entity.ToTable("ChiTietHDB");

            entity.Property(e => e.MaHdb)
                .HasMaxLength(20)
                .HasColumnName("MaHDB");
            entity.Property(e => e.MaSp)
                .HasMaxLength(20)
                .HasColumnName("MaSP");
            entity.Property(e => e.MaDm)
                .HasMaxLength(20)
                .HasColumnName("MaDM");
            entity.Property(e => e.Slban)
                .HasDefaultValueSql("((0))")
                .HasColumnName("SLBan");

            entity.HasOne(d => d.MaHdbNavigation).WithMany(p => p.ChiTietHdbs)
                .HasForeignKey(d => d.MaHdb)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cthdb_hdb");

            entity.HasOne(d => d.Ma).WithMany(p => p.ChiTietHdbs)
                .HasForeignKey(d => new { d.MaSp, d.MaDm })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cthdb_sp");
        });

        modelBuilder.Entity<ChiTietHdn>(entity =>
        {
            entity.HasKey(e => new { e.MaHdn, e.MaSp, e.MaDm }).HasName("PK__ChiTietH__81C59DC10BD4CD48");

            entity.ToTable("ChiTietHDN");

            entity.Property(e => e.MaHdn)
                .HasMaxLength(20)
                .HasColumnName("MaHDN");
            entity.Property(e => e.MaSp)
                .HasMaxLength(20)
                .HasColumnName("MaSP");
            entity.Property(e => e.MaDm)
                .HasMaxLength(20)
                .HasColumnName("MaDM");
            entity.Property(e => e.Slnhap)
                .HasDefaultValueSql("((0))")
                .HasColumnName("SLNhap");

            entity.HasOne(d => d.MaHdnNavigation).WithMany(p => p.ChiTietHdns)
                .HasForeignKey(d => d.MaHdn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cthdn_hdn");

            entity.HasOne(d => d.Ma).WithMany(p => p.ChiTietHdns)
                .HasForeignKey(d => new { d.MaSp, d.MaDm })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cthdn_sp");
        });

        modelBuilder.Entity<ChiTietSp>(entity =>
        {
            entity.HasKey(e => e.MaSp).HasName("PK__ChiTietS__2725081CBF49734C");

            entity.ToTable("ChiTietSP");

            entity.Property(e => e.MaSp)
                .HasMaxLength(20)
                .HasColumnName("MaSP");
            entity.Property(e => e.BaoHanh).HasMaxLength(100);
            entity.Property(e => e.BoNho).HasMaxLength(100);
            entity.Property(e => e.Camera).HasMaxLength(100);
            entity.Property(e => e.HeDieuHanh).HasMaxLength(100);
            entity.Property(e => e.KichThuoc).HasMaxLength(100);
            entity.Property(e => e.MoTa).HasColumnType("ntext");
            entity.Property(e => e.Pin).HasMaxLength(100);
            entity.Property(e => e.SoLuong).HasDefaultValueSql("((0))");
            entity.Property(e => e.TrongLuong).HasDefaultValueSql("((0.0))");
        });

        modelBuilder.Entity<DangNhap>(entity =>
        {
            entity.HasKey(e => e.TaiKhoan).HasName("PK__DangNhap__D5B8C7F1DA9FBCEC");

            entity.ToTable("DangNhap");

            entity.Property(e => e.TaiKhoan).HasMaxLength(100);
            entity.Property(e => e.MatKhau).HasMaxLength(100);
            entity.Property(e => e.RoleId)
                .HasMaxLength(10)
                .HasColumnName("RoleID");

            entity.HasOne(d => d.Role).WithMany(p => p.DangNhaps)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("fk_dn_r");
        });

        modelBuilder.Entity<DanhMuc>(entity =>
        {
            entity.HasKey(e => e.MaDm).HasName("PK__DanhMuc__2725866E52BC68E7");

            entity.ToTable("DanhMuc");

            entity.Property(e => e.MaDm)
                .HasMaxLength(20)
                .HasColumnName("MaDM");
            entity.Property(e => e.TenDm)
                .HasMaxLength(100)
                .HasColumnName("TenDM");
        });

        modelBuilder.Entity<HoaDonBan>(entity =>
        {
            entity.HasKey(e => e.MaHdb).HasName("PK__HoaDonBa__3C90E8FA4F097CBA");

            entity.ToTable("HoaDonBan");

            entity.Property(e => e.MaHdb)
                .HasMaxLength(20)
                .HasColumnName("MaHDB");
            entity.Property(e => e.MaKh)
                .HasMaxLength(20)
                .HasColumnName("MaKH");
            entity.Property(e => e.MaNv)
                .HasMaxLength(20)
                .HasColumnName("MaNV");
            entity.Property(e => e.NgayBan).HasColumnType("date");
            entity.Property(e => e.TongTien)
                .HasDefaultValueSql("((0))")
                .HasColumnType("money");

            entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.HoaDonBans)
                .HasForeignKey(d => d.MaKh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_hdb_kh");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.HoaDonBans)
                .HasForeignKey(d => d.MaNv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_hdb_nv");
        });

        modelBuilder.Entity<HoaDonNhap>(entity =>
        {
            entity.HasKey(e => e.MaHdn).HasName("PK__HoaDonNh__3C90E8C60068CB5D");

            entity.ToTable("HoaDonNhap");

            entity.Property(e => e.MaHdn)
                .HasMaxLength(20)
                .HasColumnName("MaHDN");
            entity.Property(e => e.MaNcc)
                .HasMaxLength(20)
                .HasColumnName("MaNCC");
            entity.Property(e => e.MaNv)
                .HasMaxLength(20)
                .HasColumnName("MaNV");
            entity.Property(e => e.NgayNhap).HasColumnType("date");
            entity.Property(e => e.TongTien)
                .HasDefaultValueSql("((0))")
                .HasColumnType("money");

            entity.HasOne(d => d.MaNccNavigation).WithMany(p => p.HoaDonNhaps)
                .HasForeignKey(d => d.MaNcc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_hdn_ncc");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.HoaDonNhaps)
                .HasForeignKey(d => d.MaNv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_hdn_nv");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKh).HasName("PK__KhachHan__2725CF1EEF6D018D");

            entity.ToTable("KhachHang");

            entity.Property(e => e.MaKh)
                .HasMaxLength(20)
                .HasColumnName("MaKH");
            entity.Property(e => e.DiaChiKh)
                .HasMaxLength(100)
                .HasColumnName("DiaChiKH");
            entity.Property(e => e.Sdtkh)
                .HasMaxLength(30)
                .HasColumnName("SDTKH");
            entity.Property(e => e.TenKh)
                .HasMaxLength(100)
                .HasColumnName("TenKH");
        });

        modelBuilder.Entity<NhaCungCap>(entity =>
        {
            entity.HasKey(e => e.MaNcc).HasName("PK__NhaCungC__3A185DEBB9E7C278");

            entity.ToTable("NhaCungCap");

            entity.Property(e => e.MaNcc)
                .HasMaxLength(20)
                .HasColumnName("MaNCC");
            entity.Property(e => e.DiaChiNcc)
                .HasMaxLength(100)
                .HasColumnName("DiaChiNCC");
            entity.Property(e => e.Sdtncc)
                .HasMaxLength(30)
                .HasColumnName("SDTNCC");
            entity.Property(e => e.TenNcc)
                .HasMaxLength(100)
                .HasColumnName("TenNCC");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNv).HasName("PK__NhanVien__2725D70A32BB3AB3");

            entity.ToTable("NhanVien");

            entity.Property(e => e.MaNv)
                .HasMaxLength(20)
                .HasColumnName("MaNV");
            entity.Property(e => e.DiaChiKh)
                .HasMaxLength(100)
                .HasColumnName("DiaChiKH");
            entity.Property(e => e.GioiTinh).HasMaxLength(20);
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.NgaySinh).HasColumnType("date");
            entity.Property(e => e.Sdtnv)
                .HasMaxLength(30)
                .HasColumnName("SDTNV");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE3A82759484");

            entity.Property(e => e.RoleId)
                .HasMaxLength(10)
                .HasColumnName("RoleID");
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.RoleName).HasMaxLength(10);
        });

        modelBuilder.Entity<SanPham>(entity =>
        {
            entity.HasKey(e => new { e.MaSp, e.MaDm }).HasName("PK__SanPham__D557507AF9CEA7A5");

            entity.ToTable("SanPham");

            entity.Property(e => e.MaSp)
                .HasMaxLength(20)
                .HasColumnName("MaSP");
            entity.Property(e => e.MaDm)
                .HasMaxLength(20)
                .HasColumnName("MaDM");
            entity.Property(e => e.AnhSp)
                .HasMaxLength(100)
                .HasColumnName("AnhSP");
            entity.Property(e => e.GiaSp)
                .HasDefaultValueSql("((0))")
                .HasColumnType("money")
                .HasColumnName("GiaSP");
            entity.Property(e => e.TenSp)
                .HasMaxLength(100)
                .HasColumnName("TenSP");

            entity.HasOne(d => d.MaDmNavigation).WithMany(p => p.SanPhams)
                .HasForeignKey(d => d.MaDm)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sp_dm");

            entity.HasOne(d => d.MaSpNavigation).WithMany(p => p.SanPhams)
                .HasForeignKey(d => d.MaSp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sp_ctsp");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
