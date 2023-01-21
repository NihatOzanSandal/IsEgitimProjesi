using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SeviyeBelirlemeIcinETicaret.Models.siniflar
{
    public class context : DbContext
    {
        public DbSet<Kullanicilar> Kullanicilar { get; set; }
        public DbSet<Urunler> Urunler {get; set;}     

        public DbSet<Sepet> Sepet {get; set;}

        public DbSet<Kategori> Kategori { get; set; }

        public context() : base("name=DbContext") { }

    }
}