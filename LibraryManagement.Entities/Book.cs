﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Entities
{
    public class Book
    {
        public int ID { get; set; }
        public int BookName { get; set; }
        public int Isbn { get; set; }
        public string AuthorName { get; set; }
        public string BookPublish { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal Price { get; set; }
        public string BookEdition { get; set; }
        /// <summary>
        /// How many book in this name available are library
        /// </summary>
        public int BookQty { get; set; }
        public DateTime EntryDate { get; set; }
        public int LUserID { get; set; }
        public DateTime UpdateDate { get; set; }
        public int UpdateLUserID { get; set; }
    }
}
