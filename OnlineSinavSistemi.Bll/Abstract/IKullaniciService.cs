using OnlineSinavSistemi.Core.Concrete;
using OnlineSinavSistemi.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace OnlineSinavSistemi.Bll.Abstract
{
    public interface IKullaniciService
    {
        ResultMessage<Kullanici> Add(Kullanici data);
        ResultMessage<Kullanici> Update(Kullanici data);
        ResultMessage<Kullanici> SoftDelete(int id);
        ResultMessage<Kullanici> Get(Expression<Func<Kullanici, bool>> filter);
        ResultMessage<ICollection<Kullanici>> GetAll(Expression<Func<Kullanici, bool>> filter = null);

        ResultMessage<Kullanici> Login(string email, string sifre);
    }
}
