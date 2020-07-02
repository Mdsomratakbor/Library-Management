using LibraryManagement.Entities;
using LibraryManagement.Web.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagement.Web.ViewModels
{
    public class BooksViewModel : IBookList
    {
        public List<Book> Books { get; set; }
    }
    public class BookActionModel : IBook
    {
        public int ID { get; set; }
        public DateTime? EntryDate { get; set; }
        public int? LUserID { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateLUserID { get; set; }
        public string BookName { get; set; }
        public int Isbn { get; set; }
        public string AuthorName { get; set; }
        public string BookPublish { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal Price { get; set; }
        public string BookEdition { get; set; }
        public int BookQty { get; set; }
        public List<BookPicture> Pictures { get; set; }
        public string PictureIDs { get; set; }
    }
}