using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SlikaOglasi.Models
{
    public class Kontakt
    {
     [Key]
        [Required(ErrorMessage ="Unesite Ime i prezime")]
        [Display(Name ="Ime i prezime")]
        public string Ime { get; set; }

        [Required(ErrorMessage ="Unesite mail")]
        [Display(Name ="Email")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Unesite telefon")]
        [Display(Name ="Telefon")]
        public string Telefon { get; set; }

        [Required(ErrorMessage ="Unesite poruku")]
        [Display(Name ="Poruka")]
        public string Poruka { get; set; }
    }
}
