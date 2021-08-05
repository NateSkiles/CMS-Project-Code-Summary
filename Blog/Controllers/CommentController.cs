using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TheatreCMS3.Areas.Blog.Models;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Blog.Controllers
{
    public class CommentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Blog/Comment
        public ActionResult Index()
        {
            return View(db.Comments.ToList());
        }


        // Partial comments view
        public ActionResult Comments(int id)
		{
            return PartialView("_Comments", db.Comments.Where(c => c.BlogPostID == id).ToList());
		}

        // GET: Blog/Comment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

		// GET: Blog/Comment/Create
		public ActionResult Create(int id)
		{
            ViewBag.BlogPostId = id;
			return View();
		}

		// POST: Blog/Comment/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommentId,Message,CommentDate,Likes,Dislikes")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                // Add blogPostId to comment object
                if (TempData.ContainsKey("BlogPostId"))
                    comment.BlogPostID = Convert.ToInt32(TempData["BlogPostId"]);
                db.Comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Index", "BlogPosts");
            }

            return View(comment);
        }

        // GET: Blog/Comment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Blog/Comment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CommentId,Message,CommentDate,Likes,Dislikes")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comment).State = EntityState.Modified;
                db.Entry(comment).Property(c => c.BlogPostID).IsModified = false;
                db.SaveChanges();
                return RedirectToAction("Index", "BlogPosts");
            }
            return View(comment);
        }

        // POST: Blog/Comment/Delete/5
        [HttpPost]
        public async Task<JsonResult> Delete(int id)
		{
            Comment comment = await db.Comments.FindAsync(id);
            db.Comments.Remove(comment);
            db.SaveChanges();
            return Json(new { success = true, id = comment.CommentId });
        }

        // POST: Blog/Comment/Upvote/5
        [HttpPost]
        public async Task<JsonResult> Upvote(int id)
        {
            Comment comment = await db.Comments.FindAsync(id);
			comment.Likes++;
            db.SaveChanges();
            return Json(new { success = true, message = comment.Likes, id = comment.CommentId, ratio = comment.LikeRatio() });
        }
            
        // POST: Blog/Comment/Downvote/5
        [HttpPost]
        public async Task<JsonResult> Downvote(int id)
		{
            Comment comment = await db.Comments.FindAsync(id);
            comment.Dislikes++;
            db.SaveChanges();
            return Json(new { success = true, message = comment.Dislikes, id = comment.CommentId, ratio = comment.LikeRatio() });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
