using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class istatistikController : Controller
    {
        // GET: istatistik
        public ActionResult Index()
        {
            Context c = new Context();
            var abonesayisi = c.SubscribeMails.Count();
            ViewBag.abonesayisi = abonesayisi;
            var blogsayisi = c.Blogs.Count();
            ViewBag.blogsayisi = blogsayisi;
            var yazarsayisi = c.Authors.Count();
            ViewBag.yazarsayisi = yazarsayisi;
            var kategorisayisi = c.Categories.Count();
            ViewBag.kategorisayisi = kategorisayisi;
            return View();
        }
    }
}