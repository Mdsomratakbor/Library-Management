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

    public class CategoryController : Controller, IDisposable
    {
        private ICategoryService _ICategoryService;
        private ICategory _ICategory;
        private Category _category;
        public CategoryController(ICategoryService categoryService, ICategory categorymodel)
        {
            _ICategoryService = categoryService;
            _ICategory = categorymodel;
            _category = new Category();
        }
        // GET: Category
        [Authorize(Roles = "Admin , User, Manager")]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Admin, Manager")]
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
        [Authorize(Roles = "Admin, Manager")]
        [HttpPost]
        public async Task<JsonResult> Action(CategoryActionModel model)
        {
            JsonResult result = new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
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
                        _category.Name = model.Name;
                        _category.Description = model.Description;
                        isSuccess = await Task.Run(() => _ICategoryService.SaveData(_category));
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
            JsonResult result = new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new
                {
                    iTotalRecords = totalRecord,
                    iTotalDisplayRecords = rowNumber,
                    aaData = categories
                }
            };
            return result;
        }
        [Authorize(Roles = "Admin, Manager")]
        public async Task<JsonResult> Delete(int id)
        {
            JsonResult result = new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
            dynamic message = "";
            var data = false;
            try
            {
                if (id > 0)
                {
                    data = await Task.Run(() => _ICategoryService.DeleteData(id));
                }
                else
                {
                    message = "Please click valid item";
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            if (data)
            {
                message = "Data Delete Successfully !!";
                result.Data = new { Success = true, Message = message };
            }
            else
            {
                result.Data = new { Success = false, Message = message };
            }

            return result;
        }
        public new void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected override void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                _ICategoryService = null;
                _ICategory = null;
                _category = null;
            }
        }
        ~CategoryController()
        {
            Dispose(false);
        }

    }
}