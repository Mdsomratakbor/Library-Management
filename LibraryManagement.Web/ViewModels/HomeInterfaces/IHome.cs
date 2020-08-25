using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Web.ViewModels.HomeInterfaces
{
    public interface IHome
    {
        int TotalBooks { get; set; }
        int TotalStudents { get; set; }
        int TotalStaffs { get; set; }
        int TotalRoles { get; set; }
        int TotalUsers { get; set; }
        int TotalIssueBooks { get; set; }
        int TotalReturnBooks { get; set; }
    }
}
