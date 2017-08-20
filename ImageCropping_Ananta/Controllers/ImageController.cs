using ImageCropping_Ananta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImageCropping_Ananta.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image
        public ActionResult Index()
        {
            return View(new ImageModel());
        }
        [HttpPost]
        public ActionResult Image(ImageModel photo, HttpPostedFileBase fileName, string putData)
        {
            if (fileName != null)
            {
                if (ModelState.IsValid)
                {
                    using (var context = new ImageUploadEntities())
                    {
                        var cordinateData = putData.Split(',');
                        var leftData = cordinateData[0].Split(':');
                        photo.leftCropped = leftData[1];

                        var topdata = cordinateData[1].Split(':');
                        photo.topCropped = topdata[1];
                        var widthData = cordinateData[2].Split(':');
                        photo.Width = widthData[1];

                        var heightData = cordinateData[3].Split(':');
                        photo.Height = heightData[1];
                        tbl_Image newImage = new tbl_Image();
                        // fileName = Request.Files["file"];
                        newImage.ImageName = photo.ImageName;
                        newImage.coordinateX = photo.coordinateX;
                        newImage.CordinateY = photo.CordinateY;
                        newImage.Height = photo.Height;
                        newImage.Width = photo.Width;
                        newImage.topCropped = photo.topCropped;
                        newImage.leftCropped = photo.leftCropped;
                        Int32 length = fileName.ContentLength;

                        byte[] tempImage = new byte[length];
                        fileName.InputStream.Read(tempImage, 0, length);
                        newImage.Image = tempImage;
                        context.tbl_Image.Add(newImage);
                        context.SaveChanges();
                        TempData["Message"] = "Successfully Image Uploaded";
                    }
                }
            }
            return View();
        }

    }
}