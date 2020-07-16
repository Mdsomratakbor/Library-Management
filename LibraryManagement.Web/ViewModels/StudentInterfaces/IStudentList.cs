using LibraryManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Web.ViewModels.StudentInterfaces
{
    public interface IStudentList
    {
         List<Student> Students { get; set; }
    }
}
