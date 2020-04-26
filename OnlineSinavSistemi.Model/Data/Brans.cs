using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnlineSinavSistemi.Model.Data
{
   public class Brans :Base
    {
        [Display(Name="Üst Branşı")]
        public int? UstBransId { get; set; }
        public string Ad { get; set; }
        public string LogoUrl { get; set; }
        
        //navigation properties
        [ForeignKey("UstBransId")]

        public virtual Brans UstBransi { get; set; }
    }
}

