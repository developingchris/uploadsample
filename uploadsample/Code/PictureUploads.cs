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
        private string _small_pattern = "{0}_small{1}";

        public void CleanOutContent()
        {
            var di = UserContent();
            di.Delete(true);
        }

        public List<string> GetThumbnailPaths()
        {
            var paths = new List<string>();
            var content = UserContent();
            var basepath = _context.HttpContext.Server.MapPath("/");
            foreach (var file in (content.GetFiles(string.Format(_small_pattern, "*", ".*")) ?? new FileInfo[0]))
            {
                paths.Add("/"+file.FullName.Replace(basepath, "").Replace("\\", "/"));
            }
            return paths;
        }

        public void Save(HttpPostedFileBase picture)
        {
            var content = UserContent();
            string fileName = Path.Combine(content.FullName,Guid.NewGuid().ToString() + Path.GetFileName(picture.FileName));
            
            picture.SaveAs(fileName);
            ResizeOrMove(fileName);
        }

        private void ResizeOrMove(string fileName)
        {
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
            string directory = Path.GetDirectoryName(fileName);
            string small_filename = string.Format(_small_pattern, Path.GetFileNameWithoutExtension(fileName), Path.GetExtension(fileName));

            return Path.Combine(directory, small_filename);
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

        private DirectoryInfo UserContent()
        {
            DirectoryInfo di = new DirectoryInfo(_context.HttpContext.Server.MapPath("UserContent"));
            if (!di.Exists)
            {
                di.Create();
            }
            return di;
        }

    }
}