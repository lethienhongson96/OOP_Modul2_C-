using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestIdentity.Models
{
    public class Student
    {
        [Key]
        public int Student_Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int PhoneNum { get; set; }
        public string Avatar_Path { get; set; }
    }
}
