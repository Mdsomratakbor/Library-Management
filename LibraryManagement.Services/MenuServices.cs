using LibraryManagement.Data;
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
        private readonly LMContext _LMContext;
        public MenuServices()
        {
            _LMContext = new LMContext();
        }
        public List<Menu> GetAllData(int displayLength, int displayStart, int sortCol, string sortDir, string search = null)
        {
            
                string columnNameAsc = "";
                string columnNameDsc = "";
                List<Menu> menus = new List<Menu>();
                if (sortCol == 0 && sortDir == "asc") columnNameAsc = "MenuName";
                else if (sortCol == 0 && sortDir == "dsc") columnNameDsc = "MenuName";
                if (sortDir == "asc" && string.IsNullOrEmpty(search) == false)
                {
                menus = _LMContext.Menus.OrderBy(x => columnNameAsc).Where(x => x.MenuName.ToString().ToLower().Contains(search.ToLower())).ToList();
                }

                else if (sortDir == "dsc" && string.IsNullOrEmpty(search) == false)
                {
                menus = _LMContext.Menus.OrderBy(x => columnNameDsc).Where(x => x.MenuName.ToString().ToLower().Contains(search.ToLower())).ToList();
                }
                else if (sortDir == "asc")
                {
                menus = _LMContext.Menus.OrderBy(x => columnNameAsc).ToList();
                }
                else
                {
                menus = _LMContext.Menus.OrderBy(x => columnNameDsc).ToList();
                }
                return menus;
            
        }
    }
}
