using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Web.ViewModels.RoleInterfaces
{
    public interface IRoleList
    {
        List<IdentityRole> Roles { get; set; }
    }
}
