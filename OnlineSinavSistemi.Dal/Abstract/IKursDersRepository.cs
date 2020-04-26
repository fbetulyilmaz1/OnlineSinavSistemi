using OnlineSinavSistemi.Core.Abstract;
using OnlineSinavSistemi.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineSinavSistemi.Dal.Abstract
{
    public interface IKursDersRepository : IRepository<KursDers>
    {
        ICollection<Kullanici> KursunKullanicilariniGetir(int id);
        ICollection<Ders> KursunDersleriniGetir(int id);
    }
}
