using kassYazilim.DBContext;
using kassYazilim.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kassYazilim.Controllers
{
    [Route("api/odev")]
    [ApiController]
    public class OdevController : ControllerBase
    {
        private readonly MyDbContext __context;


        public OdevController(MyDbContext context)
        {
            __context = context;
        }

        [HttpGet]
        public IQueryable<Odev> Get()
        {

            return __context.odev;
        }

        [HttpGet("{id}")]
        public Odev Get(int id)
        {
            var _odev = __context.odev.FirstOrDefault(p => p.OdevId == id);
            if (_odev == null)
            {
                return null;
            }
            return _odev;

        }

        
        [HttpPost("Create")]
        public void Create(Odev odev)
        {
            __context.odev.Add(new Odev()
            {
                OdevId = odev.OdevId,
                Name = odev.Name,
                StartDateTime=odev.StartDateTime,
                EndDateTime=odev.EndDateTime,
            });
            __context.SaveChanges();
        }


        [HttpDelete("Delete/{id}")]
        public void Delete(int id)
        {
            Odev result;


            using (var db = __context)
            {
                result = db.odev.Where(c => c.OdevId == id).FirstOrDefault();
                db.odev.Remove(result);
                db.SaveChanges();
            }

        }

        [HttpPut("Update/{id}")]
        public void Update(Odev odev, int id)
        {
            Odev result;
            using (var db = __context)
            {
                result = db.odev.Where(c => c.OdevId == id).FirstOrDefault();
                result.Name = odev.Name;
                result.StartDateTime = odev.StartDateTime;
                result.EndDateTime = odev.EndDateTime;

                db.SaveChanges();
            }


        }
        


    }
}
