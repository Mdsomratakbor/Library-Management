using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Entities;

namespace LibraryManagement.Web.ViewModels.Interfaces
{
    interface IBooks
    {
        List<Book> Books { get; set; }
        
    }
}
