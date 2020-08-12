using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyLibrary1.Entity;

namespace MyLibrary1.Configuration
{
    //ứng với mỗi class ta có một class cofiguration cho nó
    //cofiguration cho Category
    class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categorys");
            builder.HasKey(cate => cate.id);

            builder.Property(cate => cate.id).ValueGeneratedOnAdd();

            builder.Property(cate => cate.name).IsRequired(true);
        }
    }
}
