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
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager cm = new ContactManager(new EfContactDal());

        [AllowAnonymous]

        public ActionResult Index()
        {

            return View();
        }
        [AllowAnonymous]

        [HttpGet]
        public ActionResult AddContact()
        {

            return View();
        }
        [AllowAnonymous]

        [HttpPost]
        public ActionResult AddContact(Contact p)
        {
            p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString()); 
            cm.ContactAdd(p);
            return View();
        }

        public ActionResult SendBox()
        {
            var mesajlar = cm.GetList();
            return View(mesajlar);
        }
        public ActionResult MessageDetails(int id)
        {
            Contact contact = cm.GetByID(id);
            return View(contact);
        }
    }
}