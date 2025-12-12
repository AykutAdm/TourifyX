using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class SentMailManager : ISentMailService
    {
        ISentMailDal _sentMailDal;

        public SentMailManager(ISentMailDal sentMailDal)
        {
            _sentMailDal = sentMailDal;
        }

        public void TAdd(SentMail t)
        {
            _sentMailDal.Insert(t);
        }

        public void TDelete(SentMail t)
        {
            _sentMailDal.Delete(t);
        }

        public SentMail TGetById(int id)
        {
            return _sentMailDal.GetById(id);
        }

        public List<SentMail> TGetList()
        {
            return _sentMailDal.GetList();
        }

        public void TUpdate(SentMail t)
        {
            _sentMailDal.Update(t);
        }
    }
}

