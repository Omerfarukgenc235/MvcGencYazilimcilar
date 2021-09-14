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
    public class AboutController : Controller
    {
        // GET: About
        AboutManager cm = new AboutManager(new EfAboutDal());

        [AllowAnonymous]

        public ActionResult Index()
        {
            var aboutt = cm.GetList();
            return View(aboutt);
        }
        [AllowAnonymous]

        public PartialViewResult Footer()
        {
            var aboutlist = cm.GetList();
            return PartialView(aboutlist);
        }
        [AllowAnonymous]

        public PartialViewResult MeetTheTeem()
        {
            AuthorManager cm = new AuthorManager(new EfAuthorDal());
            var authorlist = cm.GetList();
            return PartialView(authorlist);
        }
        [HttpGet]
        public ActionResult UpdateAboutList()
        {
            var aboutlist = cm.GetList();
            
            return View(aboutlist);
        }
        [HttpPost]
        public ActionResult UpdateAbout(About p)
        {
            cm.AboutUpdate(p);
            return RedirectToAction("UpdateAboutList");
        }
    }
}