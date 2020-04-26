using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineSinavSistemi.Model.Data
{
    public class Rol : Base
    {
        public string Ad { get; set; }
        //navigation properties
        public virtual ICollection<KullaniciRol> KullaniciRoller { get; set; }

    }

}
