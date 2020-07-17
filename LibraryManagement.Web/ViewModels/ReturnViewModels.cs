using LibraryManagement.Entities;
using LibraryManagement.Web.ViewModels.ReturnInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagement.Web.ViewModels
{
    public class ReturnActionModel : IReturn
    {
        public int ID { get; set ; }
        public DateTime ReturnDate { get; set; }
        public DateTime? EntryDate { get; set; }
        public int? LUserID { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateLUserID { get; set; }
        public int StudentID { get; set; }
        public List<Student> Students { get; set; }
        public int BookID { get; set; }
        public List<Book> Books { get; set; }
        public int StaffID { get; set; }
        public List<Staff> Staffs { get; set; }
       
    }
}