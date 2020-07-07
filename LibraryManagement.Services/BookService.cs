using LibraryManagement.Data;
using LibraryManagement.Entities;
using LibraryManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Services
{
    public class BookService : IBookService
    {
        #region Singletone
        public static BookService Instance
        {
            get
            {
                if (instance == null) instance = new BookService();
                return instance;
            }
        }
        private static BookService instance { get; set; }
        #endregion




        public List<Book> GetAllBook(int displayLength, int displayStart, int sortCol, string sortDir, string search)
        {

            using (var _LMContext = new LMContext())
            {
                string columnNameAsc = "";
                string columnNameDsc = "";
                List<Book> books = new List<Book>();
                if (sortCol == 0 && sortDir == "asc") columnNameAsc = "BookName";
                else if (sortCol == 0 && sortDir == "dsc") columnNameDsc = "BookName";
                else if (sortCol == 1 && sortDir == "asc") columnNameAsc = "Isbn";
                else if (sortCol == 1 && sortDir == "dsc") columnNameDsc = "Isbn";
                else if (sortCol == 2 && sortDir == "asc") columnNameAsc = "AuthorName";
                else if (sortCol == 2 && sortDir == "dsc") columnNameDsc = "AuthorName";
                else if (sortCol == 3 && sortDir == "asc") columnNameAsc = "BookPublish";
                else if (sortCol == 3 && sortDir == "dsc") columnNameDsc = "BookPublish";
                else if (sortCol == 4 && sortDir == "asc") columnNameAsc = "PurchaseDate";
                else if (sortCol == 4 && sortDir == "dsc") columnNameDsc = "PurchaseDate";
                else if (sortCol == 5 && sortDir == "asc") columnNameAsc = "Price";
                else if (sortCol == 5 && sortDir == "dsc") columnNameDsc = "Price";
                else if (sortCol == 6 && sortDir == "asc") columnNameAsc = "BookEdition";
                else if (sortCol == 6 && sortDir == "dsc") columnNameDsc = "BookEdition";
                else if (sortCol == 7 && sortDir == "asc") columnNameAsc = "BookQty";
                else if (sortCol == 7 && sortDir == "dsc") columnNameDsc = "BookQty";

                if (sortDir == "asc" && string.IsNullOrEmpty(search) == false)
                {
                    books = _LMContext.Books.OrderBy(x => columnNameAsc).Where(x => x.BookName.ToString().ToLower().Contains(search.ToLower()) || x.Isbn.ToString().ToLower().Contains(search.ToLower()) || x.AuthorName.ToString().ToLower().Contains(search.ToLower()) || x.BookPublish.ToString().ToLower().Contains(search.ToLower()) || x.PurchaseDate.ToString().ToLower().Contains(search.ToLower()) || x.Price.ToString().ToLower().Contains(search.ToLower()) || x.BookEdition.ToString().ToLower().Contains(search.ToLower()) || x.BookQty.ToString().ToLower().Contains(search.ToLower())).Include(y => y.BookPictures.Select(x => x.Pictures)).ToList();
                }

                else if (sortDir == "dsc" && string.IsNullOrEmpty(search) == false)
                {
                    books = _LMContext.Books.OrderBy(x => columnNameDsc).Where(x => x.BookName.ToString().ToLower().Contains(search.ToLower()) || x.Isbn.ToString().ToLower().Contains(search.ToLower()) || x.AuthorName.ToString().ToLower().Contains(search.ToLower()) || x.BookPublish.ToString().ToLower().Contains(search.ToLower()) || x.PurchaseDate.ToString().ToLower().Contains(search.ToLower()) || x.Price.ToString().ToLower().Contains(search.ToLower()) || x.BookEdition.ToString().ToLower().Contains(search.ToLower()) || x.BookQty.ToString().ToLower().Contains(search.ToLower())).Include(y => y.BookPictures.Select(x => x.Pictures)).ToList();
                }
                else if (sortDir == "asc")
                {
                    books = _LMContext.Books.OrderBy(x => columnNameDsc).Include(y => y.BookPictures.Select(x => x.Pictures)).ToList();
                }
                else
                {
                    books = _LMContext.Books.OrderBy(x => columnNameDsc).Include(y => y.BookPictures.Select(x => x.Pictures)).ToList();
                }
                return books;
            }

        }

        public int TotalRowCount()
        {
            using (var _LMContext = new LMContext())
            {
                return _LMContext.Books.Count();

            }

        }

        public Book GetBookById(int id)
        {
            using (var _LMContext = new LMContext())
            {
                return _LMContext.Books.Where(x => x.ID == id).Include(y => y.BookPictures.Select(x => x.Pictures)).FirstOrDefault();
            }
        }

        public bool SaveBook(Book model)
        {
            using (var _LMContext = new LMContext())
            {
                _LMContext.Books.Add(model);
                return _LMContext.SaveChanges() > 0;
            }
        }

        public bool UpdateBook(Book model)
        {
            using (var _LMContext = new LMContext())
            {
                var existingBook = _LMContext.Books.Find(model.ID);
                _LMContext.BookPictures.RemoveRange(existingBook.BookPictures);
                _LMContext.Entry(existingBook).CurrentValues.SetValues(model);
                _LMContext.BookPictures.AddRange(model.BookPictures);
                return _LMContext.SaveChanges() > 0;
            }
        }
        public bool DeleteBook(int id)
        {
            using (var _LMContext = new LMContext())
            {
                var auction = _LMContext.Books.Find(id);
                _LMContext.Entry(auction).State = System.Data.Entity.EntityState.Modified;
                _LMContext.Books.Remove(auction);
                return _LMContext.SaveChanges()>0;
            }
        }
    }
}
