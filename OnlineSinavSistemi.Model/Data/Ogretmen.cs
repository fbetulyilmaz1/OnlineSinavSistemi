using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineSinavSistemi.Model.Data
{
    public class Ogretmen : Kullanici
    {
        public ICollection<Sinav> OgretmeniOlunanSinavlar { get; set; }

    }
}
