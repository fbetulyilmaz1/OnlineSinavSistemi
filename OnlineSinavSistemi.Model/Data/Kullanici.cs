using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineSinavSistemi.Model.Data
{
    public class Kullanici : Base
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public long Tc { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string EMail { get; set; }
        public string Sifre { get; set; }
        public string FotoUrl { get; set; }
        //navgation properties 
        public virtual ICollection<KullaniciRol> KullaniciRoller { get; set; }
        public virtual ICollection<KullaniciKurs> KullaniciKurs { get; set; }
        public virtual ICollection<KursDers> KullanicininDersleri { get; set; }
        public virtual ICollection<KullaniciSinav> KullaniciSinavlari { get; set; }

    }
}
