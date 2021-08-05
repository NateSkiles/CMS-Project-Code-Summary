using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Blog.Models
{
    public class PostMaster : ApplicationUser
    {
        public int PublishedBlogPosts { get; set; }
        public int RejectedBlogPosts { get; set; }
        public int PendingBlogPosts { get; set; }
    }
}