using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;
using System.Drawing;

namespace uploadsample
{
    public class PictureUploads
    {
        public PictureUploads(ControllerContext context)
        {
            _context = context;
        }

        private ControllerContext _context;

        public void CleanOutContent()
        {
            var di = UserContent();
            di.Delete(true);
            di.Create();
        }

        private DirectoryInfo UserContent()
        {
            DirectoryInfo di = new DirectoryInfo(_context.HttpContext.Server.MapPath("UserContent"));
            return di;
        }

        public List<string> GetThumbnailPaths()
        {
            var paths = new List<string>();
            var content = UserContent();
            foreach (var file in content.GetFiles("*_small.*"))
            {
                paths.Add("/File/UserContent/" + file.Name);
            }
            return paths;
        }

        public void Save(HttpPostedFileBase picture)
        {
            var content = UserContent();
            if (!content.Exists)
            {
                content.Create();
            }

            string fileName = Path.Combine(content.FullName,Guid.NewGuid().ToString() + Path.GetFileName(picture.FileName));
            picture.SaveAs(fileName);

            Image image = Image.FromFile(fileName);
            if (ResizeToMax(ref image, 500, 700))
            {
                image.Save(SmallName(fileName));
            }
            else
            {
                image.Dispose();
                var file = new FileInfo(fileName);
                file.MoveTo(SmallName(fileName));
            }
        }

        private string SmallName(string fileName)
        {
            return Path.Combine(Path.GetDirectoryName(fileName),Path.GetFileNameWithoutExtension(fileName) + "_small" + Path.GetExtension(fileName));
        }

        private bool ResizeToMax(ref Image inImage, int MaxWidth, int MaxHeight)
        {
            bool resized = false;
            if (inImage.Width > MaxWidth || inImage.Height > MaxHeight)
            {
                int finalWidth = Math.Min(inImage.Width, MaxWidth);

                int finalHeight = inImage.Height * finalWidth / inImage.Width;
                if (finalHeight > MaxHeight)
                {
                    finalWidth = inImage.Width * MaxHeight / inImage.Height;
                    finalHeight = MaxHeight;
                }

                resized = true;
                inImage = inImage.GetThumbnailImage(finalWidth, finalHeight, null, IntPtr.Zero);
            }
            return resized;
        }
    }
}