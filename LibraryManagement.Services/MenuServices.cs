using LibraryManagement.Entities;
using LibraryManagement.Services.Abstractclass;
using LibraryManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Services
{
    public class MenuServices : LibraryManagementServices<Menu>, IMenuServices
    {
        public List<Menu> GetAllData(int displayLength, int displayStart, int sortCol, string sortDir, string search = null)
        {
            throw new NotImplementedException();
        }
    }
}
