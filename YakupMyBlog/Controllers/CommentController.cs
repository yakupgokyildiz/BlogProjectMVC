using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YakupMyBlog.Models;

namespace YakupMyBlog.Controllers
{
    public class CommentController : Controller
    {
        Context context = new Context();
        // GET: Comment
        public ActionResult Index()
        {
            return View();


        }
        public ActionResult CommentList()
        {
            return View(context.Comments.ToList());
        }

        public void Delete(int id)
        {
            var data = context.Comments.FirstOrDefault(x => x.CommentId == id);
            context.Comments.Remove(data);
            context.SaveChanges();
        }

        public ActionResult Update(int id)
        {
            return View(context.Comments.FirstOrDefault(x=>x.CommentId==id));
        }

        [HttpPost]
        public ActionResult Update(int CommentId,string Thought)
        {
            var data = context.Comments.FirstOrDefault(x => x.CommentId == CommentId);
            data.Thought = Thought;
            context.SaveChanges();
            return RedirectToAction("CommentList");
        }
    }
}