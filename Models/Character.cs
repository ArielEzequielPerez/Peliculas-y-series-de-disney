using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace peliculasDisney.Models
{
    public class Character : IdBase
    {
        [Required(ErrorMessage = "ingrese una edad")]
        [Display(Name = "Edad")]
        public int Edad { get; set; }

        [Display(Name = "ingrese un peso")]
        public int Peso { get; set; }

        [Display(Name = "una breve historia")]
        public string Historia { get; set; }

        [Required(ErrorMessage = "ingrese una imagen")]
        public byte [] Imagen { get; set; }
        public List<Movie> PeliculasSeries {get; set;}

         
    }
}
