using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OnlineSinavSistemi.Bll.Abstract;
using OnlineSinavSistemi.Model.Data;
using OnlineSinavSistemi.WebAPI.Models;

namespace OnlineSinavSistemi.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        IUnitOfWork service;
        public UserController(IUnitOfWork _service)
        {
            service = _service;
        }

        [HttpGet]
        public ICollection<Kullanici> Get()
        {
            return service.Kullanici.GetAll().Data;
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Post(LoginViewModel model)
        {
          var cevap=  service.Kullanici.Get(x=> x.EMail==model.EMail && x.Sifre== model.Sifre);
            if (cevap.Data == null)
            {
                return Unauthorized();
            }
            else
            {
                var claims = new[]
       {
            new Claim(JwtRegisteredClaimNames.Sub, model.EMail),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

                var token = new JwtSecurityToken
                (
                    issuer: "qwer", //appsettings.json içerisinde bulunan issuer değeri
                    audience: "asdf",//appsettings.json içerisinde bulunan audince değeri
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(3), // 30 dakika geçerli olacak
                    notBefore: DateTime.UtcNow,
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("fatmabetulyilmaz")),//appsettings.json içerisinde bulunan signingkey değeri
                            SecurityAlgorithms.HmacSha256)
                );

              
                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });

            }
        }
    }
}