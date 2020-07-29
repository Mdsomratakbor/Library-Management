using LibraryManagement.Web.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Web.ViewModels.MenuRoleInterfaces
{
    public interface IMenuRole: IBaseEntities
    {
         int RoleId { get; set; }
         int MenuId { get; set; }
         bool IsUpdate { get; set; }
         bool IsDelete { get; set; }
         bool IsCreate { get; set; }
    }
}
