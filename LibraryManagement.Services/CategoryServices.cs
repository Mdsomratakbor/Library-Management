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
        public bool DeleteData(int id)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAllData(int displayLength, int displayStart, int sortCol, string sortDir, string search = null)
        {
            throw new NotImplementedException();
        }

        public Category GetDataById(int id)
        {
            throw new NotImplementedException();
        }

        public bool SaveData(Category model)
        {
            throw new NotImplementedException();
        }

        public int TotalRowCount()
        {
            throw new NotImplementedException();
        }

        public bool UpdateData(Category model)
        {
            throw new NotImplementedException();
        }
    }
}
