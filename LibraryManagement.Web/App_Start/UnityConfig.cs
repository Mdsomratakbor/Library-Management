using LibraryManagement.Entities;
using LibraryManagement.Services;
using LibraryManagement.Services.Interfaces;
using LibraryManagement.Web.Controllers;
using LibraryManagement.Web.ViewModels;
using LibraryManagement.Web.ViewModels.CategoryInterfaces;
using LibraryManagement.Web.ViewModels.DepartmentInterfaces;
using LibraryManagement.Web.ViewModels.Interfaces;
using LibraryManagement.Web.ViewModels.IssueInterfaces;
using LibraryManagement.Web.ViewModels.MenuInterfaces;
using LibraryManagement.Web.ViewModels.MenuRoleInterfaces;
using LibraryManagement.Web.ViewModels.ReturnInterfaces;
using LibraryManagement.Web.ViewModels.StaffInterfaces;
using LibraryManagement.Web.ViewModels.StudentInterfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
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
            container.RegisterType<ICategory, CategoryActionModel>();
            container.RegisterType<IIssuServices, IssueServices>();
            container.RegisterType<IIssue, IssueActionModel>();
            container.RegisterType<IReturnServices, ReturnServices>();
            container.RegisterType<IReturn, ReturnActionModel>();
            container.RegisterType<IMenuServices, MenuServices>();
            container.RegisterType<IMenuRoleService, MenuRoleServices>();
            container.RegisterType<IMenuRole, MenuRoleActionModel>();
            container.RegisterType<IMenu, MenuActionModel>();
            container.RegisterType<RolesController>(new InjectionConstructor());
            container.RegisterType<UsersController>(new InjectionConstructor());
            //container.RegisterType<MenuRoleController>(new InjectionConstructor());
            container.RegisterType<AccountController>(new InjectionConstructor());
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}