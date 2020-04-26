using OnlineSinavSistemi.Core.Concrete;
using OnlineSinavSistemi.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace OnlineSinavSistemi.Bll.Abstract
{
    public interface IKursMerkeziService
    {
        ResultMessage<KursMerkezi> Add(KursMerkezi data);
        ResultMessage<KursMerkezi> Update(KursMerkezi data);
        ResultMessage<KursMerkezi> SoftDelete(int id);
        ResultMessage<ICollection<KursMerkezi>> GetAll(Expression<Func<KursMerkezi, bool>> filter = null);
    }
}
