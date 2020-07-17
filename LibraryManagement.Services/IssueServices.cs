using LibraryManagement.Data;
using LibraryManagement.Entities;
using LibraryManagement.Services.Abstractclass;
using LibraryManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Services
{
    public class IssueServices : LibraryManagementServices<Issue>, IIssuServices
    {
        public List<Issue> GetAllData(int displayLength, int displayStart, int sortCol, string sortDir, string search = null)
        {
            using(var _LMContext = new LMContext())
            {
                string columnNameAsc = "";
                string columnNameDsc = "";
                List<Issue> issues = new List<Issue>();
                if (sortCol == 0 && sortDir == "asc") columnNameAsc = "BookID";
                else if (sortCol == 0 && sortDir == "dsc") columnNameDsc = "BookID";
                else if (sortCol == 1 && sortDir == "asc") columnNameAsc = "IssueDate";
                else if (sortCol == 1 && sortDir == "dsc") columnNameDsc = "IssueDate";
                else if (sortCol == 1 && sortDir == "asc") columnNameAsc = "ExpiraryDate";
                else if (sortCol == 1 && sortDir == "dsc") columnNameDsc = "ExpiraryDate";
                else if (sortCol == 1 && sortDir == "asc") columnNameAsc = "StudentID";
                else if (sortCol == 1 && sortDir == "dsc") columnNameDsc = "StudentID";
                if (sortDir == "asc" && string.IsNullOrEmpty(search) == false)
                {
                    issues = _LMContext.Issues.OrderBy(x => columnNameAsc).Where(x => x.Books.BookName.ToString().ToLower().Contains(search.ToLower()) || x.IssueDate.ToString().ToLower().Contains(search.ToLower()) || x.ExpiraryDate.ToString().ToLower().Contains(search.ToLower()) || x.Students.Name.ToString().ToLower().Contains(search.ToLower())).Include(y=>y.Students).Include(z=>z.Books.Categories).Include(z => z.Books.BookPictures).Include(z => z.Students.StudentPictures).Include(z => z.Students.Departments).ToList();
                }

                else if (sortDir == "dsc" && string.IsNullOrEmpty(search) == false)
                {
                    issues = _LMContext.Issues.OrderBy(x => columnNameDsc).Where(x => x.Books.BookName.ToString().ToLower().Contains(search.ToLower()) || x.IssueDate.ToString().ToLower().Contains(search.ToLower()) || x.ExpiraryDate.ToString().ToLower().Contains(search.ToLower()) || x.Students.Name.ToString().ToLower().Contains(search.ToLower())).Include(y => y.Students).Include(z => z.Books).Include(z => z.Books.Categories).Include(z => z.Books.BookPictures).Include(z => z.Students.StudentPictures).Include(z => z.Students.Departments).ToList();
                }
                else if (sortDir == "asc")
                {
                    issues = _LMContext.Issues.OrderBy(x => columnNameAsc).Include(y => y.Students).Include(z => z.Books).Include(z => z.Books.Categories).Include(z => z.Books.BookPictures).Include(z => z.Students.StudentPictures).Include(z => z.Students.Departments).ToList();
                }
                else
                {
                    issues = _LMContext.Issues.OrderBy(x => columnNameDsc).Include(y => y.Students).Include(z => z.Books).Include(z => z.Books.Categories).Include(z => z.Books.BookPictures).Include(z => z.Students.StudentPictures).Include(z => z.Students.Departments).ToList();
                }
                return issues;
            }
        }
        public override Issue GetDataById(int id)
        {
            using (var _LMContext = new LMContext())
            {
                return _LMContext.Issues.Where(x => x.ID == id).Include(y => y.Books).Include(w => w.Students).FirstOrDefault();
            }
        }
        
    }
}
