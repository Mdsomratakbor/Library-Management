using LibraryManagement.Web.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagement.Web.ViewModels.CategoryInterfaces
{
    public interface ICategory : IBaseEntities
    {
        string Name { get; set; }
        string Description { get; set; }
    }
}