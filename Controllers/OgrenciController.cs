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
    [Route("api/ogrenci")]
    [ApiController]

    public class OgrenciController : ControllerBase
    {
        private readonly MyDbContext _context;


        public OgrenciController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IQueryable<Ogrenci> Get()
        {

            return _context.ogrenci;
        }

        [HttpGet("{id}")]
        public Ogrenci Get(Guid id)
        {
            var _ogrenci = _context.ogrenci.FirstOrDefault(p => p.OgrenciId == id);
            if (_ogrenci == null)
            {
                return null;
            }
            return _ogrenci;

        }

        [HttpPost("Create")]
        public void Create([FromBody] OgrenciRequest ogrenci)
        {
            _context.ogrenci.Add(new Ogrenci()
            {
                OgrenciId = Guid.NewGuid(),
                FirstName = ogrenci.FirstName,
                LastName = ogrenci.LastName,
                OdevId = ogrenci.OdevId,
            });
            _context.SaveChanges();
        }

       

             [HttpDelete("Delete/{id}")]
            public void Delete(Guid id)
            {
                Ogrenci result;



                using (var db = _context)
                {
                    result = db.ogrenci.Where(c => c.OgrenciId == id).FirstOrDefault();
                    db.ogrenci.Remove(result);
                    db.SaveChanges();
                }

            } 

            [HttpPut("Update/{id}")]

            public void Update(OgrenciRequest ogrenci, Guid id)
            {
                Ogrenci result;
                using (var db = _context)
                {
                    result = db.ogrenci.Where(c => c.OgrenciId == id).FirstOrDefault();

                    result.FirstName = ogrenci.FirstName;
                    result.LastName = ogrenci.LastName;
                    result.OdevId = ogrenci.OdevId;

                    db.SaveChanges();
                }
            }

    }
}
