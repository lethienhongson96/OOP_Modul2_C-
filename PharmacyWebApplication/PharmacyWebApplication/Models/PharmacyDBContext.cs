using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PharmacyWebApplication.Models
{
    public partial class PharmacyDBContext : DbContext
    {
        public PharmacyDBContext()
        {
        }

        public PharmacyDBContext(DbContextOptions<PharmacyDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<District> District { get; set; }
        public virtual DbSet<Province> Province { get; set; }
        public virtual DbSet<Ward> Ward { get; set; }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<User> User{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLexpress;Database=PharmacyDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<User>()
           .HasOne(s => s.Address)
           .WithOne(ad => ad.User)
           .HasForeignKey<Address>(ad => ad.User_Id);

            modelBuilder.Entity<District>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("district");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("_name")
                    .HasMaxLength(100);

                entity.Property(e => e.Prefix)
                    .HasColumnName("_prefix")
                    .HasMaxLength(20);

                entity.Property(e => e.ProvinceId).HasColumnName("_province_id");
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("province");

                entity.Property(e => e.Code)
                    .HasColumnName("_code")
                    .HasMaxLength(20);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("_name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Ward>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ward");

                entity.Property(e => e.DistrictId).HasColumnName("_district_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("_name")
                    .HasMaxLength(50);

                entity.Property(e => e.Prefix)
                    .HasColumnName("_prefix")
                    .HasMaxLength(20);

                entity.Property(e => e.ProvinceId).HasColumnName("_province_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
