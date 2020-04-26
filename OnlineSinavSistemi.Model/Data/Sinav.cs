using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnlineSinavSistemi.Model.Data
{
    public class Sinav : Base
    {

        public int KursMerkeziId { get; set; }
        public DateTime SinavTarihi { get; set; }
        public DateTime SinavSaati { get; set; }
        public int Suresi { get; set; }
        public byte SoruSayisi { get; set; }
        public string Sinif { get; set; }
        public int BransId { get; set; }
        public int OgretmenId { get; set; }
        public int KaydedenKullaniciId { get; set; }
        public byte Kontenjan { get; set; }
        public bool OturumBittiMi { get; set; }
        //navigation properties

        [ForeignKey("KursMerkeziId")]
        public virtual KursMerkezi KursMerkezi { get; set; }
        [ForeignKey("BransId")]
        public virtual Brans Brans { get; set; }
        [ForeignKey("OgretmenId")]
        public  Ogretmen Ogretmen { get; set; }
        [ForeignKey("KaydedenKullaniciId")]
        public  Yonetici KaydedenKullanici { get; set; }
        public virtual ICollection<SinavSoru> SinavSorulari { get; set; }
        public virtual ICollection<KullaniciSinav> KullaniciSinav { get; set; }
        public virtual Kurs Kurs { get; set; }
    }
}
