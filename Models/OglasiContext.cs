using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlikaOglasi.Models
{
    public class OglasiContext : DbContext
    {
        public DbSet<Oglasi> Oglas { get; set; }
        public DbSet<Kontakt> Kontak { get; set; }


        public OglasiContext(DbContextOptions<OglasiContext> opcije) : base(opcije)
        {

        }
    }
}
