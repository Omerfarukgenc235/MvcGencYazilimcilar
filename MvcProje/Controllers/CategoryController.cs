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
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        public ActionResult Index()
        {
            var category = cm.GetList();
            return View(category);
        }
        [AllowAnonymous]

        public PartialViewResult BlogDetailsCategoryList()
        {
            var category = cm.GetList();
        
            return PartialView(category);
        }
        public ActionResult AdminCategoryList()
        {
            var categorylist = cm.GetList();
            return View(categorylist);
        }
        [HttpGet]
        public ActionResult AdminCategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminCategoryAdd(Category p)
        {
            CategoryValidator categoryvalidator = new CategoryValidator();
            ValidationResult results = categoryvalidator.Validate(p);
            if (results.IsValid)
            {
                cm.CategoryAdd(p);
                return RedirectToAction("AdminCategoryList");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult CategoryEdit(int id)
        {
            var categoryvalue = cm.GetByID(id);
            return View(categoryvalue);
        }
        [HttpPost]
        public ActionResult CategoryEdit(Category p)
        {
            cm.CategoryUpdate(p);
            return RedirectToAction("AdminCategoryList");
        }
        public ActionResult CategoryDelete(int id)
        {
            var categoryvalue = cm.GetByID(id);
            cm.CategoryDelete(categoryvalue);
            return RedirectToAction("AdminCategoryList");
        }
        public ActionResult CategoryStatus(int id)
        {
            var categoryvalue = cm.GetByID(id);
            if(categoryvalue.CategoryStatus == false)
            {
                categoryvalue.CategoryStatus = true;
            }
            else
            {
                categoryvalue.CategoryStatus = false;
            }
            cm.CategoryUpdate(categoryvalue);
            return RedirectToAction("AdminCategoryList");

        }
        //public ActionResult CategoryStatusTrue(int id)
        //{
        //    cm.TrueCategory(id);
        //    return RedirectToAction("AdminCategoryList");
        //}
    }
}