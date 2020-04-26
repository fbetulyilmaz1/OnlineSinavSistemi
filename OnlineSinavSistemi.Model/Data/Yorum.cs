using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnlineSinavSistemi.Model.Data
{
   public class Yorum : Base
    {
        [ForeignKey("Ders")]
        public int DersId { get; set; }
        [ForeignKey("Kullanici")]
        public int KullaniciId { get; set; }
        public String Aciklama { get; set; }


        public virtual Ders Ders { get; set; }
        public virtual Kullanici Kullanici { get; set; }
    }
}
