namespace LaptopStore.Models.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=LaptopStoreDB")
        {
        }

        public virtual DbSet<CTDonHang> CTDonHangs { get; set; }
        public virtual DbSet<DanhMuc> DanhMucs { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<KhoangGia> KhoangGias { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DonHang>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.Mail)
                .IsUnicode(false);

            modelBuilder.Entity<KhoangGia>()
                .Property(e => e.Giatren)
                .HasPrecision(18, 0);

            modelBuilder.Entity<KhoangGia>()
                .Property(e => e.Giaduoi)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.Imagelink)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.Memory)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.Hedieuhanh)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.VGA)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.CPUZ)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.Battery)
                .IsUnicode(false);
        }
    }
}
