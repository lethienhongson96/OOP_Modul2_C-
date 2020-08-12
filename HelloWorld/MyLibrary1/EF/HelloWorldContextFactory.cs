using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MyLibrary1.EF
{
    //class này dùng để kết nối đến database 
    public class HelloWorldContextFactory : IDesignTimeDbContextFactory<MyFirstDbContext>
    {
        public MyFirstDbContext CreateDbContext(string[] args)
        {
            //kết nối thông qua file connection json

            IConfigurationRoot Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("settingForWeb.json")
                .Build();

            //kết nối đến tên của database có trong file json
            var connectionStr = Configuration.GetConnectionString("HelloWorldDatabase");

            //thực thi sự kết nối
            var optionsBuilder = new DbContextOptionsBuilder<MyFirstDbContext>();
            optionsBuilder.UseSqlServer(connectionStr);

            return new MyFirstDbContext(optionsBuilder.Options);
        }
    }
}
