using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAboneService 
    {
        List<SubscribeMail> GetList();
        void SubscribeMailAdd(SubscribeMail subscribemail);
        SubscribeMail GetByID(int id);
        void SubscribeMailDelete(SubscribeMail subscribemail);
    }
}
