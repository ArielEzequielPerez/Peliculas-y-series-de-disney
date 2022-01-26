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
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Character> Characters { get; set; }            
        public DbSet<User> Users { get; set; }
    }

}