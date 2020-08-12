using Microsoft.EntityFrameworkCore;
using MyLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyLibrary
{
    class EmployeeDbContext : DbContext
    {
        public DbSet<Employee> employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

    }
}
