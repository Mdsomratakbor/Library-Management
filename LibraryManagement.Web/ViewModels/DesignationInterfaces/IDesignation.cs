﻿using LibraryManagement.Web.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Web.ViewModels.DesignationInterfaces
{
    interface IDesignation : IBaseEntities
    {
        string Name { get; set; }
    }
}
