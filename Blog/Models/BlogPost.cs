using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Areas.Blog.Models
{
    public class BlogPost
    {
        public int BlogPostID { get; set; }
        [Display(Prompt = "Enter you title here.")]
        public string Title { get; set; }
        public string Content { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Posted { get; set; }
        public string Author { get; set; }

		// Navigation property
		public virtual List<Comment> Comments { get; set; }
	}
}