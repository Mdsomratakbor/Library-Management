using LibraryManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Services.Interfaces
{
    interface IBookService
    {
        List<Book> GetAllBook(int displayLength, int displayStart, int sortCol, string sortDir, string search = null);
        Book GetBookById(int id);
        bool SaveBook(Book model);
        bool UpdateBook();
        bool DeleteBook(Book model);
    }
}
