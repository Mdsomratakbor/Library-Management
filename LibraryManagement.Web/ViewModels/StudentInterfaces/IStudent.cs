using LibraryManagement.Web.ViewModels.DesignationInterfaces;
using LibraryManagement.Web.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagement.Web.ViewModels.StudentInterfaces
{
     interface IStudent : IBaseEntities, IDesignatioList
    {
         string Name { get; set; }
         string Code { get; set; }
         string Semester { get; set; }
         string Email { get; set; }
         string Gender { get; set; }
         string Address { get; set; }
         string City { get; set; }
         string Phone { get; set; }
         int DepartmentID { get; set; }
    }
}