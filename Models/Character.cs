using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace peliculasDisney.Models
{
    public class Character : IdBase
    {
        [Required(ErrorMessage = "ingrese una edad")]
        [Display(Name = "Edad")]
        public int Age { get; set; }

        [Display(Name = "ingrese un peso")]
        public int Weight { get; set; }

        [Display(Name = "una breve historia")]
        public string History { get; set; }

        [Required(ErrorMessage = "ingrese una imagen")]
        public string Image { get; set; }
        public List<Movie> Movies{get; set;}

         
    }
}
