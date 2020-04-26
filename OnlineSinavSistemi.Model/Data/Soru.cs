using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnlineSinavSistemi.Model.Data
{
    public class Soru : Base
    {
        public string SoruMetni { get; set; }
        public string Cevap { get; set; }
        public int ZorlukSeviyesi { get; set; }
        public int BransId { get; set; }
        public string Aciklama { get; set; }
        public int KullaniciId { get; set; }
        public bool OnaylandiMi { get; set; }
        
        //navigation properties
        //[ForeignKey("BransId")]
        //public virtual Brans Bransi { get; set; }
        //[ForeignKey("KullaniciId")]
        //public virtual Yonetici Kullanici { get; set; }
        public virtual ICollection<SinavSoru> SinavSorulari { get; set; }
    }
}
