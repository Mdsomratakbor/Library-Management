using LibraryManagement.Entities;
using LibraryManagement.Services;
using LibraryManagement.Services.Interfaces;
using LibraryManagement.Web.ViewModels;
using LibraryManagement.Web.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Web.Controllers
{
    public class BookController : Controller
    {
        private Book _Book;
        private IBook _IBook;
        private IBookService _IBookService;
        private ICategoryService _ICategoryService;

        public BookController()
        {
            _Book = new Book();
            _IBook = new BookActionModel();
            _IBookService = new BookService();
            _ICategoryService = new CategoryServices();
        }
        // GET: Book
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Action(int? id)
        {
            try
            {
                if (id > 0)
               {
                    _Book = _IBookService.GetDataById(id.Value);
                    _IBook.ID = _Book.ID;
                    _IBook.Isbn = _Book.Isbn;
                    _IBook.BookName = _Book.BookName;
                    _IBook.AuthorName = _Book.AuthorName;
                    _IBook.BookEdition = _Book.BookEdition;
                    _IBook.BookPublish = _Book.BookPublish;
                    _IBook.PurchaseDate = _Book.PurchaseDate;
                    _IBook.Price = _Book.Price;
                    _IBook.Pictures = _Book.BookPictures;
                }
                _IBook.Categories = _ICategoryService.GetAllCategory();
                return View(_IBook);
            }
            catch (Exception ex)
            {
                HandleErrorInfo error = new HandleErrorInfo(ex, "BookController", "Action");
                return View("Error", ex.Message);

            }

        }
        [HttpPost]
        public JsonResult Action(BookActionModel model)
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            var message = "";
            bool isSuccess = false;
            try
            {

                if (ModelState.IsValid)
                {
                    List<int> picturesIDs = model.PictureIDs.Split(',').Select(x => int.Parse(x)).ToList();
                    var pictures = PictureServices.Instance.GetPicturesByIDs(picturesIDs);

                    if (model.ID > 0)
                    {
                        _Book = _IBookService.GetDataById(model.ID);
                        _Book.BookPictures.Clear();
                        _Book.BookPictures = new List<BookPicture>();
                        _Book.BookPictures.AddRange(pictures.Select(x => new BookPicture() { PictureID = x.ID, BookID=model.ID }));           
                        _Book.BookName = model.BookName;
                        _Book.AuthorName = model.AuthorName;
                        _Book.PurchaseDate = model.PurchaseDate;
                        _Book.Isbn = model.Isbn;
                        _Book.BookPublish = model.BookPublish;
                        _Book.Price = model.Price;
                        _Book.BookEdition = model.BookEdition;
                        _Book.BookQty = model.BookQty;
                        isSuccess = _IBookService.UpdateData(_Book);
                    }
                    else
                    {
                        _Book.BookPictures = new List<BookPicture>();
                        _Book.BookPictures.AddRange(pictures.Select(x => new BookPicture() { PictureID = x.ID }));
                        _Book.ID = model.ID;
                        _Book.BookName = model.BookName;
                        _Book.AuthorName = model.AuthorName;
                        _Book.PurchaseDate = model.PurchaseDate;
                        _Book.Isbn = model.Isbn;
                        _Book.BookPublish = model.BookPublish;
                        _Book.Price = model.Price;
                        _Book.BookEdition = model.BookEdition;
                        _Book.BookQty = model.BookQty;
                        isSuccess = _IBookService.SaveData(_Book);
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
            List<Book> Books = new List<Book>();
            Books = await Task.Run(() => _IBookService.GetAllData(iDisplayLength, iDisplayStart, iSortCol_0, sSortDir_0, sSearch));
            totalRecord = await Task.Run(() => _IBookService.TotalRowCount());
            rowNumber = Books.Count();
            Books = Books.Skip(iDisplayStart).Take(iDisplayLength).ToList();
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = new
            {
                iTotalRecords = totalRecord,
                iTotalDisplayRecords = rowNumber,
                aaData = Books
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
                    data = await Task.Run(()=> _IBookService.DeleteData(id));
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