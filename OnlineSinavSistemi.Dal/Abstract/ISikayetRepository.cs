using OnlineSinavSistemi.Core.Abstract;
using OnlineSinavSistemi.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineSinavSistemi.Dal.Abstract
{
    public interface ISikayetRepository : IRepository<Sikayet>
    {
        ICollection<Sikayet> SikayetleriGetir(int kullaniciid);
        ICollection<Sikayet> DersinSikayetleriniGetir(int dersid, int kullaniciid);
    }
   

}
