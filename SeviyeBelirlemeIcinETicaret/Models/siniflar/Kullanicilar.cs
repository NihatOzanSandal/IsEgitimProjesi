using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace SeviyeBelirlemeIcinETicaret.Models.siniflar
{
    public class Kullanicilar
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "KullaniciAdi")]
        public string KullaniciAdi { get; set; }


        [Required]
        [Display(Name = "Sifre")]
        public string Sifre { get; set; }

    }
}