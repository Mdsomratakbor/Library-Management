using LibraryManagement.Web.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Web.ViewModels.DepartmentInterfaces
{
    interface IDepartment : IBaseEntities
    {
        string Name { get; set; }
    }
}
