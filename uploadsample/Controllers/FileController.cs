using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace uploadsample.Controllers
{
    public class FileController : Controller
    {
        private PictureUploads _pictures;

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _pictures = new PictureUploads(ControllerContext);
            base.OnActionExecuting(filterContext);
        }


        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase picture)
        {
            _pictures.Save(picture);
            return View();
        }

        public ActionResult List()
        {
            var images = _pictures.GetThumbnailPaths();
            ViewData["images"] = images;
            return View();
        }

        public ActionResult CleanUpUserContent()
        {
            _pictures.CleanOutContent();
            return Redirect("/");
        }
    }
}
