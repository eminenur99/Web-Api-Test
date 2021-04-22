using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace kassYazilim.Models
{
    public class Ogrenci
    {
        [Key]
        public Guid OgrenciId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int OdevId { get; set; }

      //  public int OdevId { get; set; }
        public Odev Odev { get; set; }
    }

    public class OgrenciRequest
    {
       // [Key]
        //public Guid OgrenciId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int OdevId { get; set; }

       

    }
}
