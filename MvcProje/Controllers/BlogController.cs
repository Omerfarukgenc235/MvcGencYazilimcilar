using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using DataAccessLayer.Concrete;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.EntityFramework;

namespace MvcProje.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        BlogManager bm = new BlogManager(new EfBlogDal());

        [AllowAnonymous]

        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]

        public ActionResult BlogDetay()
        {

            return View();
        }
        [AllowAnonymous]
        public PartialViewResult BlogCover(int id)
        {
            var blogdetay = bm.GetBlogByBlog(id);
            return PartialView(blogdetay);
        }
        [AllowAnonymous]

        public PartialViewResult BlogReadAll(int id)
        {
            var blogdetay = bm.GetBlogByBlog(id);
            return PartialView(blogdetay);
        }
        [AllowAnonymous]

        public PartialViewResult BlogList(int page = 1)
        {

            var bloglist = bm.GetList().OrderByDescending(x =>x.BlogID).ToPagedList(page,6);
            return PartialView(bloglist);
        }
        [AllowAnonymous]

        public PartialViewResult FeaturedPost()
        {
            var post1baslik = bm.GetList().OrderByDescending(z =>z.BlogID).Where(x => x.Category.CategoryID == 1).Select(y => y.BlogTitle).FirstOrDefault();
            var post1image = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.Category.CategoryID == 1).Select(y => y.BlogImage).FirstOrDefault();
            var post1tarih = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.Category.CategoryID == 1).Select(y => y.BlogDate).FirstOrDefault();
            var blogpostid1 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.Category.CategoryID == 1).Select(y => y.BlogID).FirstOrDefault();
            ViewBag.post1baslik = post1baslik;
            ViewBag.post1image = post1image;
            ViewBag.post1tarih = post1tarih;
            ViewBag.blogpostid1 = blogpostid1;
            var post2baslik = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.Category.CategoryID == 2).Select(y => y.BlogTitle).FirstOrDefault();
            var post2image = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.Category.CategoryID == 2).Select(y => y.BlogImage).FirstOrDefault();
            var post2tarih = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.Category.CategoryID == 2).Select(y => y.BlogDate).FirstOrDefault();
            var blogpostid2 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.Category.CategoryID == 2).Select(y => y.BlogID).FirstOrDefault();

            ViewBag.post2baslik = post2baslik;
            ViewBag.post2image = post2image;
            ViewBag.post2tarih = post2tarih;
            ViewBag.blogpostid2 = blogpostid2;

            var post3baslik = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.Category.CategoryID == 5).Select(y => y.BlogTitle).FirstOrDefault();
            var post3image = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.Category.CategoryID == 5).Select(y => y.BlogImage).FirstOrDefault();
            var post3tarih = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.Category.CategoryID == 5).Select(y => y.BlogDate).FirstOrDefault();
            var post3category = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.Category.CategoryID == 5).Select(y => y.Category.CategoryName).FirstOrDefault();
            var blogpostid3 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.Category.CategoryID == 5).Select(y => y.BlogID).FirstOrDefault();

            ViewBag.post3baslik = post3baslik;
            ViewBag.post3image = post3image;
            ViewBag.post3tarih = post3tarih;
            ViewBag.post3category = post3category;
            ViewBag.blogpostid3 = blogpostid3;

            var post4baslik = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.Category.CategoryID == 3).Select(y => y.BlogTitle).FirstOrDefault();
            var post4image = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.Category.CategoryID == 3).Select(y => y.BlogImage).FirstOrDefault();
            var post4tarih = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.Category.CategoryID == 3).Select(y => y.BlogDate).FirstOrDefault();
            var blogpostid4 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.Category.CategoryID == 3).Select(y => y.BlogID).FirstOrDefault();

            ViewBag.post4baslik = post4baslik;
            ViewBag.post4image = post4image;
            ViewBag.post4tarih = post4tarih;
            ViewBag.blogpostid4 = blogpostid4;

            var post5baslik = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.Category.CategoryID == 6).Select(y => y.BlogTitle).FirstOrDefault();
            var post5image = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.Category.CategoryID == 6).Select(y => y.BlogImage).FirstOrDefault();
            var post5tarih = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.Category.CategoryID == 6).Select(y => y.BlogDate).FirstOrDefault();
            var blogpostid5 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.Category.CategoryID == 6).Select(y => y.BlogID).FirstOrDefault();

            ViewBag.post5baslik = post5baslik;
            ViewBag.post5image = post5image;
            ViewBag.post5tarih = post5tarih;
            ViewBag.blogpostid5 = blogpostid5;


            return PartialView();
        }
        [AllowAnonymous]

        public PartialViewResult OtherFeaturedPost()
        {
            return PartialView();
        }
      
        public PartialViewResult Footer()
        {
            return PartialView();
        }
        [AllowAnonymous]

        public ActionResult BlogByCategory(int id)
        {
            var kategoriname = bm.GetBlogByCategory(id).Select(y => y.Category.CategoryName).FirstOrDefault();
            ViewBag.kategoriname = kategoriname;
            var kategoriaciklama = bm.GetBlogByCategory(id).Select(y => y.Category.CategoryAciklama).FirstOrDefault();
            ViewBag.kategoriaciklama = kategoriaciklama;
            var bloglistele = bm.GetBlogByCategory(id).OrderByDescending(x=>x.BlogID);
            return View(bloglistele);
        }

        public ActionResult AdminBlogList()
        {
            var bloglar = bm.GetList();
            return View(bloglar);
        }
        public ActionResult AdminBlogList2()
        {
            var bloglar = bm.GetList();
            return View(bloglar);
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
            List<SelectListItem> yazar = (from x in c.Authors.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.AuthorName,
                                               Value = x.AuthorID.ToString()
                                           }).ToList();
            ViewBag.yazar = yazar;
            return View();           
        }
        [HttpPost]
        public ActionResult YeniBlog(Blog b)
        {
            bm.BlogAdd(b);
            return RedirectToAction("AdminBlogList");
        }
        public ActionResult DeleteBlog(int id)
        {
            var BLOGVALUE = bm.GetByID(id);
            bm.BlogDelete(BLOGVALUE);
            return RedirectToAction("AdminBlogList");

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
            return RedirectToAction("AdminBlogList");
        }
        public ActionResult GetCommentByBlog(int id)
        {
            CategoryManager cm = new CategoryManager(new EfCategoryDal());
            var commentlist = cm.GetByID(id);
            return View(commentlist);
        }
        public ActionResult AuthorBlogList(int id)
        {
            var blog = bm.GetBlogByAuthor(id);
            return View(blog);
        }
    }
}