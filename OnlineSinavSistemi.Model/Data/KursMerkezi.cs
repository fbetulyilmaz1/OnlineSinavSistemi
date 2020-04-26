using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineSinavSistemi.Model.Data
{
    public class KursMerkezi : Base
    {
        public string Ad { get; set; }
        public string Adres { get; set; }
        public short TelefonNumarasi { get; set; }
        public string Ilce { get; set; }
        public string Il { get; set; }
        public string LocationUrl { get; set; }
    }

}
