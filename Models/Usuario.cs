using peliculasDisney.Models;

namespace PeliculasSeries{
    public class Usuario : IdBase
    {        
        public string email { get; set; }
        public string contraseña { get; set; }

    }
}