using LibraryManagement.Entities;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Services
{
    public class LMSignInManagerService : SignInManager<LMUser, string>
    {
        public LMSignInManagerService(LMUserManagerService userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(LMUser user)
        {
            return user.GenerateUserIdentityAsync((LMUserManagerService)UserManager);
        }

        public static LMSignInManagerService Create(IdentityFactoryOptions<LMSignInManagerService> options, IOwinContext context)
        {
            return new LMSignInManagerService(context.GetUserManager<LMUserManagerService>(), context.Authentication);
        }
    }
}
