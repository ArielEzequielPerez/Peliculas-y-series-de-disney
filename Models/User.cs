using System;
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

        public bool Active { get; set; }
        public DateTime DischargeDate { get; set; }
        public byte [] PasswordHash { get; set; }
        public byte [] PasswordSalt { get; set; }

    }
}