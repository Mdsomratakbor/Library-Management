using LibraryManagement.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Data
{
    public class LibraryManagementDBInitializer : CreateDatabaseIfNotExists<LMContext>
    {
        protected override  void Seed(LMContext context)
        {
              SeedRoles(context);
             SeedUser(context);
        }

        private  void SeedRoles(LMContext context)
        {
            var rolesInLibraryManagement = new List<IdentityRole>() 
            { 
                new IdentityRole() {Name="Admin" },
                new IdentityRole() { Name = "Manager" }, 
                new IdentityRole() { Name = "User" }, 
            };
            var rolesStore = new RoleStore<IdentityRole>(context);
            var rolesManager = new RoleManager<IdentityRole>(rolesStore);

            foreach (IdentityRole role in rolesInLibraryManagement)
            {
                if (!rolesManager.RoleExists(role.Name))
                {
                    var result =  rolesManager.Create(role);

                    if (result.Succeeded) continue;
                }
            }
        }
        private  void SeedUser(LMContext context)
        {
            var usersStore = new UserStore<LMUser>(context);
            var usersManager = new UserManager<LMUser>(usersStore);
            var user = new LMUser();
            {
                user.Email = "somrat876@gmail.com";
                user.UserName = "admin";
            }
            var password = "admin1234";
            if (usersManager.FindByEmailAsync(user.Email) == null)
            {
                var result =  usersManager.Create(user, password);

                if (result.Succeeded)
                {
                    //add necessary roles to admin
                    usersManager.AddToRole(user.Id, "Admin");
                }
            }
        }
    }
}
