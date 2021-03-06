﻿using LibraryManagement.Entities;
using LibraryManagement.Services.Interfaces;
using LibraryManagement.Web.ViewModels;
using LibraryManagement.Web.ViewModels.MenuInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Web.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        private IMenuServices _IMenuServices;
        private IMenu _IMenu;
        private Menu _menu;
        public MenuController(IMenuServices menuSerivces, IMenu menu)
        {
            _IMenuServices = menuSerivces;
            _IMenu = menu;
            _menu = new Menu();
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
                _menu = await Task.Run(() => _IMenuServices.GetDataById(id.Value));
                _IMenu.MenuName = _menu.MenuName;
                _IMenu.Controller = _menu.Controller;
                _IMenu.Action = _menu.Action;
                _IMenu.IsParent = _menu.IsParent;
                _IMenu.IsActive = _menu.IsActive;
                _IMenu.ParentId = _menu.ParentId;
                _IMenu.Icon = _menu.Icon;
            }
            return View(_IMenu);
        }
        [Authorize(Roles = "Admin, Manager")]
        [HttpPost]
        public async Task<JsonResult> Action(MenuActionModel model)
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
                        _menu = _IMenuServices.GetDataById(model.ID);
                        _menu.MenuName = model.MenuName;
                        _menu.Controller = model.Controller;
                        _menu.Action = model.Action;
                        _menu.IsParent = model.IsParent;
                        _menu.IsActive = model.IsActive;
                        _menu.ParentId = model.ParentId;
                        _menu.Icon = model.Icon;
                        _menu.UpdateDate = DateTime.Now;
                        isSuccess = _IMenuServices.UpdateData(_menu);
                    }
                    else
                    {
                        _menu.MenuName = model.MenuName;
                        _menu.Controller = model.Controller;
                        _menu.Action = model.Action;
                        _menu.IsParent = model.IsParent;
                        _menu.IsActive = model.IsActive;
                        _menu.ParentId = model.ParentId;
                        _menu.Icon = model.Icon;
                        _menu.EntryDate = DateTime.Now;
                        _menu.ProjectName = "Library Management System";
                        isSuccess = await Task.Run(() => _IMenuServices.SaveData(_menu));
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

        public async Task<JsonResult> ListOfMenu(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch)
        {
            int rowNumber;
            int totalRecord;
            List<Menu> deparments = new List<Menu>();
            deparments = await Task.Run(() => _IMenuServices.GetAllData(iDisplayLength, iDisplayStart, iSortCol_0, sSortDir_0, sSearch));
            totalRecord = await Task.Run(() => _IMenuServices.TotalRowCount());
            rowNumber = deparments.Count();
            deparments = deparments.Skip(iDisplayStart).Take(iDisplayLength).ToList();
            JsonResult result = new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new
                {
                    iTotalRecords = totalRecord,
                    iTotalDisplayRecords = rowNumber,
                    aaData = deparments
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
                    data = await Task.Run(() => _IMenuServices.DeleteData(id));
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
                _IMenuServices = null;
                _IMenu = null;
                _menu = null;
            }
        }
        ~MenuController()
        {
            Dispose(false);
        }

    }
}