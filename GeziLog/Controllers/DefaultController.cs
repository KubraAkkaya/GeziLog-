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

        Context contextBlogs = new Context();
        BlogComment bc = new BlogComment();

        // GET: Index

        public ActionResult Index()
        {
            bc.Value3 = contextBlogs.Blogs.OrderByDescending(x=>x.ID).Take(2).ToList();
            return View(bc);
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


        public ActionResult Blogs()
        {
            //var values = contextBlogs.Blogs.ToList(); 
            bc.Value1 = contextBlogs.Blogs.ToList();
            return View(bc);
        }

        // GET: BlogDetails

        
        public ActionResult BlogDetails(int id)
        {
            //var findBlog = contextBlogs.Blogs.Where(x=>x.ID == id).ToList();
            bc.Value1 = contextBlogs.Blogs.Where(x => x.ID == id).ToList();
            bc.Value2 = contextBlogs.Comments.Where(x => x.Blogid == id).ToList();
            return View(bc);
        }

        public PartialViewResult Partial()
        {
            var values = contextBlogs.Blogs.OrderByDescending(x => x.ID).Take(2).ToList();
            return PartialView(values);
        }

        //Context contextComment = new Context();

        // GET: PartialView: ToComment
        [HttpGet]
        public PartialViewResult ToComment(int id)
        {
            ViewBag.value = id;
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult ToComment(Comment c)
        {
            contextBlogs.Comments.Add(c);
            contextBlogs.SaveChanges();
            return PartialView();
        }

        Context contextContacts = new Context();
        // GET: PartialView: ToContact
        [HttpGet]
        public PartialViewResult ToContact()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult ToContact(Contact con)
        {
            contextContacts.Contacts.Add(con);
            contextContacts.SaveChanges();
            return PartialView();
        }

    }
}