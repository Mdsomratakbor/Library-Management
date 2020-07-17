using LibraryManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Web.ViewModels.StaffInterfaces
{
    public interface IStaffList
    {
        int StaffID { get; set; }
        List<Staff> Staffs { get; set; }
    }
}
