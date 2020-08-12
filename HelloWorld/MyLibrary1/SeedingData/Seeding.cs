using Microsoft.EntityFrameworkCore;
using MyLibrary1.Entity;
using System;

namespace MyLibrary1.SeedingData
{

    //tạo các dử liệu ban đầu cho hệ thống thông qua Seeding
    //sau khi đả cấu hình xong thì gọi class này vào class DbContext
    public static class Seeding
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
            new Product()
            {
                Id = 1,
                Name = "iphone6",
                Price = 455641,
                CreatedDate = DateTime.Now,
                CategoryID = 1
            });

            modelBuilder.Entity<Product>().HasData(
            new Product()
            {
                Id = 2,
                Name = "iphone7",
                Price = 5445454,
                CreatedDate = DateTime.Now,
                CategoryID = 1
            });

            modelBuilder.Entity<Category>().HasData(
            new Category()
            {
                id = 1,
                name = "cell Phone",
            });


            modelBuilder.Entity<Product>().HasData(
            new Product()
            {
                Id = 3,
                Name = "wave 110cc",
                Price = 3636363,
                CreatedDate = DateTime.Now,
                CategoryID = 2
            });

            modelBuilder.Entity<Product>().HasData(
           new Product()
           {
               Id = 4,
               Name = "jupiter 150cc",
               Price = 898898,
               CreatedDate = DateTime.Now,
               CategoryID = 2
           });

            modelBuilder.Entity<Category>().HasData(
            new Category()
            {
                id = 2,
                name = "MotoBike",
            });
        }
    }
}
