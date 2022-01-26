using System.ComponentModel.DataAnnotations;
using peliculasDisney.Models;

namespace PeliculasSeries{
    public class User : IdBase
    {   
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Contraseña")]
        public string Contrasenia { get; set; }

    }
}