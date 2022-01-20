using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace peliculasDisney.Models
{
    public class PeliculaSerie : IdBase
    {       
        [Required(ErrorMessage = "ingrese una fecha valida")]
        [Display(Name = "Fecha")]        
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "ingrese una calificacion")]
        [Display(Name = "Calificacion(1-10)")]
        public int Calificacion { get; set; }
        public byte [] Imagen { get; set; }

        public List<Personaje> Personajes { get; set; }


    }
}
