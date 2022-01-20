using System.ComponentModel.DataAnnotations;
using peliculasDisney.Models;

namespace PeliculasSeries{
    public class Usuario : IdBase
    {   
        [Required]
        [Display(Name = "Email")]
        public string email { get; set; }

        [Required]
        [Display(Name = "Contraseña")]
        public string contraseña { get; set; }

    }
}