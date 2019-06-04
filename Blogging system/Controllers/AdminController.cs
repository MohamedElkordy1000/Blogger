using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Blogging_system.Models;

namespace Blogging_system.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/
        public ActionResult Index()
        {
            return RedirectToAction("IndexArticles");
        }

        // GET: Admin/IndexArticles
        public ActionResult IndexArticles()
        {
            var articles = db.Articles.Include(a => a.Category);
            return View(articles.ToList());
        }

        // GET: Admin/ArticleDetails/5
        public ActionResult ArticleDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // GET: Admin/CreateArticle
        public ActionResult CreateArticle()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Category_Name");
            return View();
        }

        // POST: Admin/CreateArticle
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateArticle([Bind(Include = "ArticleId,ArticleTitle,ArticleBody,Publish_date,CategoryId")] Article article)
        {
            if (ModelState.IsValid)
            {
                db.Articles.Add(article);
                db.SaveChanges();
                return RedirectToAction("IndexArticles");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Category_Name", article.CategoryId);
            return View(article);
        }

        // GET: Admin/EditArticle/5
        public ActionResult EditArticle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Category_Name", article.CategoryId);
            return View(article);
        }

        // POST: Admin/EditArticle/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditArticle([Bind(Include = "ArticleId,ArticleTitle,ArticleBody,Publish_date,CategoryId")] Article article)
        {
            if (ModelState.IsValid)
            {
                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("IndexArticles");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Category_Name", article.CategoryId);
            return View(article);
        }

        // GET: Admin/DeleteArticle/5
        public ActionResult DeleteArticle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Admin/DeleteArticle/5
        [HttpPost, ActionName("DeleteArticle")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteArticleConfirmed(int id)
        {
            Article article = db.Articles.Find(id);
            db.Articles.Remove(article);
            db.SaveChanges();
            return RedirectToAction("IndexArticles");
        }

        // GET: Admin/IndexCategories
        public ActionResult IndexCategories()
        {
            return View(db.Categories.ToList());
        }

        // GET: Admin/CategoryDetails/5
        public ActionResult CategoryDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Admin/CreateCategory
        public ActionResult CreateCategory()
        {
            return View();
        }

        // POST: Admin/CreateCategory
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCategory([Bind(Include = "CategoryId,Category_Name")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("IndexCategories");
            }

            return View(category);
        }

        // GET: Admin/EditCategory/5
        public ActionResult EditCategory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Admin/EditCategory/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCategory([Bind(Include = "CategoryId,Category_Name")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("IndexCategories");
            }
            return View(category);
        }

        // GET: Admin/DeleteCategory/5
        public ActionResult DeleteCategory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Admin/DeleteCategory/5
        [HttpPost, ActionName("DeleteCategory")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCategoryConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("IndexCategories");
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
