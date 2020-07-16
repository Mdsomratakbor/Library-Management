using LibraryManagement.Entities;
using LibraryManagement.Web.ViewModels.IssueInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryManagement.Web.ViewModels
{
    public class IssueActionModel : IIssue
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="Enter the Issue Date")]
        public DateTime IssueDate { get; set; }
        [Required(ErrorMessage = "Enter the Expirary Date")]
        public DateTime ExpiraryDate { get; set; }
        [Required(ErrorMessage = "Enter the Student Name")]
        public int StudentID { get; set; }
        [Required(ErrorMessage = "Enter the Book Name")]
        public int BookID { get; set; }       
        public DateTime? EntryDate { get; set; }
        public int? LUserID { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateLUserID { get; set; }
        public List<Student> Students { get; set; }
        public List<Book> Books { get; set; }
    }
}