using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Web.Controllers.Custom_Error
{
    [Authorize]
    public class ErrorController : Controller
    {
        public ActionResult NotFoundPage()
        {
            return View();
        }
        public ActionResult ServiceUnavailableErrorPage()
        {
            return View();
        }
        public ActionResult ForbiddenPage()
        {
            return View();
        }
        public ActionResult IntervalServerErroPage()
        {
            return View();
        }
        public ActionResult BadRequestErroPage()
        {
            return View();
        }
        public ActionResult RequestErroPage()
        {
            return View();
        }
        public ActionResult BadGatewayErrorPage()
        {
            return View();
        }
    }
}