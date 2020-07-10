using LibraryManagement.Data;
using LibraryManagement.Entities;
using LibraryManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Services
{
    public class DesignationServices : IDesigantionServices
    {   
        public List<Designation> GetAllData(int displayLength, int displayStart, int sortCol, string sortDir, string search = null)
        {
            using (var _LMContext = new LMContext())
            {
                string columnNameAsc = "";
                string columnNameDsc = "";
                List<Designation> categories = new List<Designation>();
                if (sortCol == 0 && sortDir == "asc") columnNameAsc = "Name";
                else if (sortCol == 0 && sortDir == "dsc") columnNameDsc = "Name";
                else if (sortCol == 1 && sortDir == "asc") columnNameAsc = "Description";
                else if (sortCol == 1 && sortDir == "dsc") columnNameDsc = "Description";
                if (sortDir == "asc" && string.IsNullOrEmpty(search) == false)
                {
                    categories = _LMContext.Designations.OrderBy(x => columnNameAsc).Where(x => x.Name.ToString().ToLower().Contains(search.ToLower())).ToList();
                }

                else if (sortDir == "dsc" && string.IsNullOrEmpty(search) == false)
                {
                    categories = _LMContext.Designations.OrderBy(x => columnNameDsc).Where(x => x.Name.ToString().ToLower().Contains(search.ToLower())).ToList();
                }
                else if (sortDir == "asc")
                {
                    categories = _LMContext.Designations.OrderBy(x => columnNameAsc).ToList();
                }
                else
                {
                    categories = _LMContext.Designations.OrderBy(x => columnNameDsc).ToList();
                }
                return categories;
            }
        }
        public List<Designation> GetAllDesignation()
        {
            using (var _LMContext = new LMContext())
            {
                return _LMContext.Designations.ToList();
            }
        }
        public int TotalRowCount()
        {
            using (var _LMContext = new LMContext())
            {
                return _LMContext.Designations.Count();
            }
        }
        public Designation GetDataById(int id)
        {
            using (var _LMContext = new LMContext())
            {
                return _LMContext.Designations.Where(x => x.ID == id).FirstOrDefault();
            }
        }
        public bool SaveData(Designation model)
        {
            using (var _LMContext = new LMContext())
            {
                _LMContext.Designations.Add(model);
                return _LMContext.SaveChanges() > 0;
            }
        }    
        public bool UpdateData(Designation model)
        {
            using (var _LMContext = new LMContext())
            {
                _LMContext.Entry(model).State = System.Data.Entity.EntityState.Modified;
                return _LMContext.SaveChanges() > 0;
            }
        }
        public bool DeleteData(int id)
        {
            using (var _LMContext = new LMContext())
            {
                var designation = _LMContext.Designations.Find(id);
                _LMContext.Entry(designation).State = System.Data.Entity.EntityState.Modified;
                _LMContext.Designations.Remove(designation);
                return _LMContext.SaveChanges() > 0;
            }
        }
    }
}
