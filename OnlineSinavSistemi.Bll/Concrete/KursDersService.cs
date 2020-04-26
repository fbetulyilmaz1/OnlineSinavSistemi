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
    public class KursDersService: IKursDersService
    {
        IKursDersRepository repository;
        public KursDersService(IKursDersRepository _repository)
        {
            repository = _repository;
        }
        public ResultMessage<KursDers> Add(KursDers data)
        {
            return repository.Add(data);
        }
        public ResultMessage<ICollection<KursDers>> GetAll(Expression<Func<KursDers, bool>> filter = null)
        {
            return repository.GetAll(filter);
        }

        public ResultMessage<KursDers> SoftDelete(int id)
        {
            return repository.SoftDelete(id);
        }

        public ResultMessage<KursDers> Update(KursDers data)
        {
            return repository.Update(data);
        }
    }
}
