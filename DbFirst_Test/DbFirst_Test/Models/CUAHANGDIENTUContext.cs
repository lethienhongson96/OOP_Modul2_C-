using Microsoft.EntityFrameworkCore;

namespace DbFirst_Test.Models
{
    public partial class CUAHANGDIENTUContext : DbContext
    {
        public CUAHANGDIENTUContext()
        {
        }

        public CUAHANGDIENTUContext(DbContextOptions<CUAHANGDIENTUContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chungtu> Chungtu { get; set; }
        public virtual DbSet<Mathang> Mathang { get; set; }
        public virtual DbSet<Phieuthutien> Phieuthutien { get; set; }
        public virtual DbSet<VwChungTu> VwChungTu { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
  //To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=CUAHANGDIENTU;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chungtu>(entity =>
            {
                entity.HasKey(e => e.Sochungtu);

                entity.ToTable("CHUNGTU");

                entity.Property(e => e.Sochungtu).HasColumnName("SOCHUNGTU");

                entity.Property(e => e.Diachikhachhang)
                    .IsRequired()
                    .HasColumnName("DIACHIKHACHHANG")
                    .HasMaxLength(100);

                entity.Property(e => e.Dongia)
                    .HasColumnName("DONGIA")
                    .HasColumnType("money");

                entity.Property(e => e.Mahang).HasColumnName("MAHANG");

                entity.Property(e => e.Ngaylap)
                    .HasColumnName("NGAYLAP")
                    .HasColumnType("date");

                entity.Property(e => e.Soluong).HasColumnName("SOLUONG");

                entity.Property(e => e.Tenkhachhang)
                    .IsRequired()
                    .HasColumnName("TENKHACHHANG")
                    .HasMaxLength(50);

                entity.HasOne(d => d.MahangNavigation)
                    .WithMany(p => p.Chungtu)
                    .HasForeignKey(d => d.Mahang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CHUNGTU_MATHANG");
            });

            modelBuilder.Entity<Mathang>(entity =>
            {
                entity.HasKey(e => e.Mahang);

                entity.ToTable("MATHANG");

                entity.Property(e => e.Mahang).HasColumnName("MAHANG");

                entity.Property(e => e.Chitietmathang)
                    .IsRequired()
                    .HasColumnName("CHITIETMATHANG")
                    .HasMaxLength(100);

                entity.Property(e => e.Giaban)
                    .HasColumnName("GIABAN")
                    .HasColumnType("money");

                entity.Property(e => e.Soluong).HasColumnName("SOLUONG");

                entity.Property(e => e.Tenhang)
                    .IsRequired()
                    .HasColumnName("TENHANG")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Phieuthutien>(entity =>
            {
                entity.HasKey(e => e.Sophieu);

                entity.ToTable("PHIEUTHUTIEN");

                entity.Property(e => e.Sophieu).HasColumnName("SOPHIEU");

                entity.Property(e => e.Ngaythutien)
                    .HasColumnName("NGAYTHUTIEN")
                    .HasColumnType("date");

                entity.Property(e => e.Sochungtu).HasColumnName("SOCHUNGTU");

                entity.Property(e => e.Sotien)
                    .HasColumnName("SOTIEN")
                    .HasColumnType("money");

                entity.HasOne(d => d.SochungtuNavigation)
                    .WithMany(p => p.Phieuthutien)
                    .HasForeignKey(d => d.Sochungtu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PHIEUTHUTIEN_CHUNGTU");
            });

            modelBuilder.Entity<VwChungTu>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_ChungTu");

                entity.Property(e => e.Diachikhachhang)
                    .IsRequired()
                    .HasColumnName("DIACHIKHACHHANG")
                    .HasMaxLength(100);

                entity.Property(e => e.Dongia)
                    .HasColumnName("DONGIA")
                    .HasColumnType("money");

                entity.Property(e => e.Mahang).HasColumnName("MAHANG");

                entity.Property(e => e.Ngaylap)
                    .HasColumnName("NGAYLAP")
                    .HasColumnType("date");

                entity.Property(e => e.Sochungtu)
                    .HasColumnName("SOCHUNGTU")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Soluong).HasColumnName("SOLUONG");

                entity.Property(e => e.Tenkhachhang)
                    .IsRequired()
                    .HasColumnName("TENKHACHHANG")
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
