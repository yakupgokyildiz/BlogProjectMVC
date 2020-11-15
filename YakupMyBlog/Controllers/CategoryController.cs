using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YakupMyBlog.Models;

namespace YakupMyBlog.Controllers
{
    public class CategoryController : Controller
    {
        Context context = new Context();
        // GET: Category
        public ActionResult Index(int id)
        {
            return View(id);
        }

        public PartialViewResult CategoryWidget()
        {
            var data = context.Categories.ToList();
            return PartialView(data);
        }

        public ActionResult BlogList(int id)
        {
            var data = context.Blogs.Where(x => x.CategoryID == id).ToList();
            return View("BlogListWidget", data);
        }

        public ActionResult CategoryList()
        {
            var data = context.Categories.ToList();
            return View(data);
        }

        public ActionResult Add()
        {
            Category category = new Category();
            return View(category);
        }

        [HttpPost]
        public ActionResult Add(Category category)
        {
            context.Categories.AddOrUpdate(category);
            context.SaveChanges();
            return RedirectToAction("CategoryList");
        }

        public ActionResult Update(int id)
        {
            var data = context.Categories.FirstOrDefault(x => x.CategoryId == id);
            return View("Add", data);
        }

        public void Delete(int id)
        {
            var data = context.Categories.FirstOrDefault(x => x.CategoryId == id);
            context.Categories.Remove(data);
            context.SaveChanges();
        }
    }
}