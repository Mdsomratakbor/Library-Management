using LibraryManagement.Web.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Web.ViewModels.MenuInterfaces
{
    public interface IMenu : IBaseEntities
    {
         string MenuName { get; set; }
         string Controller { get; set; }
         string Action { get; set; }
         string ProjectName { get; set; }
         int ParentId { get; set; }
         bool IsParent { get; set; }
         bool IsActive { get; set; }
         string Icon { get; set; }
    }
}
