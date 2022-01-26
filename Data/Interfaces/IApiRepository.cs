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
        
        Task<Character> GetCharacterByName(string Name);
        Task<Character> GetCharacterByIdAsync(int Id);
        Task<Character> GetCharacterByAgeAsync(int Age);
        Task<Movie> GetMovieByIdAsync(int Id);

        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync (int id);
        Task<User> GetUserByNameAsync(string Name);
    }
}