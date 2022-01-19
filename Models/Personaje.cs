using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace peliculasDisney.Models
{
    public class Personaje : IdBase
    {
        public int Edad { get; set; }
        public int Peso { get; set; }
        public string Historia { get; set; }
        public List<PeliculaSerie> PeliculasSeries {get; set;}

         
    }
}
