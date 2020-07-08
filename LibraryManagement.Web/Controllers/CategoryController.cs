using LibraryManagement.Entities;
using LibraryManagement.Services;
using LibraryManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Web.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryService _ICategoryService;
        public CategoryController()
        {
            _ICategoryService = new CategoryServices();
        }
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Action()
        {
            return View();
        }
        public async Task<JsonResult> ListOfBook(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch)
        {
            int rowNumber;
            int totalRecord;
            List<Category> categories = new List<Category>();
            categories = await Task.Run(() => _ICategoryService.GetAllData(iDisplayLength, iDisplayStart, iSortCol_0, sSortDir_0, sSearch));
            totalRecord = await Task.Run(() => _ICategoryService.TotalRowCount());
            rowNumber = categories.Count();
            categories = categories.Skip(iDisplayStart).Take(iDisplayLength).ToList();
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = new
            {
                iTotalRecords = totalRecord,
                iTotalDisplayRecords = rowNumber,
                aaData = categories
            };
            return result;
        }
    }
}