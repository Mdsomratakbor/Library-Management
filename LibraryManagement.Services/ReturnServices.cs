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
    public class ReturnServices : LibraryManagementServices<Return>, IReturnServices
    {
        private readonly IBookService _IBookService;
        public ReturnServices(IBookService bookService)
        {
            _IBookService = bookService;
        }
        public List<Return> GetAllData(int displayLength, int displayStart, int sortCol, string sortDir, string search = null)
        {
            using (var _LMContext = new LMContext())
            {
                string columnNameAsc = "";
                string columnNameDsc = "";
                List<Return> Returns = new List<Return>();
                if (sortCol == 0 && sortDir == "asc") columnNameAsc = "BookID";
                else if (sortCol == 0 && sortDir == "dsc") columnNameDsc = "BookID";
                else if (sortCol == 1 && sortDir == "asc") columnNameAsc = "ReturnDate";
                else if (sortCol == 1 && sortDir == "dsc") columnNameDsc = "ReturnDate";
                else if (sortCol == 1 && sortDir == "asc") columnNameAsc = "ExpiraryDate";
                else if (sortCol == 1 && sortDir == "dsc") columnNameDsc = "ExpiraryDate";
                else if (sortCol == 1 && sortDir == "asc") columnNameAsc = "StudentID";
                else if (sortCol == 1 && sortDir == "dsc") columnNameDsc = "StudentID";
                if (sortDir == "asc" && string.IsNullOrEmpty(search) == false)
                {
                    Returns = _LMContext.Returns.OrderBy(x => columnNameAsc).Where(x => x.Books.BookName.ToString().ToLower().Contains(search.ToLower()) || x.ReturnDate.ToString().ToLower().Contains(search.ToLower()) || x.Students.Name.ToString().ToLower().Contains(search.ToLower())).Include(y => y.Students).Include(z => z.Books.Categories).Include(z => z.Books.BookPictures.Select(y => y.Pictures)).Include(z => z.Students.StudentPictures).Include(z => z.Students.Departments).Include(x=>x.Staffs).Include(x=>x.Staffs.StaffPictures.Select(y=>y.Pictures)).Include(x => x.Staffs.Designations).ToList();
                }

                else if (sortDir == "dsc" && string.IsNullOrEmpty(search) == false)
                {
                    Returns = _LMContext.Returns.OrderBy(x => columnNameDsc).Where(x => x.Books.BookName.ToString().ToLower().Contains(search.ToLower()) || x.ReturnDate.ToString().ToLower().Contains(search.ToLower()) || x.Students.Name.ToString().ToLower().Contains(search.ToLower())).Include(y => y.Students).Include(z => z.Books).Include(z => z.Books.Categories).Include(z => z.Books.BookPictures.Select(y => y.Pictures)).Include(z => z.Students.StudentPictures).Include(z => z.Students.Departments).Include(x => x.Staffs).Include(x => x.Staffs.StaffPictures.Select(y => y.Pictures)).Include(x=>x.Staffs.Designations).ToList();
                }
                else if (sortDir == "asc")
                {
                    Returns = _LMContext.Returns.OrderBy(x => columnNameAsc).Include(y => y.Students).Include(z => z.Books).Include(z => z.Books.Categories).Include(z => z.Books.BookPictures.Select(y => y.Pictures)).Include(z => z.Students.StudentPictures).Include(z => z.Students.Departments).Include(x => x.Staffs).Include(x => x.Staffs.StaffPictures.Select(y => y.Pictures)).Include(x => x.Staffs.Designations).ToList();
                }
                else
                {
                    Returns = _LMContext.Returns.OrderBy(x => columnNameDsc).Include(y => y.Students).Include(z => z.Books).Include(z => z.Books.Categories).Include(z => z.Books.BookPictures.Select(y => y.Pictures)).Include(z => z.Students.StudentPictures).Include(z => z.Students.Departments).Include(x => x.Staffs).Include(x => x.Staffs.StaffPictures.Select(y => y.Pictures)).Include(x => x.Staffs.Designations).ToList();
                }

                return Returns;
            }
        }
        public override Return GetDataById(int id)
        {
            using (var _LMContext = new LMContext())
            {
                return _LMContext.Returns.Where(x => x.ID == id).Include(y => y.Books).Include(w => w.Students).Include(x=>x.Staffs).FirstOrDefault();
            }
        }
        public override bool SaveData(Return model)
        {
            using (var _LMContext = new LMContext())
            {
                int bookId = model.BookID;
                int bookQty = _LMContext.Books.Where(x => x.ID == bookId).Select(x => x.BookQty).FirstOrDefault();
                bookQty += 1;
                var book = _IBookService.GetDataById(bookId);
                book.BookQty = bookQty;
                _IBookService.UpdateData(book);
                var value = base.SaveData(model);
                return value;
            }
        }
        public override bool UpdateData(Return model)
        {
            using (var _LMContext = new LMContext())
            {
                int bookId = model.BookID;
                int bookQty = _LMContext.Books.Where(x => x.ID == bookId).Select(x => x.BookQty).FirstOrDefault();
                bookQty += 1;
                var book = _IBookService.GetDataById(bookId);
                book.BookQty = bookQty;
                _IBookService.UpdateData(book);
                var value = base.UpdateData(model);
                return value;
            }
        }
    }
}
