using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class CommentController : Controller
    {
        // GET: Comment 
        CommentManager cm = new CommentManager(new EfCommentDal());

        [AllowAnonymous]

        public PartialViewResult CommentList(int id)
        {

            var comment = cm.GetByID(id).Where(x => x.CommentStatus == true);
            var toplam = cm.GetByID(id).Where(x => x.CommentStatus == true).Count();
            ViewBag.toplam = toplam;
            return PartialView(comment);
        }
        [HttpGet]
        [AllowAnonymous]

        public PartialViewResult LeaveComment(int id)
        {
            ViewBag.id = id;
            return PartialView();
        }
        [HttpPost]
        [AllowAnonymous]

        public PartialViewResult LeaveComment(Comment c)
        {
            CommentValidator commentvalidator = new CommentValidator();

            ValidationResult results = commentvalidator.Validate(c);

            if (results.IsValid)
            {
                c.CommentStatus = false;
                cm.CommentAdd(c);

            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return PartialView();

        }
        public ActionResult AdminCommentList()
        {
            var commentlist = cm.CommentByStatusTrue().OrderByDescending(x => x.CommentID);
            return View(commentlist);
        }
        public ActionResult AdminCommentListFalse()
        {
            var commentlist = cm.CommentByStatusFalse().OrderByDescending(x =>x.CommentID);
            return View(commentlist);
        }
        public ActionResult YorumuKaldir(int id)
        {
            cm.CommentStatusChangeToFalse(id);
            return RedirectToAction("AdminCommentList");
        }
        public ActionResult YorumuYayinla(int id)
        {
            cm.CommentStatusChangeToTrue(id);
            return RedirectToAction("AdminCommentListFalse");
        }
    }
}