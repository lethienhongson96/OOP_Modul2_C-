using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PharmacyWeb.Models
{
    public partial class PharmacyWebDbContext : IdentityDbContext<ApplicationUser>
    {
        public PharmacyWebDbContext()
        {
        }

        public PharmacyWebDbContext(DbContextOptions<PharmacyWebDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<District> District { get; set; }
        public virtual DbSet<Province> Province { get; set; }
        public virtual DbSet<Ward> Ward { get; set; }

        public virtual DbSet<Address> Addresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLexpress;Database=PharmacyWebDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Address>()
            .HasOne(a => a.ApplicationUser)
            .WithOne(b => b.Address)
            .HasForeignKey<ApplicationUser>(b => b.Address_Id);

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
