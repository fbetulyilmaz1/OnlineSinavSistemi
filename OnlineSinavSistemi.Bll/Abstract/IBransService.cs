using OnlineSinavSistemi.Core.Concrete;
using OnlineSinavSistemi.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace OnlineSinavSistemi.Bll.Abstract
{
   public interface IBransService 
    {
        ResultMessage<Brans> Add(Brans data);
        ResultMessage<Brans> Update(Brans data);
        ResultMessage<Brans> SoftDelete(int id);
        ResultMessage<ICollection<Brans>> GetAll(Expression<Func<Brans, bool>> filter = null);
    }
}
