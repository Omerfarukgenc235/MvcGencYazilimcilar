using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        BlogManager bm = new BlogManager(new EfBlogDal());
        AuthorManager cm = new AuthorManager(new EfAuthorDal());

        [AllowAnonymous]

        public PartialViewResult AuthorAbout(int id)
        {
            var yazar = bm.GetBlogByBlog(id);
            return PartialView(yazar);
        }
        [AllowAnonymous]

        public PartialViewResult AuthorPopularPost(int id)
        {
            var blogauthorid = bm.GetList().Where(x => x.BlogID == id).Select(y => y.AuthorID).FirstOrDefault();
            var yazarblog = bm.GetBlogByAuthor(blogauthorid).OrderByDescending(x => x.BlogID).Take(3);
            return PartialView(yazarblog);
        }

        public ActionResult AuthorList()
        {
           var yazarlistesi = cm.GetList();
            return View(yazarlistesi);
        }
        [HttpGet]
        public ActionResult AddAuthor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAuthor(Author p)
        {
            cm.AuthorAdd(p);
            return RedirectToAction("AuthorList");
        }
        [HttpGet]
        public ActionResult AuthorEdit(int id)
        {
            var author = cm.GetByID(id);
            return View(author);
        }
        [HttpPost]
        public ActionResult AuthorEdit(Author p)
        {
            cm.AuthorUpdate(p);
            return RedirectToAction("AuthorList");
        }

    }
}