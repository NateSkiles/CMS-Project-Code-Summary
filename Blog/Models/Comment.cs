using System;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Blog.Models
{
	public class Comment
	{
		// Props
		public int CommentId { get; set; }
		public ApplicationUser Author { get; set; }
		public string Message { get; set; }
		public DateTime CommentDate { get; set; }
		public int Likes { get; set; } = 0;
		public int Dislikes { get; set; } = 0;

		// Fully defined navigation property
		public virtual int BlogPostID { get; set; }
		public virtual BlogPost BlogPost { get; set; }

		// Comment Constructor
		public Comment()
		{
			CommentDate = DateTime.Now;
		}

		// Return percentage of likes to total votes
		public string LikeRatio()
		{
			double maximum = Likes + Dislikes;
			string ratio = (Likes / maximum).ToString("0.00%");

			return ratio;
		}

		public string TimeAgo()
		{
			var ts = new TimeSpan(DateTime.Now.Ticks - CommentDate.Ticks);
			double delta = Math.Abs(ts.TotalSeconds);

			// Less than a second
			if (delta < 60)
			{
				return ts.Seconds == 1 ? "one second ago" : ts.Seconds + " seconds ago";
			}
			// Less than minute
			if (delta < 60 * 2)
			{
				return "a minute ago";
			}
			// Minutes
			if (delta < 45 * 60)
			{
				return ts.Minutes + " minutes ago";
			}
			// More than an hour, less than two
			if (delta < 90 * 60)
			{
				return "an hour ago";
			}
			// Hours
			if (delta < 24 * 60 * 60)
			{
				return ts.Hours + " hours ago";
			}
			// More than a day, less than two
			if (delta < 48 * 60 * 60)
			{
				return "yesterday";
			}
			// Days
			if (delta < 30 * 24 * 60 * 60)
			{
				return ts.Days + " days ago";
			}
			// If more than a month but less than two, or months
			if (delta < 12 * 30 * 24 * 60 * 60)
			{
				int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
				return months <= 1 ? "one month ago" : months + " months ago";
			}
			// If more than a year but less than two, or years
			int years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
			return years <= 1 ? "one year ago" : years + " years ago";
		}
	}
}