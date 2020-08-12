using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyLibrary.Models
{
    [Table("Employee")]
    class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [StringLength(255)]
        [Column(TypeName = "nvarchar")]
        [Required]
        public string name { get; set; }

        public float salary { get; set; }
        [Required]
        public DateTime createdDate { get; set; }
        public bool status { get; set; }
    }
}
