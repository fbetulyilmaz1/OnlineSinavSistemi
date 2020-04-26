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
    public class KursService: IKursService
    {
        IKursRepository repository;
        public KursService(IKursRepository _repository)
        {
            repository = _repository;
        }
        public ResultMessage<Kurs> Add(Kurs data)
        {
            return repository.Add(data);
        }
        public ResultMessage<ICollection<Kurs>> GetAll(Expression<Func<Kurs, bool>> filter = null)
        {
            return repository.GetAll(filter);
        }

        public ICollection<Kurs> GetCoursesWithExams()
        {
            return repository.GetCoursesWithExams();
        }

        public ResultMessage<Kurs> SoftDelete(int id)
        {
            return repository.SoftDelete(id);
        }

        public ResultMessage<Kurs> Update(Kurs data)
        {
            return repository.Update(data);
        }
    }
}
