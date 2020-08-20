using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace School_CRUD_CodeFirst.Models.Tables_Class
{
    public class ClassRoom
    {
        [Key]
        public int ClassRoom_Id { get; set; }
        public string ClassRoom_Name { get; set; }
        public string Position { get; set; }

        public ICollection<Student> Students { get; set; }

        public IList<TeacherAndClassRoom> TeacherAndClassRooms { get; set; }
    }
}
