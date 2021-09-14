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
    [AllowAnonymous]

    public class AboneController : Controller
    {
        // GET: Abone
        AboneManager cm = new AboneManager(new EfAboneDal());

        [HttpGet]
        public PartialViewResult AddMail()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult AddMail(SubscribeMail p)
        {
            cm.SubscribeMailAdd(p);
            return PartialView();
        }
        public ActionResult Aboneler()
        {
            var aboneler = cm.GetList();
            return View(aboneler);
        }
        public ActionResult AboneSil(int id)
        {
            var abonedeger = cm.GetByID(id);
            cm.SubscribeMailDelete(abonedeger);
            return RedirectToAction("Aboneler");
        }
    }
}