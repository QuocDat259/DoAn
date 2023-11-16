using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace NhaKhoa.Models
{
    public partial class NhaKhoaModel : DbContext
    {
        public NhaKhoaModel()
            : base("name=NhaKhoaModels")
        {
        }

        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<DanhGia> DanhGia { get; set; }
        public virtual DbSet<DichVu> DichVu { get; set; }
        public virtual DbSet<DonThuoc> DonThuoc { get; set; }
        public virtual DbSet<HinhThucThanhToan> HinhThucThanhToan { get; set; }
        public virtual DbSet<HoaDon> HoaDon { get; set; }
        public virtual DbSet<KhungGio> KhungGio { get; set; }
        public virtual DbSet<LichKham> LichKham { get; set; }
        public virtual DbSet<PhieuDatLich> PhieuDatLich { get; set; }
        public virtual DbSet<PhiKham> PhiKham { get; set; }
        public virtual DbSet<Phong> Phong { get; set; }
        public virtual DbSet<TinTuc> TinTuc { get; set; }
        public virtual DbSet<Thuoc> Thuoc { get; set; }
        public virtual DbSet<VatTu> VatTu { get; set; }
        public virtual DbSet<VatTuSuDung> VatTuSuDung { get; set; }
        public virtual DbSet<ThoiKhoaBieu> ThoiKhoaBieu { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoles>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.DonThuoc)
                .WithOptional(e => e.AspNetUsers)
                .HasForeignKey(e => e.Id_bacsi);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.HoaDon)
                .WithOptional(e => e.AspNetUsers)
                .HasForeignKey(e => e.Id_benhnhan);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.LichKham)
                .WithOptional(e => e.AspNetUsers)
                .HasForeignKey(e => e.Id_Nhasi);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.PhieuDatLich)
                .WithOptional(e => e.AspNetUsers)
                .HasForeignKey(e => e.IdBenhNhan);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.TinTuc)
                .WithOptional(e => e.AspNetUsers)
                .HasForeignKey(e => e.Id_admin);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.ThoiKhoaBieu)
                .WithOptional(e => e.AspNetUsers)
                .HasForeignKey(e => e.Id_Nhasi);

            modelBuilder.Entity<DichVu>()
                .HasMany(e => e.VatTuSuDung)
                .WithRequired(e => e.DichVu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DonThuoc>()
                .HasMany(e => e.Thuoc)
                .WithMany(e => e.DonThuoc)
                .Map(m => m.ToTable("ChiTietThuoc").MapLeftKey("Id_donthuoc").MapRightKey("Id_thuoc"));

            modelBuilder.Entity<HoaDon>()
                .HasMany(e => e.VatTuSuDung)
                .WithRequired(e => e.HoaDon)
                .HasForeignKey(e => e.Id_dichvu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HoaDon>()
                .HasMany(e => e.VatTuSuDung1)
                .WithRequired(e => e.HoaDon1)
                .HasForeignKey(e => e.Id_Vattu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhieuDatLich>()
                .HasMany(e => e.PhiKham)
                .WithRequired(e => e.PhieuDatLich)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VatTu>()
                .HasMany(e => e.VatTuSuDung)
                .WithRequired(e => e.VatTu)
                .WillCascadeOnDelete(false);
        }
    }
}
