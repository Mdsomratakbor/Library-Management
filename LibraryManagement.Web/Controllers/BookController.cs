﻿using LibraryManagement.Entities;
using LibraryManagement.Services;
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
        public BookController()
        {
            _Book = new Book();
            _IBook = new BookActionModel();
        }
        // GET: Book
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Action(int? id)
        {

            return View(_IBook);

        }
        [HttpPost]
        public JsonResult Action(Book model)
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            var message = "";
            bool isSuccess = false;
            try
            {

                if (ModelState.IsValid)
                {
                    //List<int> picturesIDs = model.PictureIDs.Split(',').Select(x => int.Parse(x)).ToList();
                    //var pictures = _SharedService.GetPicturesByIDs(picturesIDs);

                    if (model.ID > 0)
                    {

                        //_AccomodationPackage = _AccomodationPackagesService.GetAccomodationPackagesById(model.ID);
                        //_AccomodationPackage.NoOfRoom = model.NoOfRoom;
                        //_AccomodationPackage.Name = model.Name;
                        //_AccomodationPackage.FeePerNight = model.FeePerNight;
                        //_AccomodationPackage.AccomodationTypeID = model.AccomodationTypeID;
                        //_AccomodationPackage.AccomodationPackagePictures.Clear();
                        //_AccomodationPackage.AccomodationPackagePictures.AddRange(pictures.Select(x => new AccomodationPackagePictures() { PictuerID = x.ID, AccomodationPackageID = model.ID }));
                        //data = _AccomodationPackagesService.UpdateAccomodationPackages(_AccomodationPackage);
                    }
                    else
                    {
                        //_AccomodationPackage.AccomodationPackagePictures = new List<AccomodationPackagePictures>();
                        //_AccomodationPackage.AccomodationPackagePictures.AddRange(pictures.Select(x => new AccomodationPackagePictures() { PictuerID = x.ID }));
                        _Book.ID = model.ID;
                        _Book.BookName = model.BookName;
                        _Book.AuthorName = model.AuthorName;
                        _Book.PurchaseDate = model.PurchaseDate;
                        _Book.Isbn = model.Isbn;
                        _Book.BookPublish = model.BookPublish;
                        _Book.Price = model.Price;
                        _Book.BookEdition = model.BookEdition;
                        _Book.BookQty = model.BookQty;
                        isSuccess = BookService.Instance.SaveBook(_Book);
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
        public async  Task<JsonResult> ListOfBook(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch)
        {
            int rowNumber;       
            List<Book> Books = new List<Book>();
            Books = await BookService.Instance.GetAllBook(iDisplayLength, iDisplayStart, iSortCol_0, sSortDir_0, sSearch);
            rowNumber = Books.Count();
            Books = Books.Skip(iDisplayStart).Take(iDisplayLength).ToList();
              JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = new
            {
                iTotalRecords = await BookService.Instance.TotalRowCount(),
                iTotalDisplayRecords = rowNumber,
                aaData = Books
            };
            return result;
        }
}
}