using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace peliculasDisney.Models
{
    public class Genero : IdBase 
    {
        List<PeliculaSerie> PeliculasSeries { get; set; }

    }
}
