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
        public ActionResult Action(int id)
        {
            return View();

        }
        public JsonResult ListOfBook(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch)
        {
            int firstRecord = iDisplayLength;
            int lastRecord = iDisplayStart + iDisplayLength;
            int rowNumber;
          
            List<Book> Books = new List<Book>();

            Books = BookService.Instance.GetAllBook(iDisplayLength, iDisplayStart, iSortCol_0, sSortDir_0, sSearch);
            rowNumber = Books.Count();
            Books = Books.Skip(iDisplayStart).Take(iDisplayLength).ToList();
              JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
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