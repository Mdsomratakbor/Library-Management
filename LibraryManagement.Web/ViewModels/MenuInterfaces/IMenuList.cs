﻿using LibraryManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LibraryManagement.Web.ViewModels.MenuInterfaces
{
    public interface IMenuList
    {
        List<Menu> Menus { get; set; }
    }
}
