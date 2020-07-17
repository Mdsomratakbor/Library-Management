using LibraryManagement.Web.ViewModels.Interfaces;
using LibraryManagement.Web.ViewModels.StudentInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Web.ViewModels.IssueInterfaces
{
    public interface IIssue:IBaseEntities, IStudentList, IBookList
    {
         DateTime IssueDate { get; set; }
         DateTime ExpiraryDate { get; set; }
   
    }
}
