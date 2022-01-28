using System.Collections.Generic;

namespace peliculasDisney.Models
{
    public class Genero : IdBase 
    {
        public string Image { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
