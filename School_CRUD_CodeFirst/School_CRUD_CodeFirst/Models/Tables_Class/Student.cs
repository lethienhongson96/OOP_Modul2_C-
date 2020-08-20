using System.ComponentModel.DataAnnotations;

namespace School_CRUD_CodeFirst.Models.Tables_Class
{
    public class Student
    {
        [Key]
        public int Student_Id { get; set; }
        public string Name{ get; set; }
        public string address { get; set; }
        public int PhoneNum{ get; set; }
        public string Avatar_Path { get; set; }
        
        public ClassRoom ClassRoom{ get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    }
}
