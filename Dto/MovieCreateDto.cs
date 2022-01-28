using System;

namespace PeliculasSeries.Dto
{
    public class MovieCreateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int Ranking { get; set; }     
        public string Image { get; set; }
        
    }
}
