using LibraryManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Web.ViewModels.ImageInterfaces
{
    interface IPicture<T> where T: class
    {
         List<T> Pictures { get; set; }
    }
}
