using LibraryManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Web.ViewModels.Interfaces
{
    interface IBook: IBaseEntities
    {
         string BookName { get; set; }
         int Isbn { get; set; }
         string AuthorName { get; set; }
         string BookPublish { get; set; }
         DateTime PurchaseDate { get; set; }
         decimal Price { get; set; }
         string BookEdition { get; set; }
         List<BookPicture> BookPictures { get; set; }
        /// <summary>
        /// How many book in this name available are library
        /// </summary>
         int BookQty { get; set; }
    }
}
