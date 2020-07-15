using LibraryManagement.Entities;
using LibraryManagement.Services.Interfaces;
using LibraryManagement.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Web.Controllers
{
    public class IssueController : Controller
    {
        // GET: Issue
        private Issue _Issue;
        //private readonly IIssue _IIssue;
        private readonly IIssuServices _IIssuServices;
        private readonly IStudentServices _IStudentServices;
        private readonly IBookService _IBookService;

        public IssueController(IIssuServices IssueService, IStudentServices studentService, IBookService bookservices)
        {
            _Issue = new Issue();
            _IIssuServices = IssueService;
            _IStudentServices = studentService;
            _IBookService = bookservices;
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
                //_IIssue.ID = _Issue.ID;
                //_IIssue.Isbn = _Issue.Isbn;
                //_IIssue.IssueName = _Issue.IssueName;
                //_IIssue.AuthorName = _Issue.AuthorName;
                //_IIssue.IssueEdition = _Issue.IssueEdition;
                //_IIssue.IssuePublish = _Issue.IssuePublish;
                //_IIssue.PurchaseDate = _Issue.PurchaseDate;
                //_IIssue.Price = _Issue.Price;
                //_IIssue.Pictures = _Issue.IssuePictures;
                //_IIssue.CategoryID = _Issue.CategoryID;
            }
            //_IIssue.Categories = await Task.Run(() => _ICategoryService.GetAllData());
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> Action(BookActionModel model)
        {
            JsonResult result = new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
            var message = "";
            bool isSuccess = false;
            List<Picture> pictures = new List<Picture>();
            try
            {
                if (ModelState.IsValid)
                {
                    if (!string.IsNullOrEmpty(model.PictureIDs))
                    {
                        //List<int> picturesIDs = model.PictureIDs.Split(',').Select(x => int.Parse(x)).ToList();
                        //pictures = await Task.Run(() => PictureServices.Instance.GetPicturesByIDs(picturesIDs));
                    }
                    if (model.ID > 0)
                    {
                        _Issue = await Task.Run(() => _IIssuServices.GetDataById(model.ID));
                        //_Issue.IssuePictures.Clear();
                        //_Issue.IssuePictures = new List<IssuePicture>();
                        //_Issue.IssuePictures.AddRange(pictures.Select(x => new IssuePicture() { PictureID = x.ID, IssueID = model.ID }));
                        //_Issue.IssueName = model.IssueName;
                        //_Issue.AuthorName = model.AuthorName;
                        //_Issue.PurchaseDate = model.PurchaseDate;
                        //_Issue.Isbn = model.Isbn;
                        //_Issue.IssuePublish = model.IssuePublish;
                        //_Issue.Price = model.Price;
                        //_Issue.IssueEdition = model.IssueEdition;
                        //_Issue.IssueQty = model.IssueQty;
                        //_Issue.CategoryID = model.CategoryID;
                        isSuccess = _IIssuServices.UpdateData(_Issue);
                    }
                    else
                    {
                        //_Issue.IssuePictures = new List<IssuePicture>();
                        //_Issue.IssuePictures.AddRange(pictures.Select(x => new IssuePicture() { PictureID = x.ID }));
                        //_Issue.ID = model.ID;
                        //_Issue.IssueName = model.IssueName;
                        //_Issue.AuthorName = model.AuthorName;
                        //_Issue.PurchaseDate = model.PurchaseDate;
                        //_Issue.Isbn = model.Isbn;
                        //_Issue.IssuePublish = model.IssuePublish;
                        //_Issue.Price = model.Price;
                        //_Issue.IssueEdition = model.IssueEdition;
                        //_Issue.IssueQty = model.IssueQty;
                        //_Issue.CategoryID = model.CategoryID;
                        isSuccess = _IIssuServices.SaveData(_Issue);
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