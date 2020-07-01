using LibraryManagement.Entities;
using LibraryManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Web.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult ListOfBook(int displayLength, int displayStart, int sortCol, string sortDir, string search = null)
        {
            int firstRecord = displayStart;
            int lastRecord = displayStart + displayLength;
            int rowNumber;
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            List<Book> Books = new List<Book>();

            Books = BookService.Instance.GetAllBook(displayLength, displayStart, sortCol, sortDir, search);
            rowNumber = Books.Count();
            Books = Books.Where(x => rowNumber > firstRecord && rowNumber < lastRecord).ToList();
            result.Data = new
            {
                iTotalRecords = BookService.Instance.TotalRowCount(),
                iTotalDisplayRecords = rowNumber,
                aaData = Books
            };
            return result;
        }
}
}