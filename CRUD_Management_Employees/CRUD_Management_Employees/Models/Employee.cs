using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Management_Employees.Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Required]
        [DisplayName("Full Name")]
        public string FullName { get; set; }

        [Column(TypeName = "varchar(10)")]
        [Required]
        [DisplayName("employee code")]
        public string EmpCode { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Required]
        public string Position { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Required]
        [DisplayName("Office Location")]
        public string OfficeLocation { get; set; }
    }
}
