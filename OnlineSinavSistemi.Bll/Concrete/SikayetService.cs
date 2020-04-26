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
    public class SikayetService: ISikayetService
    {
        ISikayetRepository repository;
        public SikayetService(ISikayetRepository _repository)
        {
            repository = _repository;
        }
        public ResultMessage<Sikayet> Add(Sikayet data)
        {
            return repository.Add(data);
        }
        public ResultMessage<ICollection<Sikayet>> GetAll(Expression<Func<Sikayet, bool>> filter = null)
        {
            return repository.GetAll(filter);
        }

        public ResultMessage<Sikayet> SoftDelete(int id)
        {
            return repository.SoftDelete(id);
        }

        public ResultMessage<Sikayet> Update(Sikayet data)
        {
            return repository.Update(data);
        }
    }
}
