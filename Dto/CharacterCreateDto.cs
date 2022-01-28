using System.Collections.Generic;
using peliculasDisney.Models;

namespace PeliculasSeries.Dto
{
    public class CharacterCreateDto
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public string Image { get; set; }
        public List<Movie> Movies{get; set;}

    }
}