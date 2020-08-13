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
        [Required(ErrorMessage ="please enter your name")]
        [DisplayName("Full Name")]
        public string FullName { get; set; }

        [Column(TypeName = "varchar(10)")]
        [Required(ErrorMessage = "please enter your Employee code")]
        [DisplayName("employee code")]
        public string EmpCode { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Required(ErrorMessage = "please enter your Position")]
        public string Position { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Required(ErrorMessage = "please enter your Office Location")]
        [DisplayName("Office Location")]
        public string OfficeLocation { get; set; }
    }
}
