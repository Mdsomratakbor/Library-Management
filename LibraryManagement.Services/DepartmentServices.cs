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
    public class DepartmentServices : IDepartmentServices
    {
        

        public List<Department> GetAllData(int displayLength, int displayStart, int sortCol, string sortDir, string search = null)
        {
            using (var _LMContext = new LMContext())
            {
                string columnNameAsc = "";
                string columnNameDsc = "";
                List<Department> categories = new List<Department>();
                if (sortCol == 0 && sortDir == "asc") columnNameAsc = "Name";
                else if (sortCol == 0 && sortDir == "dsc") columnNameDsc = "Name";
                else if (sortCol == 1 && sortDir == "asc") columnNameAsc = "Description";
                else if (sortCol == 1 && sortDir == "dsc") columnNameDsc = "Description";
                if (sortDir == "asc" && string.IsNullOrEmpty(search) == false)
                {
                    categories = _LMContext.Departments.OrderBy(x => columnNameAsc).Where(x => x.Name.ToString().ToLower().Contains(search.ToLower())).ToList();
                }

                else if (sortDir == "dsc" && string.IsNullOrEmpty(search) == false)
                {
                    categories = _LMContext.Departments.OrderBy(x => columnNameDsc).Where(x => x.Name.ToString().ToLower().Contains(search.ToLower())).ToList();
                }
                else if (sortDir == "asc")
                {
                    categories = _LMContext.Departments.OrderBy(x => columnNameAsc).ToList();
                }
                else
                {
                    categories = _LMContext.Departments.OrderBy(x => columnNameDsc).ToList();
                }
                return categories;
            }
        }
        public int TotalRowCount()
        {
            using (var _LMContext = new LMContext())
            {
                return _LMContext.Departments.Count();
            }
        }

        public Department GetDataById(int id)
        {
            using (var _LMContext = new LMContext())
            {
                return _LMContext.Departments.Where(x => x.ID == id).FirstOrDefault();
            }
        }

        public bool SaveData(Department model)
        {
            using (var _LMContext = new LMContext())
            {
                _LMContext.Departments.Add(model);
                return _LMContext.SaveChanges() > 0;
            }
        }

     

        public bool UpdateData(Department model)
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
                var deparment = _LMContext.Departments.Find(id);
                _LMContext.Entry(deparment).State = System.Data.Entity.EntityState.Modified;
                _LMContext.Departments.Remove(deparment);
                return _LMContext.SaveChanges() > 0;
            }
        }
    }
}
