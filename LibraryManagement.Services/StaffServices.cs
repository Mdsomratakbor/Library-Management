using LibraryManagement.Data;
using LibraryManagement.Entities;
using LibraryManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Services
{
    public class StaffServices : IStaffServices
    {
        public List<Staff> GetAllData(int displayLength, int displayStart, int sortCol, string sortDir, string search)
        {

            using (var _LMContext = new LMContext())
            {
                string columnNameAsc = "";
                string columnNameDsc = "";
                List<Staff> Staffs = new List<Staff>();
                if (sortCol == 0 && sortDir == "asc") columnNameAsc = "Name";
                else if (sortCol == 0 && sortDir == "dsc") columnNameDsc = "Name";
                else if (sortCol == 1 && sortDir == "asc") columnNameAsc = "Contact";
                else if (sortCol == 1 && sortDir == "dsc") columnNameDsc = "Contact";
                else if (sortCol == 2 && sortDir == "asc") columnNameAsc = "Address";
                else if (sortCol == 2 && sortDir == "dsc") columnNameDsc = "Address";
                else if (sortCol == 3 && sortDir == "asc") columnNameAsc = "Gender";
                else if (sortCol == 3 && sortDir == "dsc") columnNameDsc = "Gender";
                else if (sortCol == 4 && sortDir == "asc") columnNameAsc = "Address";
                else if (sortCol == 4 && sortDir == "dsc") columnNameDsc = "Address";
                else if (sortCol == 5 && sortDir == "asc") columnNameAsc = "City";
                else if (sortCol == 5 && sortDir == "dsc") columnNameDsc = "City";
                else if (sortCol == 6 && sortDir == "asc") columnNameAsc = "Phone";
                else if (sortCol == 6 && sortDir == "dsc") columnNameDsc = "Phone";

                if (sortDir == "asc" && string.IsNullOrEmpty(search) == false)
                {
                    Staffs = _LMContext.Staffs.OrderBy(x => columnNameAsc).Where(x => x.Name.ToString().ToLower().Contains(search.ToLower()) || x.Contact.ToString().ToLower().Contains(search.ToLower())  || x.Gender.ToString().ToLower().Contains(search.ToLower()) || x.Email.ToString().ToLower().Contains(search.ToLower()) || x.Address.ToString().ToLower().Contains(search.ToLower()) || x.City.ToString().ToLower().Contains(search.ToLower()) || x.Phone.ToString().ToLower().Contains(search.ToLower())).Include(y => y.StaffPictures.Select(x => x.Pictures)).Include(w => w.Designations).ToList();
                }

                else if (sortDir == "dsc" && string.IsNullOrEmpty(search) == false)
                {
                    Staffs = _LMContext.Staffs.OrderBy(x => columnNameDsc).Where(x => x.Name.ToString().ToLower().Contains(search.ToLower()) || x.Contact.ToString().ToLower().Contains(search.ToLower()) ||  x.Gender.ToString().ToLower().Contains(search.ToLower()) || x.Email.ToString().ToLower().Contains(search.ToLower()) || x.Address.ToString().ToLower().Contains(search.ToLower()) || x.City.ToString().ToLower().Contains(search.ToLower()) || x.Phone.ToString().ToLower().Contains(search.ToLower())).Include(y => y.StaffPictures.Select(x => x.Pictures)).Include(w => w.Designations).ToList();
                }
                else if (sortDir == "asc")
                {
                    Staffs = _LMContext.Staffs.OrderBy(x => columnNameAsc).Include(y => y.StaffPictures.Select(x => x.Pictures)).Include(w => w.Designations).ToList();
                }
                else
                {
                    Staffs = _LMContext.Staffs.OrderBy(x => columnNameDsc).Include(y => y.StaffPictures.Select(x => x.Pictures)).Include(w => w.Designations).ToList();
                }
                return Staffs;
            }

        }
        public int TotalRowCount()
        {
            using (var _LMContext = new LMContext())
            {
                return _LMContext.Staffs.Count();
            }

        }

        public Staff GetDataById(int id)
        {
            using (var _LMContext = new LMContext())
            {
                return _LMContext.Staffs.Where(x => x.ID == id).Include(y => y.StaffPictures.Select(x => x.Pictures)).Include(w => w.Designations).FirstOrDefault();
            }
        }

        public bool SaveData(Staff model)
        {
            using (var _LMContext = new LMContext())
            {
                _LMContext.Staffs.Add(model);
                return _LMContext.SaveChanges() > 0;
            }
        }

        public bool UpdateData(Staff model)
        {
            using (var _LMContext = new LMContext())
            {
                var existingStaff = _LMContext.Staffs.Find(model.ID);
                _LMContext.StaffPictures.RemoveRange(existingStaff.StaffPictures);
                _LMContext.Entry(existingStaff).CurrentValues.SetValues(model);
                _LMContext.StaffPictures.AddRange(model.StaffPictures);
                return _LMContext.SaveChanges() > 0;
            }
        }
        public bool DeleteData(int id)
        {
            using (var _LMContext = new LMContext())
            {
                var Staff = _LMContext.Staffs.Find(id);
                _LMContext.Entry(Staff).State = System.Data.Entity.EntityState.Modified;
                _LMContext.Staffs.Remove(Staff);
                return _LMContext.SaveChanges() > 0;
            }
        }
    }
}
