using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Blog.Models
{
    public class BlogPhotographer : ApplicationUser
    {
        public string Biography { get; set; }
        public int PhotosAdded { get; set; }

    }
}