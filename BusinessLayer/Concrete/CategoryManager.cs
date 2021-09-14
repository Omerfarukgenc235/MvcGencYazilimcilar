using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        //Repository<Category> repocategory = new Repository<Category>();

        ICategoryDal _categorDal;

        public CategoryManager(ICategoryDal categorDal)
        {
            _categorDal = categorDal;
        }

        //public List<Category> GetAll()
        //{
        //    return repocategory.List();
        //}
        //public int CategoryAddBL(Category p)
        //{
        //    if (p.CategoryName == "" || p.CategoryAciklama == "" || p.CategoryName.Length <= 1)
        //    {
        //        return -1;
        //    }
        //    return repocategory.Insert(p);
        //}
        //public Category FindCategory(int id)
        //{
        //    return repocategory.Find(x => x.CategoryID == id);
        //}
        //public int EditCategory(Category p)
        //{
        //    Category category = repocategory.Find(x => x.CategoryID == p.CategoryID);
        //    if(p.CategoryName != "" || p.CategoryAciklama != "")
        //    {
        //        return -1;
        //    }
        //    category.CategoryName = p.CategoryName;
        //    category.CategoryAciklama = p.CategoryAciklama;
        //    return repocategory.Update(category);
        //}
        //public int DeleteCategory(int id)
        //{
        //    Category category = repocategory.Find(x => x.CategoryID == id);
        //    category.CategoryStatus = false;
        //    return repocategory.Update(category);
        //}
        //public int TrueCategory(int id)
        //{
        //    Category category = repocategory.Find(x => x.CategoryID == id);
        //    category.CategoryStatus = true;
        //    return repocategory.Update(category);
        //}

        public List<Category> GetList()
        {
            return _categorDal.List();
        }

        public void CategoryAdd(Category category)
        {
            _categorDal.Insert(category);
        }

        public Category GetByID(int id)
        {
            return _categorDal.Find(x => x.CategoryID == id);
        }

        public void CategoryDelete(Category category)
        {
            _categorDal.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            _categorDal.Update(category);
        }
    }

}
