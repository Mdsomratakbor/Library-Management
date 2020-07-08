using LibraryManagement.Entities;
using LibraryManagement.Services;
using LibraryManagement.Services.Interfaces;
using LibraryManagement.Web.ViewModels;
using LibraryManagement.Web.ViewModels.CategoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Web.Controllers
{
    [HandleError]
    public class CategoryController : Controller
    {
        private ICategoryService _ICategoryService;
        private ICategory _ICategory;
        private Category _category;
        public CategoryController()
        {
            _ICategoryService = new CategoryServices();
            _ICategory = new CategoryActionModel();
        }
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> Action(int? id)
        {
            if (id > 0)
            {
                _category = await Task.Run(() => _ICategoryService.GetDataById(id.Value));
                _ICategory.ID = _category.ID;
                _ICategory.Name = _category.Name;
                _ICategory.Description = _category.Description;
            }
            return View(_ICategory);
        }
        [HttpPost]
        public JsonResult Action(CategoryActionModel model)
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            var message = "";
            bool isSuccess = false;
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.ID > 0)
                    {
                        _category = _ICategoryService.GetDataById(model.ID);
                        _category.Name = model.Name;
                        _category.Description = model.Description;
                        isSuccess = _ICategoryService.UpdateData(_category);
                    }
                    else
                    {
                        _category.ID = model.ID;
                        _category.Name = model.Name;
                        _category.Description = model.Description;
                        isSuccess = _ICategoryService.SaveData(_category);
                    }
                }
                else
                {
                    message = string.Join("; ", ModelState.Values
                                           .SelectMany(x => x.Errors)
                                           .Select(x => x.ErrorMessage));
                }

            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            if (isSuccess)
            {
                message = "Data Save Successfully!!";
                result.Data = new { Success = true, Message = message };
            }
            else
            {
                result.Data = new { Success = false, Message = message };
            }
            return result;
        }

        public async Task<JsonResult> ListOfCategory(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch)
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