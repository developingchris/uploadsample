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
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase picture)
        {
            var content = UserContent();
            if (!content.Exists)
            {
                content.Create();
            }

            picture.SaveAs(Path.Combine(content.FullName, Path.GetFileName(picture.FileName)));

            return View();
        }

        public ActionResult List()
        {
            var di = UserContent();

            var images = new List<string>();

            foreach (var file in di.GetFiles())
            {
                images.Add("/UserContent/" + file.Name);
            }
            ViewData["images"] = images;

            return View();
        }

        private DirectoryInfo UserContent()
        {
            DirectoryInfo di = new DirectoryInfo(Server.MapPath("UserContent"));
            return di;
        }

        public ActionResult CleanUpUserContent()
        {
            var di = UserContent();
            di.Delete(true);
            di.Create();
            return Redirect("/");
        }

    }
}
