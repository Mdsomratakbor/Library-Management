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
                menus = _LMContext.MenuRoles.OrderBy(x => columnNameAsc).ToList();
            }

            else if (sortDir == "dsc" && string.IsNullOrEmpty(search) == false)
            {
                menus = _LMContext.MenuRoles.OrderBy(x => columnNameDsc).ToList();

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

        public List<MenuRole> GetAllMenu(string userName)
        {
            try
            {
                List<MenuRole> menuRole = new List<MenuRole>();
                var user = _LMContext.Users.Where(x => x.UserName == userName).FirstOrDefault();
                var userRoles = user.Roles.Select(x => x.RoleId).ToList();
                menuRole = _LMContext.MenuRoles.Where(x => userRoles.Contains(x.RoleId)).Include(y => y.Menus).ToList();
                foreach (var data in menuRole)
                {
                    GetAllData();
                }
                return menuRole;
            }
            catch(Exception ex)
            {
                throw ex;
            }
           
        }
    }
}
