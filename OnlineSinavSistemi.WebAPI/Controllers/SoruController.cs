using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineSinavSistemi.Bll.Abstract;
using OnlineSinavSistemi.Model.Data;

namespace OnlineSinavSistemi.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SoruController : ControllerBase
    {
        IUnitOfWork service;
        public SoruController(IUnitOfWork _service)
        {
            service = _service;
        }
        // GET api/values
        [HttpGet]
        public JsonResult Get()
        {
         var sorular=   service.Soru.GetAll().Data;
            return new JsonResult(Newtonsoft.Json.JsonConvert.SerializeObject(sorular));
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public bool Post(Soru data)
        {
            //Soru eklenecekData = JsonConvert.DeserializeObject<Soru>(value);
            service.Soru.Add(data);
           int cevap= service.SaveChanges().Data;
            return cevap > 0;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
