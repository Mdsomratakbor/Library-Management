using LibraryManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Services.Interfaces
{
    public interface IServices<T> where T: class
    {
        List<T> GetAllData(int displayLength, int displayStart, int sortCol, string sortDir, string search = null);
        int TotalRowCount();
        T GetDataById(int id);
        bool SaveData(T model);
        bool UpdateData(T model);
        bool DeleteData(int id);
    }
}
