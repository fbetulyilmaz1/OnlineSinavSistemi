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
    public class KullaniciCevapService: IKullaniciCevapService
    {
        IKullaniciCevapRepository repository;
        public KullaniciCevapService(IKullaniciCevapRepository _repository)
        {
            repository = _repository;
        }
        public ResultMessage<KullaniciCevap> Add(KullaniciCevap data)
        {
            return repository.Add(data);
        }
        public ResultMessage<ICollection<KullaniciCevap>> GetAll(Expression<Func<KullaniciCevap, bool>> filter = null)
        {
            return repository.GetAll(filter);
        }

        public ResultMessage<KullaniciCevap> SoftDelete(int id)
        {
            return repository.SoftDelete(id);
        }

        public ResultMessage<KullaniciCevap> Update(KullaniciCevap data)
        {
            return repository.Update(data);
        }
    }
}
