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
    public class KursMerkeziService: IKursMerkeziService
    {
        IKursMerkeziRepository repository;
        public KursMerkeziService(IKursMerkeziRepository _repository)
        {
            repository = _repository;
        }
        public ResultMessage<KursMerkezi> Add(KursMerkezi data)
        {
            return repository.Add(data);
        }
        public ResultMessage<ICollection<KursMerkezi>> GetAll(Expression<Func<KursMerkezi, bool>> filter = null)
        {
            return repository.GetAll(filter);
        }

        public ResultMessage<KursMerkezi> SoftDelete(int id)
        {
            return repository.SoftDelete(id);
        }

        public ResultMessage<KursMerkezi> Update(KursMerkezi data)
        {
            return repository.Update(data);
        }
    }
}
