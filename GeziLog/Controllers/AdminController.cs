using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GeziLog.Models.Classes;

namespace GeziLog.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin (blogları listeleme)

        Context contextAdmin = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var values = contextAdmin.Blogs.ToList();
            return View(values);
        }

        // GET: Admin (blog ekleme)
        [HttpGet]
        public ActionResult NewBlog()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewBlog(Blog b)
        {
            contextAdmin.Blogs.Add(b);
            contextAdmin.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Admin (blog silme)
        public ActionResult DeleteBlog(int id)
        {
            var findedBlog = contextAdmin.Blogs.Find(id);
            contextAdmin.Blogs.Remove(findedBlog);
            contextAdmin.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Admin (blog güncelleme)
        public ActionResult GetBlog(int id)
        {
            var findedBlog2 = contextAdmin.Blogs.Find(id);
            return View("GetBlog", findedBlog2);
        }
        public ActionResult UpdateBlog(Blog b)
        {
            var findedBlog3 = contextAdmin.Blogs.Find(b.ID);
            findedBlog3.Title = b.Title;
            findedBlog3.Content = b.Content;
            findedBlog3.PhotoBlogURL = b.PhotoBlogURL;
            findedBlog3.Date = b.Date;
            contextAdmin.SaveChanges();
            return RedirectToAction("Index");
        }




        // GET: Admin (yorum listesi)
        public ActionResult CommentList()
        {
            var comments = contextAdmin.Comments.ToList();
            return View(comments);
        }

        // GET: Admin (yorum silme)
        public ActionResult DeleteComment(int id)
        {
            var deleteComment = contextAdmin.Comments.Find(id);
            contextAdmin.Comments.Remove(deleteComment);
            contextAdmin.SaveChanges();
            return RedirectToAction("CommentList");
        }

        // GET: Admin (yorum getir)
        public ActionResult GetComment(int id)
        {
            var comment = contextAdmin.Comments.Find(id);
            return View("GetComment", comment);
        }





        // GET: Admin (about listeleme)
        public ActionResult AboutList()
        {
            var abouts = contextAdmin.Abouts.ToList();
            return View(abouts);
        }

        // GET: Admin (about ekleme)
        [HttpGet]
        public ActionResult NewAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewAbout(About a)
        {
            contextAdmin.Abouts.Add(a);
            contextAdmin.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Admin (about silme)
        public ActionResult DeleteAbout(int id)
        {
            var findedAbout = contextAdmin.Abouts.Find(id);
            contextAdmin.Abouts.Remove(findedAbout);
            contextAdmin.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Admin (about güncelleme)
        public ActionResult GetAbout(int id)
        {
            var findedAbout = contextAdmin.Abouts.Find(id);
            return View("GetAbout", findedAbout);
        }
        public ActionResult UpdateAbout(About a)
        {
            var findedAbout2 = contextAdmin.Abouts.Find(a.ID);
            findedAbout2.Content = a.Content;
            findedAbout2.PhotoAboutURL = a.PhotoAboutURL;
            contextAdmin.SaveChanges();
            return RedirectToAction("Index");
        }



        //Toplam Yorum Listeleme
        public PartialViewResult TotalComment()
        {
            var tc = contextAdmin.Counters.ToList();
            return PartialView(tc);
        }



        // GET: Admin (contact listeleme)
        public ActionResult ContactList()
        {
            var contacts = contextAdmin.Contacts.ToList();
            return View(contacts);
        }

        // GET: Admin (contact silme)
        public ActionResult DeleteContact(int id)
        {
            var findedContact = contextAdmin.Contacts.Find(id);
            contextAdmin.Contacts.Remove(findedContact);
            contextAdmin.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}