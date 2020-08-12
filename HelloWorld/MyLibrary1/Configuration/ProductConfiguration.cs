using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyLibrary1.Entity;

namespace MyLibrary1.Configuration
{

    //ứng với mỗi class ta có một class cofiguration cho nó
    //cofiguration cho Product
    class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(pro => pro.Id);
            builder.Property(pro => pro.Id).ValueGeneratedOnAdd();

            builder.Property(pro => pro.Name).IsRequired();
            builder.Property(pro => pro.Price).IsRequired();

            builder.HasOne(Cate => Cate.Category)
                   .WithMany(Pro => Pro.Products);
        }
    }
}
