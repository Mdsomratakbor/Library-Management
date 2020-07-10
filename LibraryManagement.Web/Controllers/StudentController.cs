using LibraryManagement.Entities;
using LibraryManagement.Services;
using LibraryManagement.Services.Interfaces;
using LibraryManagement.Web.ViewModels;
using LibraryManagement.Web.ViewModels.StudentInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Web.Controllers
{
    [HandleError]
    public class StudentController : Controller
    {
        // GET: Student
        private Student _Student;
        private IStudent _IStudent;
        private IStudentServices _IStudentServices;
        private IDepartmentServices _IDepartmentServices;

        public StudentController()
        {
            _Student = new Student();
            //_IStudent = new BookActionModel();
            _IStudentServices = new StudentServices();
            _IDepartmentServices = new DepartmentServices();
        }
        // GET: Book
        public ActionResult Index()
        {
                return View();           
        }
        public async Task<ActionResult> Action(int? id)
        {
            if (id > 0)
            {
                _Student = await Task.Run(() => _IStudentServices.GetDataById(id.Value));
                _IStudent.ID = _Student.ID;
                _IStudent.Name = _Student.Name;
                _IStudent.Phone = _Student.Phone;
                _IStudent.Address = _Student.Address;
                _IStudent.City = _Student.City;
                _IStudent.Email = _Student.Email;
                _IStudent.DepartmentID = _Student.DepartmentID;
                _IStudent.Semester = _Student.Semester;
                _IStudent.Pictures = _Student.StudentPictures;
                _IStudent.DepartmentID = _Student.DepartmentID;
                _IStudent.Code = "STD-000"+ await Task.Run(()=>_IStudentServices.TotalRowCount());
            }
            _IStudent.Departments = await Task.Run(() => _IDepartmentServices.GetAllDepartment());
            return View(_IStudent);
        }
        [HttpPost]
        public async Task<JsonResult> Action(StudentActionModel model)
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            var message = "";
            bool isSuccess = false;
            List<Picture> pictures = new List<Picture>();
            try
            {
                if (ModelState.IsValid)
                {
                    if (!string.IsNullOrEmpty(model.PictureIDs))
                    {
                        List<int> picturesIDs = model.PictureIDs.Split(',').Select(x => int.Parse(x)).ToList();
                        pictures = await Task.Run(() => PictureServices.Instance.GetPicturesByIDs(picturesIDs));
                    }
                    if (model.ID > 0)
                    {
                        _Student = await Task.Run(() => _IStudentServices.GetDataById(model.ID));
                        _Student.BookPictures.Clear();
                        _Student.BookPictures = new List<BookPicture>();
                        _Student.BookPictures.AddRange(pictures.Select(x => new BookPicture() { PictureID = x.ID, BookID = model.ID }));
                        _Student.BookName = model.BookName;
                        _Student.AuthorName = model.AuthorName;
                        _Student.PurchaseDate = model.PurchaseDate;
                        _Student.Isbn = model.Isbn;
                        _Student.BookPublish = model.BookPublish;
                        _Student.Price = model.Price;
                        _Student.BookEdition = model.BookEdition;
                        _Student.BookQty = model.BookQty;
                        _Student.CategoryID = model.CategoryID;
                        isSuccess = _IStudentServices.UpdateData(_Student);
                    }
                    else
                    {
                        _Student.BookPictures = new List<BookPicture>();
                        _Student.BookPictures.AddRange(pictures.Select(x => new BookPicture() { PictureID = x.ID }));
                        _Student.ID = model.ID;
                        _Student.BookName = model.BookName;
                        _Student.AuthorName = model.AuthorName;
                        _Student.PurchaseDate = model.PurchaseDate;
                        _Student.Isbn = model.Isbn;
                        _Student.BookPublish = model.BookPublish;
                        _Student.Price = model.Price;
                        _Student.BookEdition = model.BookEdition;
                        _Student.BookQty = model.BookQty;
                        _Student.CategoryID = model.CategoryID;
                        isSuccess = _IStudentServices.SaveData(_Student);
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
        public async Task<JsonResult> ListOfBook(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch)
        {
            int rowNumber;
            int totalRecord;
            List<Student> students = new List<Student>();
            students = await Task.Run(() => _IStudentServices.GetAllData(iDisplayLength, iDisplayStart, iSortCol_0, sSortDir_0, sSearch));
            totalRecord = await Task.Run(() => _IStudentServices.TotalRowCount());
            rowNumber = students.Count();
            students = students.Skip(iDisplayStart).Take(iDisplayLength).ToList();
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = new
            {
                iTotalRecords = totalRecord,
                iTotalDisplayRecords = rowNumber,
                aaData = students
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
                    data = await Task.Run(() => _IStudentServices.DeleteData(id));
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