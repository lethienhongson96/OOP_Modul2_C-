using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using School_CRUD_CodeFirst.Models.Tables_Class;
using School_CRUD_CodeFirst.Models.UserIdentity;
using System;

namespace School_CRUD_CodeFirst.Models
{
    public class SchoolDbContext : IdentityDbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TeacherAndClassRoom>().HasKey(sc => new { sc.Teacher_Id, sc.ClassRoom_Id });

            modelBuilder.Entity<TeacherAndClassRoom>()
                .HasOne(sc => sc.Teacher)
                .WithMany(s => s.TeacherAndClassRooms)
                .HasForeignKey(sc => sc.Teacher_Id);


            modelBuilder.Entity<TeacherAndClassRoom>()
                .HasOne(sc => sc.ClassRoom)
                .WithMany(s => s.TeacherAndClassRooms)
                .HasForeignKey(sc => sc.ClassRoom_Id);

        }

        public DbSet<ClassRoom> ClassRooms { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherAndClassRoom> TeacherAndClassRooms { get; set; }

    }
}
