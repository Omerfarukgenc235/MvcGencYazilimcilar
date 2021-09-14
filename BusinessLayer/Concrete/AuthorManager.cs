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
    public class AuthorManager : IAuthorService
    {
        IAuthorDal _authorDal;

        public AuthorManager(IAuthorDal authorDal)
        {
            _authorDal = authorDal;
        }

       
      
      
        public List<Author> GetList()
        {
            return _authorDal.List();     
        }

        public void AuthorAdd(Author author)
        {
            _authorDal.Insert(author);
        }

        public Author GetByID(int id)
        {
            return _authorDal.Find(x => x.AuthorID == id);
        }

        public void AuthorDelete(Author author)
        {
            throw new NotImplementedException();
        }

        public void AuthorUpdate(Author author)
        {
            _authorDal.Update(author);
        }
    }
}
