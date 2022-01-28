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
        public async Task<Genero> GetGeneroByIdAsync(int Id)
        {
            return await _context.Generos.FindAsync(Id);
        }

        
       

        public async Task<IEnumerable<Movie>> GetMoviesAsync()
        {
            return await _context.Movies.ToListAsync();
        }
        public async Task<Movie> GetMovieByIdAsync(int Id)
        {
            return await _context.Movies.FirstOrDefaultAsync(Movie => Movie.Id == Id);
        }

        public async Task<IEnumerable<Movie>> GetMovieByNameAsync(string Name)
        {
            return await _context.Movies.Where(Movie => Movie.Name == Name).ToListAsync();
        }

        public async Task<IEnumerable<Movie>>GetMovieByIdGeneroAsync(int Id)
        {
            return await _context.Generos.Where(AGenero => AGenero.Id == Id).Select(AGenero => AGenero.Movies).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Movie>> GetMovieByOrderByDescAsync(string OrderBy)
        {
            return await _context.Movies.OrderByDescending(Movie => Movie.Name).ToListAsync();
        }

        public async Task<IEnumerable<Movie>> GetMovieByOrderByAscAsync(string OrderBy)
        {
            return await _context.Movies.OrderBy(Movie => Movie.Name).ToListAsync();
        }



        public async Task<IEnumerable<Character>> GetCharactersAsync()
        {
            var personajes = await _context.Characters.Select(ACharacter => new Character{ Name = ACharacter.Name, Image = ACharacter.Image}).ToListAsync();
            return personajes;
        }

        public async Task<Character> GetCharacterByIdAsync(int Id)
        {
            return await _context.Characters.FirstOrDefaultAsync(ACharacter => ACharacter.Id == Id);
            
        }
        public async Task<IEnumerable<Character>> GetCharacterByName(string Name)
        {
            return await _context.Characters.Where(ACharacter => ACharacter.Name == Name).ToListAsync();
        }

        public async Task<IEnumerable <Character>> GetCharacterByAgeAsync(int Age)
        {
            return await _context.Characters.Where(ACharacter => ACharacter.Age == Age).ToListAsync();            
        }

        public async Task<IEnumerable<Character>>GetCharacterByMovie(int IdMovie)
        {
            var movie = await _context.Characters.Select(ACharacter => ACharacter.Movies.Where(AMovie => AMovie.Id == IdMovie)).ToListAsync();
            return (IEnumerable<Character>) movie;


        }

     

        public async Task<User> GetUserByIdAsync(int id)
        {
            return  await _context.Users.FirstOrDefaultAsync(User => User.Id== id);  
        }

        public async Task<User> GetUserByNameAsync(string Name)
        {
            return await _context.Users.FirstOrDefaultAsync(AUser => AUser.Name == Name);
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
