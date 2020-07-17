using LibraryManagement.Entities;
using LibraryManagement.Services.Interfaces;
using LibraryManagement.Web.ViewModels;
using LibraryManagement.Web.ViewModels.IssueInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Web.Controllers
{
    [HandleError]
    [Authorize]
    public class IssueController : Controller
    {
        // GET: Issue
        private Issue _Issue;
        private readonly IIssue _IIssue;
        private readonly IIssuServices _IIssuServices;
        private readonly IStudentServices _IStudentServices;
        private readonly IBookService _IBookService;

        public IssueController(IIssuServices IssueService, IStudentServices studentService, IBookService bookservices, IIssue Issuemodel)
        {
            _Issue = new Issue();
            _IIssuServices = IssueService;
            _IStudentServices = studentService;
            _IBookService = bookservices;
            _IIssue = Issuemodel;
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
                _Issue = await Task.Run(() => _IIssuServices.GetDataById(id.Value));
                _IIssue.ID = _Issue.ID;
                _IIssue.IssueDate = _Issue.IssueDate;
                _IIssue.ExpiraryDate = _Issue.ExpiraryDate;
                _IIssue.StudentID = _Issue.StudentID;
                _IIssue.BookID = _Issue.BookID;
            }
            _IIssue.Students = await Task.Run(() => _IStudentServices.GetAllData());
            _IIssue.Books = await Task.Run(() => _IBookService.GetAllData());
            return View(_IIssue);
        }
        [HttpPost]
        public async Task<JsonResult> Action(IssueActionModel model)
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
                    if (model.ID > 0 )
                    {
                        _Issue.ID = model.ID;
                        _Issue.IssueDate = model.IssueDate;
                        _Issue.ExpiraryDate = model.ExpiraryDate;
                        _Issue.StudentID = model.StudentID;
                        _Issue.BookID = model.BookID;
                        _Issue.UpdateDate = model.UpdateDate;
                        _Issue.UpdateLUserID = model.UpdateLUserID;
                        isSuccess = await Task.Run(()=> _IIssuServices.UpdateData(_Issue));
                    }
                    else
                    {
                        _Issue.IssueDate = model.IssueDate;
                        _Issue.ExpiraryDate = model.ExpiraryDate;
                        _Issue.StudentID = model.StudentID;
                        _Issue.BookID = model.BookID;
                        _Issue.EntryDate = model.EntryDate;
                        _Issue.LUserID = model.LUserID;
                        isSuccess = await Task.Run(() => _IIssuServices.SaveData(_Issue));
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
        public async Task<JsonResult> ListOfIssue(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch)
        {
            int rowNumber;
            int totalRecord;
            List<Issue> Issues = new List<Issue>();
            Issues = await Task.Run(() => _IIssuServices.GetAllData(iDisplayLength, iDisplayStart, iSortCol_0, sSortDir_0, sSearch));
            totalRecord = await Task.Run(() => _IIssuServices.TotalRowCount());
            rowNumber = Issues.Count();
            Issues = Issues.Skip(iDisplayStart).Take(iDisplayLength).ToList();
            JsonResult result = new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new
                {
                    iTotalRecords = totalRecord,
                    iTotalDisplayRecords = rowNumber,
                    aaData = Issues
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
                    data = await Task.Run(() => _IIssuServices.DeleteData(id));
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