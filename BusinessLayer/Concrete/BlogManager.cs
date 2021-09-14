using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        Repository<Blog> repoblog = new Repository<Blog>();
        IBlogDal _BlogDal;

        public BlogManager(IBlogDal BlogDal)
        {
            _BlogDal = BlogDal;
        }
        public List<Blog> GetBlogByBlog(int id)
        {
            return repoblog.List(x => x.BlogID == id);
        }
        public List<Blog> GetBlogByCategory(int id)
        {
            return repoblog.List(x => x.CategoryID == id);
        }
        public List<Blog> GetBlogByAuthor(int id)
        {
            return repoblog.List(x => x.AuthorID == id);
        }
        public List<Blog> GetList()
        {
            return _BlogDal.List();

        }

        public void BlogAdd(Blog blog)
        {
            _BlogDal.Insert(blog);
        }

        public Blog GetByID(int id)
        {
            return _BlogDal.Find(x => x.BlogID == id);
        }

        public void BlogDelete(Blog blog)
        {
            _BlogDal.Delete(blog);
        }

        public void BlogUpdate(Blog blog)
        {
            _BlogDal.Update(blog);
        }           
    }
}
