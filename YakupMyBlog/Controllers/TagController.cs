using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YakupMyBlog.Models;

namespace YakupMyBlog.Controllers
{
    public class TagController : Controller
    {
        Context context = new Context();
        // GET: Tag
        public ActionResult Index(int id)
        {
            return View(id);
        }

        public PartialViewResult TagWidget()
        {
            var data = context.Tags.ToList();
            return PartialView(data);
        }

        public ActionResult BlogList(int id)
        {
            //var data = context.Blogs.Where(x => x.Tags.Any(y => y.TagId == id)).ToList();
            var data = context.Blogs.Where(x => x.BlogTags.Any(y => y.TagID == id)).ToList();
            return View("BlogListWidget", data);
        }

        public ActionResult TagList()
        {
            var data = context.Tags.ToList();
            return View(data);
        }

        public ActionResult Add()
        {
            Tag tag = new Tag();
            return View(tag);
        }

        [HttpPost]
        public ActionResult Add(Tag tag)
        {
            context.Tags.AddOrUpdate(tag);
            context.SaveChanges();
            return RedirectToAction("TagList");
        }

        public ActionResult Update(int id)
        {
            var data = context.Tags.FirstOrDefault(x => x.TagId == id);
            return View("Add", data);
        }

        public void Delete(int id)
        {
            var data = context.Tags.FirstOrDefault(x => x.TagId == id);
            context.Tags.Remove(data);
            context.SaveChanges();
        }
    }
}