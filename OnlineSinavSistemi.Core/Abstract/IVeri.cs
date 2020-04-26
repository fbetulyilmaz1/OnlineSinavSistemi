using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineSinavSistemi.Core.Abstract
{
   public interface IVeri
    {
        //bu interfaceden kalıtım alarak oluşturulan tüm classlar veritabanı için kullanılmaktadır.
        bool SilindiMi { get; set; }
      
    }
}
