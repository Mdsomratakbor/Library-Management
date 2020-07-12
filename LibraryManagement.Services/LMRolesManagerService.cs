using LibraryManagement.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Services
{
    public class LMRolesManagerService :RoleManager<IdentityRole>
    {
        public LMRolesManagerService(IRoleStore<IdentityRole, string> roleStore):base(roleStore)
        {
            
        }
        public static LMRolesManagerService Create(IdentityFactoryOptions<LMRolesManagerService>options, IOwinContext context)
        {
            return new LMRolesManagerService(new RoleStore<IdentityRole>(context.Get<LMContext>()));
        }
    }
}
