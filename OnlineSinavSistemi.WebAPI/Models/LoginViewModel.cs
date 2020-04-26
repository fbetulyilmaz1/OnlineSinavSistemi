using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineSinavSistemi.WebAPI.Models
{
    public class LoginViewModel
    {
        [Required]
        public string EMail { get; set; }
        [Required]
        public string Sifre { get; set; }
    }

}
