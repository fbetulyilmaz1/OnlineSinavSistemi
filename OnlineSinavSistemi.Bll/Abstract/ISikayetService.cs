using OnlineSinavSistemi.Core.Concrete;
using OnlineSinavSistemi.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace OnlineSinavSistemi.Bll.Abstract
{
    public interface ISikayetService
    {
        ResultMessage<Sikayet> Add(Sikayet data);
        ResultMessage<Sikayet> Update(Sikayet data);
        ResultMessage<Sikayet> SoftDelete(int id);
        ResultMessage<ICollection<Sikayet>> GetAll(Expression<Func<Sikayet, bool>> filter = null);
    }
}
