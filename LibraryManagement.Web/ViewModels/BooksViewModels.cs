using LibraryManagement.Entities;
using LibraryManagement.Web.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required (ErrorMessage ="Please enter Book Name")]

        public string BookName { get; set; }
        [Required (ErrorMessage ="Please enter book ISBN")]
        public int Isbn { get; set; }
        [Required (ErrorMessage ="Please enter book Author Name")]
        public string AuthorName { get; set; }
        [Required(ErrorMessage = "Please enter book publisher")]
        public string BookPublish { get; set; }
        [Required (ErrorMessage ="Please enter book Purchase Date")]
        public DateTime PurchaseDate { get; set; }
        [Required(ErrorMessage = "Please enter book Price ")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Please enter book Edition ")]
        public string BookEdition { get; set; }
        [Required(ErrorMessage = "Please enter total book purchase qty")]
        public int BookQty { get; set; }
        public List<BookPicture> Pictures { get; set; }
        public string PictureIDs { get; set; }
        [Required(ErrorMessage = "Please enter book category")]
        public int CategoryID { get; set; }
        public List<Category> Categories { get; set; }
    }
}