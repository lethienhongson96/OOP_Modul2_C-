using Microsoft.EntityFrameworkCore;
using MyLibrary1.Configuration;
using MyLibrary1.Entity;
using MyLibrary1.SeedingData;

namespace MyLibrary1.EF
{
    //database nằm ở file này
    //khai báo các class tượng trưng cho các table vào file này
    //sau đó applyconfiguration cho các class đó thông qua các class configuration đả cấu hình
    public class MyFirstDbContext : DbContext
    {
        //khái báo các table có mặt trong hệ thống
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        //ctor
        public MyFirstDbContext(DbContextOptions options) : base(options)
        {
        }

        //override phương thức OnModelCreating để đưa các configuration vào áp dụng
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

            //gọi seeding data vào để configuration
            modelBuilder.Seed();
        }

        //Data for CRUD
    }
}
