using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GeziLog.Models.Classes;

namespace GeziLog.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Index

        public ActionResult Index()
        {
            return View();
        }

        // GET: About

        Context contextAbout = new Context();
        public ActionResult About()
        {
            var values = contextAbout.Abouts.ToList();
            return View(values);
        }

        // GET: Contact

        public ActionResult Contact()
        {
            return View();
        }

        // GET: Blogs

        Context contextBlogs = new Context();
        public ActionResult Blogs()
        {
            var values = contextBlogs.Blogs.ToList(); 
            return View(values);
        }

        // GET: Single

        public ActionResult Single(int id)
        {
            var findBlog = contextBlogs.Blogs.Where(x=>x.ID == id).ToList();
            return View(findBlog);
        }
    }
}