using LibraryManagement.Entities;
using LibraryManagement.Services;
using LibraryManagement.Services.Interfaces;
using LibraryManagement.Web.ViewModels;
using LibraryManagement.Web.ViewModels.DepartmentInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Web.Controllers
{
    [HandleError]
    public class DepartmentController : Controller
    {
        // GET: Department
        private IDepartmentServices _IDepartmentServices;
        private IDepartment _IDepartment;
        private Department _deparment;
        public DepartmentController()
        {
            _IDepartmentServices = new DepartmentServices();
            _IDepartment = new DepartmentActionModel();
            _deparment = new Department();
        }
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> Action(int? id)
        {
            if (id > 0)
            {
                _deparment = await Task.Run(() => _IDepartmentServices.GetDataById(id.Value));
                _IDepartment.ID = _deparment.ID;
                _IDepartment.Name = _deparment.Name;
            }
            return View(_IDepartment);
        }
        [HttpPost]
        public async Task<JsonResult> Action(DepartmentActionModel model)
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
                        _deparment = _IDepartmentServices.GetDataById(model.ID);
                        _deparment.Name = model.Name;
                        isSuccess = _IDepartmentServices.UpdateData(_deparment);
                    }
                    else
                    {
                        _deparment.Name = model.Name;
                        isSuccess = await Task.Run(() => _IDepartmentServices.SaveData(_deparment));
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

        public async Task<JsonResult> ListOfDepartment(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch)
        {
            int rowNumber;
            int totalRecord;
            List<Department> deparments = new List<Department>();
            deparments = await Task.Run(() => _IDepartmentServices.GetAllData(iDisplayLength, iDisplayStart, iSortCol_0, sSortDir_0, sSearch));
            totalRecord = await Task.Run(() => _IDepartmentServices.TotalRowCount());
            rowNumber = deparments.Count();
            deparments = deparments.Skip(iDisplayStart).Take(iDisplayLength).ToList();
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = new
            {
                iTotalRecords = totalRecord,
                iTotalDisplayRecords = rowNumber,
                aaData = deparments
            };
            return result;
        }

        public async Task<JsonResult> Delete(int id)
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            dynamic message = "";
            var data = false;
            try
            {
                if (id > 0)
                {
                    data = await Task.Run(() => _IDepartmentServices.DeleteData(id));
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
                _IDepartmentServices = null;
                _IDepartment = null;
                _deparment = null;
            }
        }
        ~DepartmentController()
        {
            Dispose(false);
        }


    }
}