using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace qlthucung.Models
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public virtual DbSet<DanhGium> DanhGia { get; set; }
        public virtual DbSet<DanhMuc> DanhMucs { get; set; }
        public virtual DbSet<DichVu> DichVus { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<KhachHangRole> KhachHangRoles { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<ThuVienAnh> ThuVienAnhs { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectsV13;Database=petstore;Trusted_Connection=True;");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ChiTietDonHang>(entity =>
            {
                entity.HasKey(e => new { e.Madon, e.Masp })
                    .HasName("PK__ChiTietD__3C460110D46F34D2");

                entity.HasOne(d => d.MadonNavigation)
                    .WithMany(p => p.ChiTietDonHangs)
                    .HasForeignKey(d => d.Madon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ChiTietDo__madon__36B12243");

                entity.HasOne(d => d.MaspNavigation)
                    .WithMany(p => p.ChiTietDonHangs)
                    .HasForeignKey(d => d.Masp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ChiTietDon__masp__37A5467C");
            });

            modelBuilder.Entity<DanhGium>(entity =>
            {
                entity.Property(e => e.Trangthai).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdKhNavigation)
                    .WithMany(p => p.DanhGia)
                    .HasForeignKey(d => d.IdKh)
                    .HasConstraintName("FK__DanhGia__id_kh__3C69FB99");

                entity.HasOne(d => d.IdSpNavigation)
                    .WithMany(p => p.DanhGia)
                    .HasForeignKey(d => d.IdSp)
                    .HasConstraintName("FK__DanhGia__id_sp__3B75D760");
            });

            modelBuilder.Entity<DanhMuc>(entity =>
            {
                entity.HasKey(e => e.IdDanhmuc)
                    .HasName("PK__DanhMuc__DB790BF68C813DE1");
            });

            modelBuilder.Entity<DichVu>(entity =>
            {
                entity.HasKey(e => e.Iddichvu)
                    .HasName("PK__DichVu__77FDDBF8BC48DDF1");

                entity.HasOne(d => d.MakhNavigation)
                    .WithMany(p => p.DichVus)
                    .HasForeignKey(d => d.Makh)
                    .HasConstraintName("FK__DichVu__makh__30F848ED");
            });

            modelBuilder.Entity<DonHang>(entity =>
            {
                entity.HasKey(e => e.Madon)
                    .HasName("PK__DonHang__0BE416770A34913A");

                entity.HasOne(d => d.MakhNavigation)
                    .WithMany(p => p.DonHangs)
                    .HasForeignKey(d => d.Makh)
                    .HasConstraintName("FK__DonHang__makh__33D4B598");
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.HasKey(e => e.Makh)
                    .HasName("PK__KhachHan__7A21BB4CE42C9226");

                entity.Property(e => e.Dienthoai).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Tendangnhap).IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.KhachHangs)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__KhachHang__RoleI__2E1BDC42");
            });

            modelBuilder.Entity<KhachHangRole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__KhachHan__8AFACE3A2B34BEF9");

                entity.Property(e => e.RoleId).ValueGeneratedNever();

                entity.Property(e => e.RoleName).IsUnicode(false);
            });


            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.HasKey(e => e.Masp)
                    .HasName("PK__SanPham__7A217672AEC9D6C2");

                entity.HasOne(d => d.IdDanhmucNavigation)
                    .WithMany(p => p.SanPhams)
                    .HasForeignKey(d => d.IdDanhmuc)
                    .HasConstraintName("FK__SanPham__idDanhm__286302EC");

                entity.HasOne(d => d.IdthuvienNavigation)
                    .WithMany(p => p.SanPhams)
                    .HasForeignKey(d => d.Idthuvien)
                    .HasConstraintName("FK__SanPham__idthuvi__29572725");
            });

            modelBuilder.Entity<ThuVienAnh>(entity =>
            {
                entity.HasKey(e => e.Idthuvien)
                    .HasName("PK__ThuVienA__31FA4CDF3B21DD43");
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
