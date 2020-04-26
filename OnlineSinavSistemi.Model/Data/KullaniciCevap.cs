using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnlineSinavSistemi.Model.Data
{
    public class KullaniciCevap : Base
    {
        [ForeignKey("KullaniciSinav")]
        public int KullaniciSinavId { get; set; }
        [ForeignKey("Soru")]
        public int SoruId { get; set; }
        public char Cevap { get; set; }


        public virtual KullaniciSinav KullaniciSinav { get; set; }
        public virtual Soru Soru { get; set; }

    }
}