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
    public class CategoryServices : ICategoryService
    {
        

        public List<Category> GetAllData(int displayLength, int displayStart, int sortCol, string sortDir, string search = null)
        {
            using (var _LMContext = new LMContext())
            {
                string columnNameAsc = "";
                string columnNameDsc = "";
                List<Category> categories = new List<Category>();
                if (sortCol == 0 && sortDir == "asc") columnNameAsc = "Name";
                else if (sortCol == 0 && sortDir == "dsc") columnNameDsc = "Name";
                else if (sortCol == 1 && sortDir == "asc") columnNameAsc = "Description";
                else if (sortCol == 1 && sortDir == "dsc") columnNameDsc = "Description";
                if (sortDir == "asc" && string.IsNullOrEmpty(search) == false)
                {
                    categories = _LMContext.Categories.OrderBy(x => columnNameAsc).Where(x => x.Name.ToString().ToLower().Contains(search.ToLower()) || x.Description.ToString().ToLower().Contains(search.ToLower())).ToList();
                }

                else if (sortDir == "dsc" && string.IsNullOrEmpty(search) == false)
                {
                    categories = _LMContext.Categories.OrderBy(x => columnNameDsc).Where(x => x.Name.ToString().ToLower().Contains(search.ToLower()) || x.Description.ToString().ToLower().Contains(search.ToLower())).ToList();
                }
                else if (sortDir == "asc")
                {
                    categories = _LMContext.Categories.OrderBy(x => columnNameAsc).ToList();
                }
                else
                {
                    categories = _LMContext.Categories.OrderBy(x => columnNameDsc).ToList();
                }
                return categories;
            }
        }

        public List<Category> GetAllCategory()
        {
            using (var _LMContext = new LMContext())
            {
                return _LMContext.Categories.ToList();
            }
        }
        public int TotalRowCount()
        {
            using (var _LMContext = new LMContext())
            {
                return _LMContext.Categories.Count();
            }
        }

        public Category GetDataById(int id)
        {
            using (var _LMContext = new LMContext())
            {
                return _LMContext.Categories.Where(x => x.ID == id).FirstOrDefault();
            }
        }

        public bool SaveData(Category model)
        {
            using (var _LMContext = new LMContext())
            {
                _LMContext.Categories.Add(model);
                return _LMContext.SaveChanges() > 0;
            }
        }

      

        public bool UpdateData(Category model)
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
                var category = _LMContext.Categories.Find(id);
                _LMContext.Entry(category).State = System.Data.Entity.EntityState.Modified;
                _LMContext.Categories.Remove(category);
                return _LMContext.SaveChanges() > 0;
            }
        }
    }
}
