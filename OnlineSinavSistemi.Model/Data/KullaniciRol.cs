using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineSinavSistemi.Model.Data
{
    public class KullaniciRol : Base

    {
        public int KullaniciId { get; set; }
        public int RolId { get; set; }
        //navigation properties
        public Kullanici Kullanici { get; set; }
        public Rol Rol { get; set; }


    }
}
