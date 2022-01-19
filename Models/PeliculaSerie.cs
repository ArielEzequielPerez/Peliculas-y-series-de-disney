using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace peliculasDisney.Models
{
    public class PeliculaSerie : IdBase
    {       
        public DateTime Fecha { get; set; }
        public int Calificacion { get; set; }
        public List<Personaje> Personajes { get; set; }


    }
}
