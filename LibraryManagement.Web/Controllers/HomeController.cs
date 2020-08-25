using LibraryManagement.Services;
using LibraryManagement.Services.Interfaces;
using LibraryManagement.Web.ViewModels.HomeInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Web.Controllers
{
    [HandleError]
    [Authorize]
    public class HomeController : Controller
    {
        private IHomeServices _homeServices;
        private IHome _model;
        public HomeController(IHomeServices homeServices, IHome model)
        {
            _homeServices = homeServices;
            _model = model;
        }
        public ActionResult Index()
        {
            _model.TotalBooks = _homeServices.TotalBooks();
            _model.TotalIssueBooks = _homeServices.TotalIssueBooks();
            _model.TotalReturnBooks = _homeServices.TotalReturnBooks();
            _model.TotalRoles = _homeServices.TotalRoles();
            _model.TotalStaffs = _homeServices.TotalStaffs();
            _model.TotalStudents = _homeServices.TotalStudents();
            _model.TotalUsers = _homeServices.TotalUsers();
            return View(_model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
         
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}