using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyLibrary1.Entity;

namespace MyLibrary1.Entity
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [StringLength(250)]
        [Required]
        public string Name{ get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
