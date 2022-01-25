using Microsoft.EntityFrameworkCore;
using peliculasDisney.Data;
using peliculasDisney.Models;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace PeliculasSeries.Data
{

    public class ApiRepository : IApiRepository
    {
        private readonly DataContext _context;
        public ApiRepository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<IEnumerable<Genero>> GetGenerosByIdAsync()
        {
            return await _context.Generos.ToListAsync();
        }

        public async Task<IEnumerable<PeliculaSerie>> GetPeliculaSeriesAsync()
        {
            return await _context.PeliculasSeries.ToListAsync();
        }

        public async Task<Personaje> GetPersonajeByEdadAsync(int Edad)
        {
            return await _context.Personajes.FirstOrDefaultAsync(UnPersonaje => UnPersonaje.Edad == Edad);
        }

        public async Task<IEnumerable<Personaje>> GetPersonajesAsync()
        {
            return await _context.Personajes.ToListAsync();
        }

        public async Task<Personaje> GetPersonajeByIdAsync(int Id)
        {
            var UnPersonaje = await _context.Personajes.FirstOrDefaultAsync(UnPersonaje => UnPersonaje.Id == Id);
            return UnPersonaje;
        }

        public async Task<Usuario> GetUsuarioByIdAsync(int id)
        {
            return  await _context.Usuarios.FirstOrDefaultAsync(Usuario => Usuario.Id== id);  
        }

        public async Task<Usuario> GetUsuarioByNombreAsync(string Nombre)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(Usuario => Usuario.Nombre == Nombre);
        }

        public async Task<IEnumerable<Usuario>> GetUsuariosAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
       
}
