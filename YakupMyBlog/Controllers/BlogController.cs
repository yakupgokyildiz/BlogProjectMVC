using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YakupMyBlog.App_Classes;
using YakupMyBlog.Models;

namespace YakupMyBlog.Controllers
{
    public class BlogController : Controller
    {
        Context context = new Context();
        // GET: Blog
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BlogDetail(int id)
        {
            var data = context.Blogs.FirstOrDefault(x => x.BlogId == id);
            return View(data);
        }

        public ActionResult BlogList()
        {
            return View(context.Blogs.ToList());
        }

        public ActionResult Add()
        {
            Blog blog = new Blog();

            ViewBag.Categories = context.Categories.ToList();
            //ViewBag.Tag = context.Tags.ToList();
            return View(blog);
        }
        [HttpPost]
        public ActionResult Add(Blog blog, HttpPostedFileBase fileUpload)
        {
            if (fileUpload != null)
            {
                blog.UploadDate = DateTime.Now;
                blog.View = 0;
                blog.Like = 0;
                System.Drawing.Image image = System.Drawing.Image.FromStream(fileUpload.InputStream);
                Bitmap smallImage = new Bitmap(image, Settings.ImageSmallSize);
                Bitmap mediumImage = new Bitmap(image, Settings.ImageMediumSize);
                Bitmap bigImage = new Bitmap(image, Settings.ImageBigSize);

                string smallPath = "/Content/BlogImage/Small/" + Guid.NewGuid() + Path.GetExtension(fileUpload.FileName);
                string mediumPath = "/Content/BlogImage/Medium/" + Guid.NewGuid() + Path.GetExtension(fileUpload.FileName);
                string bigPath = "/Content/BlogImage/Big/" + Guid.NewGuid() + Path.GetExtension(fileUpload.FileName);

                smallImage.Save(Server.MapPath(smallPath));
                mediumImage.Save(Server.MapPath(mediumPath));
                bigImage.Save(Server.MapPath(bigPath));
                context.Blogs.AddOrUpdate(blog);
                context.SaveChanges();
                YakupMyBlog.Models.Image img = new YakupMyBlog.Models.Image();
                
                img.BlogID = blog.BlogId;
                img.SmallSize = smallPath;
                img.MediumSize = mediumPath;
                img.BigSize = bigPath;

                context.Images.AddOrUpdate(img);
                context.SaveChanges();

                return RedirectToAction("BlogList");
            }
            else
            {
                return RedirectToAction("Add");
            }


        }

        public ActionResult Update(int id)
        {
            ViewBag.Categories = context.Categories.ToList();
            var data = context.Blogs.FirstOrDefault(x => x.BlogId == id);

            return View("Add", data);
        }

        public void Delete(int id)
        {

            var dataBlogTag = context.BlogTags.Where(x => x.BlogID == id).ToList();

            foreach (var item in dataBlogTag)
            {
                context.BlogTags.Remove(item);

            }
            var dataComment = context.Comments.Where(x => x.BlogID == id).ToList();
            foreach (var item in dataComment)
            {
                context.Comments.Remove(item);
            }
            var dataBlog = context.Blogs.FirstOrDefault(x => x.BlogId == id);
            var dataImage = context.Images.FirstOrDefault(x => x.BlogID == id);
            
            
            
            context.Images.Remove(dataImage);
            context.Blogs.Remove(dataBlog);
            context.SaveChanges();

        }

        public ActionResult Comment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Comment(Comment comment)
        {
            Comment c = new Comment();
            c.Username = comment.Username;
            c.Email = comment.Email;
            c.Thought = comment.Thought;
            c.UploadDate = DateTime.Now;
            c.BlogID = comment.BlogID;
           
            context.Comments.Add(c);
            context.SaveChanges();
            return RedirectToAction("BlogDetail",new { id=comment.BlogID});


        }

        public void BlogLike(int id)
        {
            var data = context.Blogs.FirstOrDefault(x => x.BlogId == id);
            data.Like++;
            context.SaveChanges();
        }
    }
}