using OnlineSinavSistemi.Core.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace OnlineSinavSistemi.Core.Abstract
{
   public interface IRepository<T> where T : class, IVeri, new() 
    {
        ResultMessage<T> Add(T data);
        ResultMessage<T> Update(T data);
        ResultMessage<T> Delete(int id);
        ResultMessage<T> SoftDelete(int id);
        ResultMessage<ICollection<T>> GetAll(Expression<Func<T, bool>> filter=null);
        ResultMessage<T> Get(Expression<Func<T, bool>> filter);
       
    }
}
