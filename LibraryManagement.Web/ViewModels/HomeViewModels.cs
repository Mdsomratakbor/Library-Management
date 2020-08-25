using LibraryManagement.Web.ViewModels.HomeInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagement.Web.ViewModels
{
    public class HomeViewModel : IHome
    {
        public int TotalBooks { get; set; }
        public int TotalStudents { get; set; }
        public int TotalStaffs { get; set; }
        public int TotalRoles { get; set; }
        public int TotalUsers { get; set; }
        public int TotalIssueBooks { get; set; }
        public int TotalReturnBooks { get; set; }
    }
}