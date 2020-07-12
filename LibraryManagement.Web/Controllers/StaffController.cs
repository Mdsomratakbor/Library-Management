using LibraryManagement.Entities;
using LibraryManagement.Services;
using LibraryManagement.Services.Enums;
using LibraryManagement.Services.Interfaces;
using LibraryManagement.Web.ViewModels;
using LibraryManagement.Web.ViewModels.StaffInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Web.Controllers
{
    [HandleError]
    public class StaffController : Controller
    {
        // GET: Staff
        // GET: Staff
        private Staff _Staff;
        private IStaff _IStaff;
        private IStaffServices _IStaffServices;
        private IDesigantionServices _IDesigantionServices;

        public StaffController(IStaffServices staffServices, IStaff staff, IDesigantionServices designationServices)
        {
            _Staff = new Staff();
            _IStaff = staff;
            _IStaffServices = staffServices;
            _IDesigantionServices = designationServices;
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
                _Staff = await Task.Run(() => _IStaffServices.GetDataById(id.Value));
                _IStaff.ID = _Staff.ID;
                _IStaff.Name = _Staff.Name;
                _IStaff.Phone = _Staff.Phone;
                _IStaff.Contact = _Staff.Contact;
                _IStaff.Address = _Staff.Address;
                _IStaff.City = _Staff.City;
                _IStaff.Email = _Staff.Email;
                _IStaff.DesignationID = _Staff.DesignationID;
                _IStaff.Pictures = _Staff.StaffPictures;
                _IStaff.Gender = _Staff.Gender;
            }
            _IStaff.Designations = await Task.Run(() => _IDesigantionServices.GetAllData());
            _IStaff.Genders = Enum.GetValues(typeof(GenderEnums)).Cast<GenderEnums>().ToList();
            return View(_IStaff);
        }
        [HttpPost]
        public async Task<JsonResult> Action(StaffActionModel model)
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
                        List<int> picturesIDs = model.PictureIDs.Split(',').Select(x => int.Parse(x)).ToList();
                        pictures = await Task.Run(() => PictureServices.Instance.GetPicturesByIDs(picturesIDs));
                    }
                    if (model.ID > 0)
                    {
                        _Staff = await Task.Run(() => _IStaffServices.GetDataById(model.ID));
                        _Staff.StaffPictures.Clear();
                        _Staff.StaffPictures = new List<StaffPicture>();
                        _Staff.StaffPictures.AddRange(pictures.Select(x => new StaffPicture() { PictureID = x.ID, StaffID = model.ID }));
                        _Staff.Name = model.Name;
                        _Staff.Phone = model.Phone;
                        _Staff.Address = model.Address;
                        _Staff.City = model.City;
                        _Staff.Email = model.Email;
                        _Staff.DesignationID = model.DesignationID;
                        _Staff.Contact = model.Contact;
                        _Staff.Gender = model.Gender;
                        isSuccess = _IStaffServices.UpdateData(_Staff);
                    }
                    else
                    {
                        _Staff.StaffPictures = new List<StaffPicture>();
                        _Staff.StaffPictures.AddRange(pictures.Select(x => new StaffPicture() { PictureID = x.ID }));
                        _Staff.Name = model.Name;
                        _Staff.Phone = model.Phone;
                        _Staff.Address = model.Address;
                        _Staff.City = model.City;
                        _Staff.Email = model.Email;
                        _Staff.DesignationID = model.DesignationID;
                        _Staff.Contact = model.Contact;
                        _Staff.Gender = model.Gender;
                        isSuccess = _IStaffServices.SaveData(_Staff);
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
        public async Task<JsonResult> ListOfStaff(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch)
        {
            int rowNumber;
            int totalRecord;
            List<Staff> Staffs = new List<Staff>();
            Staffs = await Task.Run(() => _IStaffServices.GetAllData(iDisplayLength, iDisplayStart, iSortCol_0, sSortDir_0, sSearch));
            totalRecord = await Task.Run(() => _IStaffServices.TotalRowCount());
            rowNumber = Staffs.Count();
            Staffs = Staffs.Skip(iDisplayStart).Take(iDisplayLength).ToList();
            JsonResult result = new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new
                {
                    iTotalRecords = totalRecord,
                    iTotalDisplayRecords = rowNumber,
                    aaData = Staffs
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
                    data = await Task.Run(() => _IStaffServices.DeleteData(id));
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
                _IStaff = null;
                _IStaffServices = null;
            }
        }
        ~StaffController()
        {
            Dispose(false);
        }
    }
}