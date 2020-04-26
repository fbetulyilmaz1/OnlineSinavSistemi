using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnlineSinavSistemi.Model.Data
{
    public class KursDers : Base
    {
        public int KullaniciId { get; set; }
        public int DersId { get; set; }

       

        //navigation properties
        public Kullanici Kullanici { get; set; }
        public Ders Ders { get; set; }
      
    }

    
}
