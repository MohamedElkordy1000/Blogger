using Blogging_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Blogging_system.Controllers
{
    [Authorize(Roles = "Member")]
    public class MemberController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Memeber/
        public ActionResult Index()
        {
            return RedirectToAction("IndexArticles");
        }

        // GET: Member/IndexArticles
        public ActionResult IndexArticles()
        {
            var articles = db.Articles.Include(a => a.Category);
            return View(articles.ToList());
        }
        public ActionResult CustomSearch(string search_param, string searchtext)
        {
            List<Article> articles = new List<Article>();
            switch (search_param)
            {
                case "Year":
                    articles = db.Articles.Where(b => b.Publish_date.ToString().Contains(searchtext)).ToList();
                    break;
                case "Category":
                    articles = db.Articles.Where(b => b.Category.Category_Name.Contains(searchtext)).ToList();
                    break;
                case "Title":
                    articles = db.Articles.Where(b => b.ArticleTitle.Contains(searchtext)).ToList();
                    break;
                case "Others":
                default:
                    articles = db.Articles.Where(b => b.Publish_date.ToString().Contains(searchtext) ||
                                              b.Category.Category_Name.Contains(searchtext) ||
                                              b.ArticleTitle.Contains(searchtext)).ToList();
                    break;
            }
            return View("IndexArticles", articles);
        }


    }
}
