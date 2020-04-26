using OnlineSinavSistemi.Core.Concrete;
using OnlineSinavSistemi.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace OnlineSinavSistemi.Bll.Abstract
{
    public interface IKursDersService
    {
        ResultMessage<KursDers> Add(KursDers data);
        ResultMessage<KursDers> Update(KursDers data);
        ResultMessage<KursDers> SoftDelete(int id);
        ResultMessage<ICollection<KursDers>> GetAll(Expression<Func<KursDers, bool>> filter = null);
    }
}
