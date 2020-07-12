using LibraryManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Web.ViewModels.CategoryInterfaces
{
    public interface ICategoryList
    {
        List<Category> Categories { get; set; }
    }
}
