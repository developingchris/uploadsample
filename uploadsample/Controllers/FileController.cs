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
        public FileController()
        {
        }

        public FileController(PictureUploads uploader)
        {
            _pictures = uploader;
        }

        private PictureUploads _pictures;

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _pictures = new PictureUploads(ControllerContext);
            base.OnActionExecuting(filterContext);
        }


        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase picture)
        {
            if (_pictures.IsImage(picture))
            {
                _pictures.Save(picture);
            }
            else
            {
                TempData["Error"] = "Sorry, Please upload images to take part in the chase.";
            }
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
