using LibraryManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Services.Interfaces
{
    interface IServices
    {
        List<T> GetAllData<T>(int displayLength, int displayStart, int sortCol, string sortDir, string search = null);
    }
}
