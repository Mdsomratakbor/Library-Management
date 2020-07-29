using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace LibraryManagement.Web.ViewModels.MenuInterfaces
{
    public interface IMenuList
    {
        List<Menu> Menus { get; set; }
    }
}
