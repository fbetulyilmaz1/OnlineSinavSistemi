using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnlineSinavSistemi.Model.Data
{
    public class Sikayet : Base
    {
        public int KullaniciId { get; set; }
        public int DersId { get; set; }
        public string Aciklama { get; set; }
        //nav prop
        [ForeignKey("KullaniciId")]
        public virtual Kullanici Kullanicisi { get; set; }
    }
}
