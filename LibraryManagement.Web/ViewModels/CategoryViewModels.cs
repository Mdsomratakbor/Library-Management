using LibraryManagement.Entities;
using LibraryManagement.Web.ViewModels.CategoryInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryManagement.Web.ViewModels
{
    public class CategoryListModel : ICategoryList
    {
        public List<Category> Categories { get; set; }
    }
    public class CategoryActionModel : ICategory
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Please enter Book Category Name")]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? EntryDate { get; set; }
        public int? LUserID { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateLUserID { get; set; }
    }
}