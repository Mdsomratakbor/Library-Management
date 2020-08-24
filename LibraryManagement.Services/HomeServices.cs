using LibraryManagement.Data;
using LibraryManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Services
{
    public class HomeServices : IHomeServices
    {
        private LMContext _context;
        public HomeServices()
        {
            _context = new LMContext();
        }
        public int TotalBooks()
        {
           return  _context.Books.Count();
            
        }

        public int TotalIssueBooks() 
        {
            return _context.Issues.Count();
        }

        public int TotalReturnBooks()
        {
            return _context.Returns.Count();
        }

        public int TotalRoles()
        {
           return _context.Roles.Count();
        }

        public int TotalStaffs()
        {
            return _context.Staffs.Count();
        }

        public int TotalStudents()
        {
            return _context.Students.Count();
        }

        public int TotalUsers()
        {
            return _context.Users.Count();
        }
    }
}
