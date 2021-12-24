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


        //Yorum listesi
        public ActionResult CommentList()
        {
            var comments = contextAdmin.Comments.ToList();
            return View(comments);
        }

        //Yorum silme
        public ActionResult DeleteComment(int id)
        {
            var deleteComment = contextAdmin.Comments.Find(id);
            contextAdmin.Comments.Remove(deleteComment);
            contextAdmin.SaveChanges();
            return RedirectToAction("CommentList");
        }

        //yorum getir
        public ActionResult GetComment(int id)
        {
            var comment = contextAdmin.Comments.Find(id);
            return View("GetComment", comment);
        }

        ////Yorum güncelle
        //public ActionResult UpdateComment(Comment c)
        //{
        //    var comment = contextAdmin.Comments.Find(c.ID);
        //    comment.UserName =c.UserName;
        //    comment.Mail =c.Mail;
        //    comment.CommentArea =c.CommentArea;
        //    contextAdmin.SaveChanges();
        //    return RedirectToAction("CommentList");
        //}

    }
}