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
    public class WriterLoginManager : IWriterLoginService
    {
        IAuthorDal _writerDal;

        public WriterLoginManager(IAuthorDal writerDal)
        {
            _writerDal = writerDal;
        }
        public Author GetWriter(string username, string password)
        {
            return _writerDal.Find(x => x.Mail == username);
        }
    }
}
