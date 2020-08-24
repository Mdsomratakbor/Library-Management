using LibraryManagement.Entities;
using LibraryManagement.Services;
using LibraryManagement.Services.Interfaces;
using LibraryManagement.Web.ViewModels;
using LibraryManagement.Web.ViewModels.DepartmentInterfaces;
using LibraryManagement.Web.ViewModels.DesignationInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Web.Controllers
{
    [HandleError]
    public class DesignationController : Controller
    {
        // GET: Designation
        private IDesigantionServices _IDesigantionServices;
        private IDesignation _IDesignation;
        private Designation _designation;
        public DesignationController()
        {
            _IDesigantionServices = new DesignationServices();
            _IDesignation = new DesignationActionModel();
            _designation = new Designation();
        }
        [Authorize(Roles = "Admin, User, Manager")]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Admin, Manager")]
        public async Task<ActionResult> Action(int? id)
        {
            if (id > 0)
            {
                _designation = await Task.Run(() => _IDesigantionServices.GetDataById(id.Value));
                _IDesignation.ID = _designation.ID;
                _IDesignation.Name = _designation.Name;
            }
            return View(_IDesignation);
        }
        [Authorize(Roles = "Admin, Manager")]
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
                        _designation = _IDesigantionServices.GetDataById(model.ID);
                        _designation.Name = model.Name;
                        isSuccess = _IDesigantionServices.UpdateData(_designation);
                    }
                    else
                    {
                        _designation.Name = model.Name;
                        isSuccess = await Task.Run(() => _IDesigantionServices.SaveData(_designation));
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

        public async Task<JsonResult> ListOfDesination(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch)
        {
            int rowNumber;
            int totalRecord;
            List<Designation> designations = new List<Designation>();
            designations = await Task.Run(() => _IDesigantionServices.GetAllData(iDisplayLength, iDisplayStart, iSortCol_0, sSortDir_0, sSearch));
            totalRecord = await Task.Run(() => _IDesigantionServices.TotalRowCount());
            rowNumber = designations.Count();
            designations = designations.Skip(iDisplayStart).Take(iDisplayLength).ToList();
            JsonResult result = new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new
                {
                    iTotalRecords = totalRecord,
                    iTotalDisplayRecords = rowNumber,
                    aaData = designations
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
                    data = await Task.Run(() => _IDesigantionServices.DeleteData(id));
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
                _IDesigantionServices = null;
                _IDesignation = null;
                _designation = null;
            }
        }
        ~DesignationController()
        {
            Dispose(false);
        }
    }
}