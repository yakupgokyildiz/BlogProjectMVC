using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using YakupMyBlog.Models;

namespace YakupMyBlog.Controllers
{
    public class SecurityController : Controller
    {
        Context context = new Context();
        // GET: Security
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            var data = context.Users.FirstOrDefault(x => x.UserName == user.UserName && x.Password==user.Password);
            if (data!=null)
            {
                FormsAuthentication.SetAuthCookie(data.UserName, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.mesaj = "Kullanıcı adı veya şifre hatalı";
            }
            return View();
        }

        public ActionResult Logout(User user)
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}