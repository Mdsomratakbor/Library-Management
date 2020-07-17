using LibraryManagement.Entities;
using LibraryManagement.Services.Interfaces;
using LibraryManagement.Web.ViewModels;
using LibraryManagement.Web.ViewModels.IssueInterfaces;
using LibraryManagement.Web.ViewModels.ReturnInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Web.Controllers
{
    public class ReturnController : Controller
    {
        // GET: Return
        private Return _entity;
        private readonly IReturn _IReturn;
        private readonly IReturnServices _IReturnServices;
        private readonly IStudentServices _IStudentServices;
        private readonly IBookService _IBookService;
        private readonly IStaffServices _IStaffServices;

        public ReturnController(IReturnServices IssueService, IStudentServices studentService, IBookService bookservices, IReturn Issuemodel, IStaffServices staffSevices)
        {
            _entity = new Return();
            _IReturnServices = IssueService;
            _IStudentServices = studentService;
            _IBookService = bookservices;
            _IReturn = Issuemodel;
            _IStaffServices = staffSevices;
        }
        // GET: Issue
        public ActionResult Index()
        {

            return View();
        }
        public async Task<ActionResult> Action(int? id)
        {
            if (id > 0)
            {
                _entity = await Task.Run(() => _IReturnServices.GetDataById(id.Value));
                _IReturn.ID = _entity.ID;
                _IReturn.ReturnDate = _entity.ReturnDate;
                _IReturn.StudentID = _entity.StudentID;
                _IReturn.BookID = _entity.BookID;
                _IReturn.StaffID = _entity.StaffID;
            }
            _IReturn.Students = await Task.Run(() => _IStudentServices.GetAllData());
            _IReturn.Books = await Task.Run(() => _IBookService.GetAllData());
            _IReturn.Staffs = await Task.Run(() => _IStaffServices.GetAllData());
            return View(_IReturn);
        }
        [HttpPost]
        public async Task<JsonResult> Action(ReturnActionModel model)
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
                        _entity.ID = model.ID;
                        _entity.ReturnDate = model.ReturnDate;
                        _entity.StudentID = model.StudentID;
                        _entity.StaffID = model.StaffID;
                        _entity.BookID = model.BookID;
                        _entity.UpdateDate = model.UpdateDate;
                        _entity.UpdateLUserID = model.UpdateLUserID;
                        isSuccess = await Task.Run(() => _IReturnServices.UpdateData(_entity));
                    }
                    else
                    {
                        _entity.ReturnDate = model.ReturnDate;
                        _entity.StudentID = model.StudentID;
                        _entity.StaffID = model.StaffID;
                        _entity.StudentID = model.StudentID;
                        _entity.BookID = model.BookID;
                        _entity.EntryDate = model.EntryDate;
                        _entity.LUserID = model.LUserID;
                        isSuccess = await Task.Run(() => _IReturnServices.SaveData(_entity));
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
        public async Task<JsonResult> ListOfReturn(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch)
        {
            int rowNumber;
            int totalRecord;
            List<Return> returns = new List<Return>();
            returns = await Task.Run(() => _IReturnServices.GetAllData(iDisplayLength, iDisplayStart, iSortCol_0, sSortDir_0, sSearch));
            totalRecord = await Task.Run(() => _IReturnServices.TotalRowCount());
            rowNumber = returns.Count();
            returns = returns.Skip(iDisplayStart).Take(iDisplayLength).ToList();
            JsonResult result = new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new
                {
                    iTotalRecords = totalRecord,
                    iTotalDisplayRecords = rowNumber,
                    aaData = returns
                }
            };
            return result;
        }

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
                    data = await Task.Run(() => _IReturnServices.DeleteData(id));
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
    }
}