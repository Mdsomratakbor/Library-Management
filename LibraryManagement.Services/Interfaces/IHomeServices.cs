using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Services.Interfaces
{
    public interface IHomeServices
    {
        int TotalBooks();
        int TotalStudents();
        int TotalStaffs();
        int TotalRoles();
        int TotalUsers();
        int TotalIssueBooks();
        int TotalReturnBooks();

    }
}
