using OnlineSinavSistemi.Core.Concrete;
using OnlineSinavSistemi.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace OnlineSinavSistemi.Bll.Abstract
{
    public interface IKullaniciSinavService
    {
        ResultMessage<KullaniciSinav> Add(KullaniciSinav data);
        ResultMessage<KullaniciSinav> Update(KullaniciSinav data);
        ResultMessage<KullaniciSinav> SoftDelete(int id);
        ResultMessage<ICollection<KullaniciSinav>> GetAll(Expression<Func<KullaniciSinav, bool>> filter = null);
    }
}
