using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheatreCMS3.Areas.Blog.Models;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Blog.Controllers
{
    public class BlogAuthorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Blog/BlogAuthors
        public ActionResult Index()
        {
            var foo = db.BlogAuthors.ToList();
            return View(foo);
        }

        // GET: Blog/BlogAuthors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogAuthor blogAuthor = db.BlogAuthors.Find(id);
            if (blogAuthor == null)
            {
                return HttpNotFound();
            }
            return View(blogAuthor);
        }

        // GET: Blog/BlogAuthors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blog/BlogAuthors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BlogAuthorId,Name,Bio,Joined,Left")] BlogAuthor blogAuthor)
        {
            if (ModelState.IsValid)
            {
                db.BlogAuthors.Add(blogAuthor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(blogAuthor);
        }

        // GET: Blog/BlogAuthors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogAuthor blogAuthor = db.BlogAuthors.Find(id);
            if (blogAuthor == null)
            {
                return HttpNotFound();
            }
            return View(blogAuthor);
        }

        // POST: Blog/BlogAuthors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BlogAuthorId,Name,Bio,Joined,Left")] BlogAuthor blogAuthor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blogAuthor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blogAuthor);
        }

        // GET: Blog/BlogAuthors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogAuthor blogAuthor = db.BlogAuthors.Find(id);
            if (blogAuthor == null)
            {
                return HttpNotFound();
            }
            return View(blogAuthor);
        }

        // POST: Blog/BlogAuthors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BlogAuthor blogAuthor = db.BlogAuthors.Find(id);
            db.BlogAuthors.Remove(blogAuthor);
            db.SaveChanges();
            return RedirectToAction("Index");
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
