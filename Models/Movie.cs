using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace peliculasDisney.Models
{
    public class Movie : IdBase
    {       
        [Required(ErrorMessage = "ingrese una fecha valida")]
        [Display(Name = "Fecha")]        
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "ingrese una calificacion")]
        [Display(Name = "Calificacion(1-10)")]
        public int Ranking { get; set; }
        public string Image { get; set; }

        public List<Character> Characters { get; set; }

    }
}
