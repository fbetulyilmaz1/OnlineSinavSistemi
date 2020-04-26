using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnlineSinavSistemi.Model.Data
{
    public class Kurs : Base
    {
        public DateTime BaslamaTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public bool BittiMi { get; set; }

        [ForeignKey("Sinav")]
        public int SinavId { get; set; }
        public string HaftalikCalisma { get; set; }


        public virtual Sinav Sinav { get; set; }
        public virtual ICollection<Ders> Ders { get; set; }
        public virtual ICollection<KullaniciKurs> KullaniciKurs { get; set; }


    }
}
