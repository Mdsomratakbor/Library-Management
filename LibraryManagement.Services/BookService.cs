﻿using LibraryManagement.Data;
using LibraryManagement.Entities;
using LibraryManagement.Services.Abstractclass;
using LibraryManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Services
{
    public class BookService : LibraryManagementServices<Book>, IBookService
    {
        public List<Book> GetAllData(int displayLength, int displayStart, int sortCol, string sortDir, string search)
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
                    books = _LMContext.Books.OrderBy(x => columnNameAsc).Where(x => x.BookName.ToString().ToLower().Contains(search.ToLower()) || x.Isbn.ToString().ToLower().Contains(search.ToLower()) || x.AuthorName.ToString().ToLower().Contains(search.ToLower()) || x.BookPublish.ToString().ToLower().Contains(search.ToLower()) || x.PurchaseDate.ToString().ToLower().Contains(search.ToLower()) || x.Price.ToString().ToLower().Contains(search.ToLower()) || x.BookEdition.ToString().ToLower().Contains(search.ToLower()) || x.BookQty.ToString().ToLower().Contains(search.ToLower())).Include(y => y.BookPictures.Select(x => x.Pictures)).Include(w=>w.Categories).ToList();
                }

                else if (sortDir == "dsc" && string.IsNullOrEmpty(search) == false)
                {
                    books = _LMContext.Books.OrderBy(x => columnNameDsc).Where(x => x.BookName.ToString().ToLower().Contains(search.ToLower()) || x.Isbn.ToString().ToLower().Contains(search.ToLower()) || x.AuthorName.ToString().ToLower().Contains(search.ToLower()) || x.BookPublish.ToString().ToLower().Contains(search.ToLower()) || x.PurchaseDate.ToString().ToLower().Contains(search.ToLower()) || x.Price.ToString().ToLower().Contains(search.ToLower()) || x.BookEdition.ToString().ToLower().Contains(search.ToLower()) || x.BookQty.ToString().ToLower().Contains(search.ToLower())).Include(y => y.BookPictures.Select(x => x.Pictures)).Include(w => w.Categories).ToList();
                }
                else if (sortDir == "asc")
                {
                    books = _LMContext.Books.OrderBy(x => columnNameAsc).Include(y => y.BookPictures.Select(x => x.Pictures)).Include(w => w.Categories).ToList();
                }
                else
                {
                    books = _LMContext.Books.OrderBy(x => columnNameDsc).Include(y => y.BookPictures.Select(x => x.Pictures)).Include(w => w.Categories).ToList();
                }
                return books;
            }

        }

        public override List<Book> GetAllData()
        {
            using (var _LMContext = new LMContext())
            {
                return _LMContext.Books.Where(x=>x.BookQty>0).Include(y => y.BookPictures.Select(x => x.Pictures)).ToList();
            }
        }
        public override Book GetDataById(int id)
        {
            using (var _LMContext = new LMContext())
            {
                return _LMContext.Books.Where(x => x.ID == id).Include(y => y.BookPictures.Select(x => x.Pictures)).FirstOrDefault();
            }
        }

        public override bool UpdateData(Book model)
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
    }
}
