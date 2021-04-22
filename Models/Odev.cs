using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace kassYazilim.Models
{
    public class Odev
    {
        [Key]
        public int OdevId { get; set; }
        public string Name { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }


        public ICollection<Ogrenci> ogrencis { get; set; }
    }
}
