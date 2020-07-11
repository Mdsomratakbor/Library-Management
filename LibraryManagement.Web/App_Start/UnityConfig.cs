using LibraryManagement.Services;
using LibraryManagement.Services.Interfaces;
using LibraryManagement.Web.ViewModels;
using LibraryManagement.Web.ViewModels.StudentInterfaces;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace LibraryManagement.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
             container.RegisterType<IStudentServices, StudentServices>();
            container.RegisterType<IStudent, StudentActionModel>();
            container.RegisterType<IDepartmentServices, DepartmentServices>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}