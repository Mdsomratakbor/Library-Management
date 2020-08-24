using LibraryManagement.Entities;
using LibraryManagement.Services;
using LibraryManagement.Services.Interfaces;
using LibraryManagement.Web.ViewModels;
using LibraryManagement.Web.ViewModels.MenuRoleInterfaces;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Web.Controllers
{
    public class MenuRoleController : Controller
    {
        private  IMenuRoleService _IMenuRoleService;
        private  IMenuServices _IMenuServices;
        private  IMenuRole _IMenuRole;
        private  LMRolesManagerService _roleManager;
        private  MenuRole _menuRole;
        public LMRolesManagerService RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().GetUserManager<LMRolesManagerService>();
            }
            private set
            {
                _roleManager = value;
            }
        }
        public MenuRoleController()
        {
           
        }
        public MenuRoleController(IMenuRoleService menuroleService, IMenuRole menurole, IMenuServices menuservice)
        {
            _IMenuRoleService = menuroleService;
            _IMenuServices = menuservice;
            _IMenuRole = menurole;
           
            _menuRole = new MenuRole();
        }
        [Authorize(Roles = "Admin, Users, Manager")]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Admin, Manager")]
        public async Task<ActionResult> Action(int? id)
        {
            if (id > 0)
            {
                _menuRole = await Task.Run(() => _IMenuRoleService.GetDataById(id.Value));
                _IMenuRole.ID = _menuRole.ID;
                //_IMenuRole.RoleId = _menuRole.RoleId;
                //_IMenuRole.MenuId = _menuRole.MenuId;
                //_IMenuRole.IsUpdate = _menuRole.IsUpdate;
                //_IMenuRole.IsDelete = _menuRole.IsDelete;
                //_IMenuRole.IsCreate = _menuRole.IsCreate;
            }
           
            var roles = RoleManager.Roles.AsQueryable();
            //List<MenuRole> allRoleMenu = _IMenuRoleService.GetAllData();
            //List<Menu> menus= _IMenuServices.GetAllData();
            _IMenuRole.Menus = _IMenuServices.GetAllData();
            _IMenuRole.Roles = roles.Select(x => x).ToList();
            return View(_IMenuRole);
        }
        [Authorize(Roles = "Admin, Manager")]
        [HttpPost]
        public async Task<JsonResult> Action(MenuRoleActionModel model)
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
                        _menuRole = _IMenuRoleService.GetDataById(model.ID);
                        //_menuRole.RoleId = model.RoleId;
                        //_menuRole.MenuId = model.MenuId;
                        //_menuRole.IsUpdate = model.IsUpdate;
                        //_menuRole.IsDelete = model.IsDelete;
                        //_menuRole.IsCreate = model.IsCreate;
                        _menuRole.UpdateDate = DateTime.Now;
                        isSuccess = _IMenuRoleService.UpdateData(_menuRole);
                    }
                    else
                    {
                        //_menuRole.RoleId = model.RoleId;
                        //_menuRole.MenuId = model.MenuId;
                        //_menuRole.IsUpdate = model.IsUpdate;
                        //_menuRole.IsDelete = model.IsDelete;
                        //_menuRole.IsCreate = model.IsCreate;
                        _menuRole.EntryDate = DateTime.Now;
                        isSuccess = await Task.Run(() => _IMenuRoleService.SaveData(_menuRole));
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

        public async Task<JsonResult> ListOfMenuRole(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch)
        {
            int rowNumber;
            int totalRecord;
            List<MenuRole> menuroles = new List<MenuRole>();
            menuroles = await Task.Run(() => _IMenuRoleService.GetAllData(iDisplayLength, iDisplayStart, iSortCol_0, sSortDir_0, sSearch));
            totalRecord = await Task.Run(() => _IMenuRoleService.TotalRowCount());
            rowNumber = menuroles.Count();
            menuroles = menuroles.Skip(iDisplayStart).Take(iDisplayLength).ToList();
            JsonResult result = new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new
                {
                    iTotalRecords = totalRecord,
                    iTotalDisplayRecords = rowNumber,
                    aaData = menuroles
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
                    data = await Task.Run(() => _IMenuRoleService.DeleteData(id));
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
                _IMenuRoleService = null;
                _IMenuRole = null;
                _menuRole = null;
            }
        }
        ~MenuRoleController()
        {
            Dispose(false);
        }
    }
}