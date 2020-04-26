using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineSinavSistemi.Model.Data
{
    public class Yonetici : Kullanici
    {
        public ICollection<Sinav> KaydedilenSinavlar { get; set; }

    }
}
