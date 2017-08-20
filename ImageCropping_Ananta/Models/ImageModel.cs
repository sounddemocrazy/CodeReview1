using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImageCropping_Ananta.Models
{
    public class ImageModel
    {
        public int Id { get; set; }
        public string ImageName { get; set; }
        public byte[] Image { get; set; }
        public string coordinateX { get; set; }
        public string CordinateY { get; set; }
        public string Height { get; set; }
        public string Width { get; set; }
        public string leftCropped { get; set; }
        public string topCropped { get; set; }

        public string putData { get; set; }
    }
}