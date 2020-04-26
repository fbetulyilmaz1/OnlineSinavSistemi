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
    public class SoruService: ISoruService
    {
        ISoruRepository repository;
        public SoruService(ISoruRepository _repository)
        {
            repository = _repository;
        }
        public ResultMessage<Soru> Add(Soru data)
        {
            return repository.Add(data);
        }
        public ResultMessage<ICollection<Soru>> GetAll(Expression<Func<Soru, bool>> filter = null)
        {
            return repository.GetAll(filter);
        }

        public ResultMessage<Soru> SoftDelete(int id)
        {
            return repository.SoftDelete(id);
        }

        public ResultMessage<Soru> Update(Soru data)
        {
            return repository.Update(data);
        }
    }
}
