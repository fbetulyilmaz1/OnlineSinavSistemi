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
    public class DersService: IDersService
    {
        IDersRepository repository;
        public DersService(IDersRepository _repository)
        {
            repository = _repository;
        }
        public ResultMessage<Ders> Add(Ders data)
        {
            return repository.Add(data);
        }

        public ResultMessage<ICollection<Ders>> GetAll(Expression<Func<Ders, bool>> filter = null)
        {
            return repository.GetAll(filter);
        }

        public ResultMessage<Ders> SoftDelete(int id)
        {
            return repository.SoftDelete(id);
        }

        public ResultMessage<Ders> Update(Ders data)
        {
            return repository.Update(data);
        }
    }
}
