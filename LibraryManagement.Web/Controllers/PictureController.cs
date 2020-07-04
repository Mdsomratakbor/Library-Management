using LibraryManagement.Entities;
using LibraryManagement.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Web.Controllers
{
    public class PictureController : Controller
    {
        private PictureServices _PictureServices;

        public PictureController()
        {
            _PictureServices = new PictureServices();

        }
        // GET: Shared
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult UploadPicture()
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            var files = Request.Files;
            List<object> pictuerJSON = new List<object>();
            try
            {
                for (int i = 0; i < files.Count; i++)
                {
                    var picture = files[i];
                    var fileName = Guid.NewGuid() + Path.GetExtension(picture.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/images/BookImage/"), fileName);
                    picture.SaveAs(path);
                    var dbPictuer = new Picture();
                    dbPictuer.URL = fileName;
                    int pictureID = _PictureServices.SavePicture(dbPictuer);
                    pictuerJSON.Add(new { ID = pictureID, URL = dbPictuer.URL });

                }
                result.Data = new { Success = true, pictuerJSON };
            }

            catch (Exception ex)
            {
                result.Data = new { Success = false, Message = ex.Message };
            }
            return result;
        }
    }
}