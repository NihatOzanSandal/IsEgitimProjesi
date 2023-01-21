using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SeviyeBelirlemeIcinETicaret.Models.siniflar
{
    [Serializable]
    public class Sepet
    {

        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "KullaniciId")]
        public int KullaniciId { get; set; }


        [Required]
        [Display(Name = "UrunId")]
        public int UrunId { get; set; }

    }
}