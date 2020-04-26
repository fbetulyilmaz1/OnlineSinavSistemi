using OnlineSinavSistemi.Core.Abstract;
using OnlineSinavSistemi.Model.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineSinavSistemi.Dal.Abstract
{
    public interface ISinavSoruRepository : IRepository<SinavSoru>
    {
        ICollection<SinavSoru> SorularinSinavlari(int soruId);
        ICollection<SinavSoru> SinavinSorularini(int sinavId);
    }
}
