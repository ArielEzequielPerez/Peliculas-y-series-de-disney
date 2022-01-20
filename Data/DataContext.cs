using Microsoft.EntityFrameworkCore;
using peliculasDisney.Models;
using PeliculasSeries;

namespace peliculasDisney.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Genero> Generos { get; set; }
        public DbSet<PeliculaSerie> PeliculasSeries { get; set; }
        public DbSet<Personaje> Personajes { get; set; }            
        public DbSet<Usuario> Usuarios { get; set; }
    }

}