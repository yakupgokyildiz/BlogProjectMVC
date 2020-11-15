using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YakupMyBlog.Models;

namespace YakupMyBlog.Controllers
{
    public class HomeController : Controller
    {
        Context context = new Context();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BlogList()
        {
            var data = context.Blogs.ToList();
            return View("BlogListWidget",data);
        }

        public PartialViewResult LastBlogsListWidget()
        {
            var data = context.Blogs.OrderByDescending(x => x.UploadDate).Take(3).ToList();
            return PartialView(data);
        }

        public ActionResult Search(String search)
        {
            var data = context.Blogs.Where(x => x.Title.Contains(search)).ToList();
            return PartialView("BlogListWidget", data);
        }
    }
}