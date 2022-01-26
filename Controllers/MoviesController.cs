using Microsoft.AspNetCore.Mvc;
using peliculasDisney.Data;
using peliculasDisney.Models;
using System.Threading.Tasks;

namespace PeliculasSeries.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        private readonly IApiRepository _Repository;
        public MoviesController(IApiRepository Repository)
        {
            _Repository = Repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var Movies = await _Repository.GetMoviesAsync();
            return Ok(Movies);
        }
        
        [HttpPost]
        public async Task<IActionResult> Post(Movie Movie)
        {
            _Repository.Add(Movie);
            if (await _Repository.SaveAll())
                return Ok(Movie);

            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> Get(int id)
        {
            var movie = await _Repository.GetMovieByIdAsync(id);

            if (movie == null)
                return NotFound();


            return Ok(movie);
        }
        [HttpPut]
        public async Task<ActionResult> Put(Movie Movie)
        {
            var movieUpdate = await _Repository.GetMovieByIdAsync(Movie.Id);

            if (movieUpdate == null)
                return NotFound("Pelicula no encontrada");

            movieUpdate.Nombre = Movie.Nombre;
            movieUpdate.Calificacion = Movie.Calificacion;
            movieUpdate.Imagen = Movie.Imagen;

            if (!await _Repository.SaveAll())
                return NoContent();

            return Ok(movieUpdate);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var movie = await _Repository.GetMovieByIdAsync(id);

            if (movie == null)
                return NotFound();

            _Repository.Delete(movie);

            if (!await _Repository.SaveAll())
                return BadRequest();

            return Ok();
        }

    }
}
