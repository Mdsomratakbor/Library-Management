using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Entities
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Code { get;set; }
        public string Semester { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }       
        public string Address { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public int DepartmentID { get; set; }
        public List<Department> Departments { get; set; }
        public List<StudentPicture> StudentPictures { get; set; }

    }
}
