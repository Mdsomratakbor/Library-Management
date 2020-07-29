using LibraryManagement.Entities;
using LibraryManagement.Web.ViewModels.MenuInterfaces;
using LibraryManagement.Web.ViewModels.MenuRoleInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagement.Web.ViewModels
{
    public class MenuActionModel : IMenuRole, IMenuList, IRoleList
    {
        public int RoleId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int MenuId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsUpdate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsDelete { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsCreate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<Menu> Menus { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}