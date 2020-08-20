using School_CRUD_CodeFirst.Models.Tables_Class;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace School_CRUD_CodeFirst.Models
{
    public class Teacher
    {
        [Key]
        public int Teacher_Id { get; set; }
        public string Teacher_Name { get; set; }
        public string Teacher_Address{ get; set; }
        public string Avatar_Path{ get; set; }
        public string Teacher_Level{ get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public IList<TeacherAndClassRoom> TeacherAndClassRooms { get; set; }
    }
}
