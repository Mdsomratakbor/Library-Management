﻿using LibraryManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Web.ViewModels.DepartmentInterfaces
{
    interface IDepartmentList
    {
         List<Department> Departments { get; set; }
    }
}