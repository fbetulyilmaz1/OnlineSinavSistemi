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
    public class SinavService: ISinavService
    {
        ISinavRepository repository;
        public SinavService(ISinavRepository _repository)
        {
            repository = _repository;
        }
        public ResultMessage<Sinav> Add(Sinav data)
        {
            return repository.Add(data);
        }
        public ResultMessage<ICollection<Sinav>> GetAll(Expression<Func<Sinav, bool>> filter = null)
        {
            return repository.GetAll(filter);
        }

        public ResultMessage<Sinav> SoftDelete(int id)
        {
            return repository.SoftDelete(id);
        }

        public ResultMessage<Sinav> Update(Sinav data)
        {
            return repository.Update(data);
        }
    }
}
