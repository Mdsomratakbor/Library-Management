﻿using LibraryManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Web.ViewModels.MenuRoleInterfaces
{
    public interface IMenuRoleList
    {
        List<MenuRole> MenuRoles { get; set; }
    }
}
