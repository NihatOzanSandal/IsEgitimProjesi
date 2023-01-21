using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SeviyeBelirlemeIcinETicaret.Models.siniflar
{
    public class Urunler
    {

        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "KategoriId")]
        public int KategoriId { get; set; }

        [Required]
        [Display(Name = "UrunAdi")]
        public String UrunAdi { get; set; }

        [Required]
        [Display(Name = "Fiyat")]
        public Double Fiyat { get; set; }
    }
}