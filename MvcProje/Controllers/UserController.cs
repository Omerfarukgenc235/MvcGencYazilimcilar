using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProje.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        // GET: User
        UserProfileManager userprofile = new UserProfileManager();
        BlogManager bm = new BlogManager(new EfBlogDal());

        public ActionResult Index()
        {
   
            return View();
        }
        public PartialViewResult Partial1(string p)
        {
            p = (string)Session["WriterMail"];
            var profilevalues = userprofile.GetAuthorByMail(p);
            return PartialView(profilevalues);
        }
        public ActionResult UpdateUserProfile(Author p)
        {
            userprofile.EditAuthor(p);
            return RedirectToAction("Index");

        }
        public ActionResult BlogList(string p)
        {
            p = (string)Session["WriterMail"];
            Context c = new Context();
            int id = c.Authors.Where(x => x.Mail == p).Select(y => y.AuthorID).FirstOrDefault();
            var blog = userprofile.GetBlogByAuthor(id);
            return View(blog);
        }
        [HttpGet]

        public ActionResult UpdateBlog(int id)
        {
            Blog blog = bm.GetByID(id);
            Context c = new Context();
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.values = values;
            List<SelectListItem> yazar = (from x in c.Authors.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.AuthorName,
                                              Value = x.AuthorID.ToString()
                                          }).ToList();
            ViewBag.yazar = yazar;
            return View(blog);
        }
        [HttpPost]
        public ActionResult UpdateBlog(Blog p)
        {
            bm.BlogUpdate(p);
            return RedirectToAction("BlogList");
        }
        [HttpGet]
        public ActionResult YeniBlog()
        {
            Context c = new Context();
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.values = values;
            return View();
        }
        [HttpPost]
        public ActionResult YeniBlog(Blog b)
        {
            Context c = new Context();
            string p = (string)Session["WriterMail"];
            int yazar = c.Authors.Where(x => x.Mail == p).Select(y => y.AuthorID).FirstOrDefault();
            b.AuthorID = yazar;
            bm.BlogAdd(b);
            return RedirectToAction("BlogList");
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AuthorLogin", "Login");
        }
    }
}