using LibraryManagement.Entities;
using LibraryManagement.Web.ViewModels.MenuInterfaces;
using LibraryManagement.Web.ViewModels.MenuRoleInterfaces;
using LibraryManagement.Web.ViewModels.RoleInterfaces;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagement.Web.ViewModels
{
    public class MenuRoleActionModel : IMenuRole, IMenuList, IRoleList
    {
        public int ID { get; set; }
        public int RoleId { get; set; }
        public int MenuId { get; set; }
        public bool IsUpdate { get; set; }
        public bool IsDelete { get; set; }
        public bool IsCreate { get; set; }
        public List<Menu> Menus { get; set; }
        public List<IdentityRole> Roles { get; set; }     
        public DateTime? EntryDate { get; set; }
        public int? LUserID { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateLUserID { get; set; }
        List<System.Web.UI.WebControls.Menu> IMenuRole.Menus { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}