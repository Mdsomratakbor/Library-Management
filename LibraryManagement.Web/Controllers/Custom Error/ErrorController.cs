using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Web.Controllers.Custom_Error
{
    public class ErrorController : Controller
    {
        public ActionResult NotFoundPage()
        {
            return View();
        }
    }
}