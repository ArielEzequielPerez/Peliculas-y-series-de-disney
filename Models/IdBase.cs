using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace peliculasDisney.Models
{
    public class IdBase
    {
        [Key]
        public int Id {get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
    }
}
