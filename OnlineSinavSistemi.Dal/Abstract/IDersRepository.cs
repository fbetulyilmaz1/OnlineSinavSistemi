using OnlineSinavSistemi.Core.Abstract;
using OnlineSinavSistemi.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineSinavSistemi.Dal.Abstract
{
    public interface IDersRepository : IRepository<Ders>
    {
        ICollection<Ders> DersleriGetir();
    }
}
