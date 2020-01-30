using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SlikaOglasi.Models
{
    [Table("Oglasi")]
    public class Oglasi
    {

        public int OglasiId { get; set; }

        [Required(ErrorMessage = "Unesite naslov")]
        [StringLength(20, ErrorMessage = "Do 20 karaktera")]
        [Display(Name ="Naslov")]
        public string Naslov { get; set; }

        [Display(Name = "Fotografija")]    
        [Required(ErrorMessage = "Uneti Url adresu slike")]
        [StringLength(255, ErrorMessage = "Minimum 1 a maximum 255 karatera", MinimumLength = 1)]
        public string Url { get; set; }

        [Required(ErrorMessage = "Unesi marku automobila")]
        [StringLength(20, ErrorMessage = "Minimum 1 a maximum 20 karatera", MinimumLength = 1)]
        [Display(Name ="Marka")]
        public string Marka { get; set; }

        [Required(ErrorMessage = "Unesi model automobila")]
        [StringLength(20, ErrorMessage = "Minimum 1 a maximum 20 karatera", MinimumLength = 1)]
        [Display(Name ="Model")]
        public string Model { get; set; }


        [Required(ErrorMessage ="Unesi godiste autombila")]
        [Display(Name ="Godiste")]
        public int Godiste { get; set; }


        [Required(ErrorMessage ="Unesi kubikazu motora")] 
        [Display(Name ="Motor")]
        public int Motor { get; set; }


        [Required(ErrorMessage ="Unesi snagu motora")]
        [Display(Name ="Snaga Ks")]      
        public int Snaga_Ks { get; set; }


        [Required(ErrorMessage = "Unesi vrstu goriva")]
        [StringLength(20, ErrorMessage = "Minimum 3 a maximum 20 karatera", MinimumLength = 3)]
        [Display(Name ="Gorivo")]
        public string Gorivo { get; set; }


        [Required(ErrorMessage = "Unesi vrstu karoserije")]
        [StringLength(10, ErrorMessage = "Minimum 3 a maximum 10 karatera", MinimumLength = 3)]
        [Display(Name ="Karoserija")]
        public string Karoserija { get; set; }

        [Required(ErrorMessage = "Unesite opis")]
        [StringLength(100, ErrorMessage = "Minimalno 5 karaktera a maksimalno 100",
        MinimumLength = 5)]
        [DataType(DataType.MultilineText)]
        [Display(Name ="Opis")]
        public string Opis { get; set; }


        [Required(ErrorMessage = "Unesite cenu")]
        [Display(Name ="Cena")]
        public decimal Cena { get; set; }

       
    }
}
