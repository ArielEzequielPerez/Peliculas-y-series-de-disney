using peliculasDisney.Models;
using PeliculasSeries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace peliculasDisney.Data
{
    public interface IApiRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<IEnumerable<Genero>> GetGenerosAsync();
        Task<IEnumerable<Character>> GetCharactersAsync();
        Task<IEnumerable<Movie>> GetMoviesAsync();
        
        Task<IEnumerable<Character>> GetCharacterByName(string Name);
        Task<IEnumerable<Character>> GetCharacterByAgeAsync(int Age);
        Task<IEnumerable<Character>> GetCharacterByMovie(int IdMovie);

        Task<IEnumerable<Movie>> GetMovieByNameAsync(string Name);
        Task<IEnumerable<Movie>>GetMovieByIdGeneroAsync(int Id);
        Task<IEnumerable<Movie>> GetMovieByOrderByDescAsync(string OrderBy);
        Task<IEnumerable<Movie>> GetMovieByOrderByAscAsync(string OrderBy);
        Task<Genero> GetGeneroByIdAsync(int Id);
        Task<Character> GetCharacterByIdAsync(int Id);
        Task<Movie> GetMovieByIdAsync(int Id);

        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync (int id);
        Task<User> GetUserByEmailAsync(string Email);
    }
}