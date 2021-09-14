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
    public class AboneManager : IAboneService
    {
        IAboneDal _aboneDal;

        public AboneManager(IAboneDal aboneDal)
        {
            _aboneDal = aboneDal;
        }

      

        public SubscribeMail GetByID(int id)
        {
            return _aboneDal.Find(x => x.MailID == id);
        }

        public List<SubscribeMail> GetList()
        {
            return _aboneDal.List();
        }

        public void SubscribeMailAdd(SubscribeMail subscribemail)
        {
            _aboneDal.Insert(subscribemail);
        }

        public void SubscribeMailDelete(SubscribeMail subscribemail)
        {
            _aboneDal.Delete(subscribemail);
        }

    
    }
}
