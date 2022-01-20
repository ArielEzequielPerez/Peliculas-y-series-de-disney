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
        Task<IEnumerable<Genero>> GetGenerosByIdAsync();
        Task<IEnumerable<Usuario>> GetUsuariosAsync();
        Task<IEnumerable<Personaje>> GetPersonajesAsync();
        Task<IEnumerable<PeliculaSerie>> GetPeliculaSeriesAsync();
        Task<Personaje> GetPersonajesByNombreAsync(string Nombre);
        Task<Personaje> GetPersonajeByEdadAsync(int Edad);
        Task<Usuario> GetUsuarioByIdAsync (int id);
        Task<Usuario> GetUsuarioByNombreAsync(string Nombre);


    }
}