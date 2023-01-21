using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SeviyeBelirlemeIcinETicaret.Models.siniflar
{
    public class Kategori
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "KategoriAdi")]
        public String KategoriAdi { get; set; }

    }
}