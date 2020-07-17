using LibraryManagement.Web.ViewModels.Interfaces;
using LibraryManagement.Web.ViewModels.StaffInterfaces;
using LibraryManagement.Web.ViewModels.StudentInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Web.ViewModels.ReturnInterfaces
{
    public interface IReturn : IBaseEntities, IStudentList, IBookList, IStaffList
    {
       DateTime ReturnDate { get; set; }
    }
}
