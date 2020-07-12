using LibraryManagement.Services;
using LibraryManagement.Services.Interfaces;
using LibraryManagement.Web.ViewModels;
using LibraryManagement.Web.ViewModels.DepartmentInterfaces;
using LibraryManagement.Web.ViewModels.Interfaces;
using LibraryManagement.Web.ViewModels.StaffInterfaces;
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
            container.RegisterType<IStaffServices, StaffServices>();
            container.RegisterType<IStaff, StaffActionModel>();
            container.RegisterType<IDesigantionServices, DesignationServices>();
            container.RegisterType<IBookService, BookService>();
            container.RegisterType<IBook, BookActionModel>();
            container.RegisterType<ICategoryService, CategoryServices>();
            container.RegisterType<IDepartment, DepartmentActionModel>();
            

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}