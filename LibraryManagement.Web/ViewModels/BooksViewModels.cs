using LibraryManagement.Entities;
using LibraryManagement.Web.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagement.Web.ViewModels
{
    public class BooksViewModel: IBooks
    {
        public List<Book> Books { get; set; }
    }
}