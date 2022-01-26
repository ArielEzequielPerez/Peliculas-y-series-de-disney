using Microsoft.EntityFrameworkCore;
using peliculasDisney.Data;
using peliculasDisney.Models;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<Genero>> GetGenerosAsync()
        {
            return await _context.Generos.ToListAsync();
        }
       

        public async Task<IEnumerable<Movie>> GetMoviesAsync()
        {
            return await _context.Movies.ToListAsync();
        }
        public async Task<Movie> GetMovieByIdAsync(int Id)
        {
            return await _context.Movies.FirstOrDefaultAsync(Movie => Movie.Id == Id);
        }


        public async Task<IEnumerable<Character>> GetCharactersAsync()
        {
            var personajes = await _context.Characters.Select(unPersonaje => new Character{ Nombre = unPersonaje.Nombre, Imagen = unPersonaje.Imagen}).ToListAsync();
            return personajes;
        }

        public async Task<Character> GetCharacterByIdAsync(int Id)
        {
            return await _context.Characters.FirstOrDefaultAsync(UnPersonaje => UnPersonaje.Id == Id);
            
        }
        public async Task<Character> GetCharacterByName(string Name)
        {
            return await _context.Characters.FirstOrDefaultAsync(Personaje => Personaje.Nombre == Name);
        }

        public async Task<Character> GetCharacterByAgeAsync(int Age)
        {
            return await _context.Characters.FirstOrDefaultAsync(Personaje => Personaje.Edad == Age);
        }

     

        public async Task<User> GetUserByIdAsync(int id)
        {
            return  await _context.Users.FirstOrDefaultAsync(User => User.Id== id);  
        }

        public async Task<User> GetUserByNameAsync(string Name)
        {
            return await _context.Users.FirstOrDefaultAsync(Usuario => Usuario.Nombre == Name);
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
        

        

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
       
}
