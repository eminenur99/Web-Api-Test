using kassYazilim.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kassYazilim.DBContext
{
    public class MyDbContext : DbContext
    {
       

        public DbSet<Odev> odev { get; set; }
        public DbSet<Ogrenci> ogrenci { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

    }
}
