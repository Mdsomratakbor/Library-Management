using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Entities
{
    public class Student : BaseEntities
    {
        public string Name { get; set; }
        public string Code { get;set; }
        public string Semester { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }       
        public string Address { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public int DepartmentID { get; set; }
        public virtual Department Departments { get; set; }
        public virtual List<StudentPicture> StudentPictures { get; set; }

    }
}
