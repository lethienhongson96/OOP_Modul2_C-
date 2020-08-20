using School_CRUD_CodeFirst.Models.Tables_Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School_CRUD_CodeFirst.Models
{
    public class TeacherAndClassRoom
    {
        public string Course { get; set; }

        public int Teacher_Id { get; set; }
        public Teacher Teacher{ get; set; }

        public int ClassRoom_Id { get; set; }
        public ClassRoom ClassRoom{ get; set; }
    }
}
