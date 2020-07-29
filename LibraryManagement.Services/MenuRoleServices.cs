using LibraryManagement.Data;
using LibraryManagement.Entities;
using LibraryManagement.Services.Abstractclass;
using LibraryManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Services
{
    public class MenuRoleServices : LibraryManagementServices<MenuRole>, IMenuRoleService
    {
        private readonly LMContext _LMContext;
        public MenuRoleServices()
        {
            _LMContext = new LMContext();
        }
        public List<MenuRole> GetAllData(int displayLength, int displayStart, int sortCol, string sortDir, string search = null)
        {

            string columnNameAsc = "";
            string columnNameDsc = "";
            List<MenuRole> menus = new List<MenuRole>();
            if (sortCol == 0 && sortDir == "asc") columnNameAsc = "MenuName";
            else if (sortCol == 0 && sortDir == "dsc") columnNameDsc = "MenuName";
            if (sortDir == "asc" && string.IsNullOrEmpty(search) == false)
            {
                menus = _LMContext.MenuRoles.OrderBy(x => columnNameAsc).Where(x => x.Menus.MenuName.ToString().ToLower().Contains(search.ToLower())).Include(y => y.Menus).ToList();
            }

            else if (sortDir == "dsc" && string.IsNullOrEmpty(search) == false)
            {
                menus = _LMContext.MenuRoles.OrderBy(x => columnNameDsc).Where(x => x.Menus.MenuName.ToString().ToLower().Contains(search.ToLower())).Include(y => y.Menus).ToList();
            }
            else if (sortDir == "asc")
            {
                menus = _LMContext.MenuRoles.OrderBy(x => columnNameAsc).ToList();
            }
            else
            {
                menus = _LMContext.MenuRoles.OrderBy(x => columnNameDsc).ToList();
            }
            return menus;

        }
    }
}
