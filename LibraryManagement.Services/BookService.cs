using LibraryManagement.Data;
using LibraryManagement.Entities;
using LibraryManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Services
{
    public class BookService : IBookService
    {
        private LMContext _LMContext;
        public BookService()
        {
            _LMContext = new LMContext();
        }

        public List<Book> GetAllBook()
        {
            return _LMContext.Books.ToList();
        }

        public Book GetBookById(int id)
        {
            return _LMContext.Books.Find(id);
        }

        public bool SaveBook(Book model)
        {
            _LMContext.Books.Add(model);
            return _LMContext.SaveChanges() > 0;
        }

        public bool UpdateBook()
        {
            throw new NotImplementedException();
        }
        public bool DeleteBook(Book model)
        {
            _LMContext.Entry(model).State = System.Data.Entity.EntityState.Deleted;
            return _LMContext.SaveChanges() > 0;
        }
    }
}
