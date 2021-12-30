using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using GeziLog.Models.Classes;

namespace GeziLog.Controllers
{
    public class LoginController : Controller
    {
        Context context = new Context();
        
        //GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            var information = context.Admins.FirstOrDefault(x => x.User == admin.User && x.Password==admin.Password);
            if (information != null)
            {
                FormsAuthentication.SetAuthCookie(information.User,false);
                Session["Kullanici"] = information.User.ToString();
                return RedirectToAction("Index","Admin");
            }
            else
            {
                return View();
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }
    }
}