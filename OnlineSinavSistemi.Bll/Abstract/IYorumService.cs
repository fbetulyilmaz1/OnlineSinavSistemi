using OnlineSinavSistemi.Core.Concrete;
using OnlineSinavSistemi.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace OnlineSinavSistemi.Bll.Abstract
{
    public interface IYorumService
    {
        ResultMessage<Yorum> Add(Yorum data);
        ResultMessage<Yorum> Update(Yorum data);
        ResultMessage<Yorum> SoftDelete(int id);
        ResultMessage<ICollection<Yorum>> GetAll(Expression<Func<Yorum, bool>> filter = null);
    }
}
