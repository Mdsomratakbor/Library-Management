﻿using LibraryManagement.Entities;
using LibraryManagement.Web.ViewModels.ImageInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Web.ViewModels.Interfaces
{
    interface IBook: IBaseEntities, IPicture<BookPicture>
    {
         string BookName { get; set; }
         int Isbn { get; set; }
         string AuthorName { get; set; }
         string BookPublish { get; set; }
         DateTime PurchaseDate { get; set; }
         decimal Price { get; set; }
         string BookEdition { get; set; }
        /// <summary>
        /// How many book in this name available are library
        /// </summary>
         int BookQty { get; set; }
    }
}