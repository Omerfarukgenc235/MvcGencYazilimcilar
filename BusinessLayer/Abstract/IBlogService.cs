using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBlogService
    {
        List<Blog> GetList();
        void BlogAdd(Blog blog);
        Blog GetByID(int id);
        List<Blog> GetBlogByAuthor(int id);
        List<Blog> GetBlogByCategory(int id);
        void BlogDelete(Blog blog);
        void BlogUpdate(Blog blog);
    }
}
