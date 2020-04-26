using OnlineSinavSistemi.Bll.Abstract;
using OnlineSinavSistemi.Core.Concrete;
using OnlineSinavSistemi.Dal.Abstract;
using OnlineSinavSistemi.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace OnlineSinavSistemi.Bll.Concrete
{
    public class KullaniciService: IKullaniciService
    {
        IKullaniciRepository repository;
        public KullaniciService(IKullaniciRepository _repository)
        {
            repository = _repository;
        }
        public ResultMessage<Kullanici> Add(Kullanici data)
        {
            return repository.Add(data);
        }
        public ResultMessage<ICollection<Kullanici>> GetAll(Expression<Func<Kullanici, bool>> filter = null)
        {
            return repository.GetAll(filter);
        }
        public ResultMessage<Kullanici> Get(Expression<Func<Kullanici, bool>> filter)
        {
            return repository.Get(filter);
        }

        public ResultMessage<Kullanici> Login(string email, string sifre)
        {
          return  repository.Get(x => x.Sifre == sifre && x.EMail == email);
        }

        public ResultMessage<Kullanici> SoftDelete(int id)
        {
            return repository.SoftDelete(id);
        }

        public ResultMessage<Kullanici> Update(Kullanici data)
        {
            return repository.Update(data);
        }
    }
}
