using OnlineSinavSistemi.Core.Concrete;
using OnlineSinavSistemi.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace OnlineSinavSistemi.Bll.Abstract
{
    public interface IKursService
    {
        ResultMessage<Kurs> Add(Kurs data);
        ResultMessage<Kurs> Update(Kurs data);
        ResultMessage<Kurs> SoftDelete(int id);
        ResultMessage<ICollection<Kurs>> GetAll(Expression<Func<Kurs, bool>> filter = null);
        ICollection<Kurs> GetCoursesWithExams();
    }
}
