using Microsoft.AspNetCore.Mvc;
using peliculasDisney.Data;
using peliculasDisney.Models;
using PeliculasSeries.Dto;
using System.Linq;
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
            var MovieDto = Movies.Select(AMovie => new MovieCreateDto { Name = AMovie.Name, Image = AMovie.Image, Date = AMovie.Date }).ToList();
            return Ok(MovieDto);
        }
        
        [HttpPost]
        public async Task<IActionResult> Post(Movie Movie)
        {
            _Repository.Add(Movie);
            if (await _Repository.SaveAll())
                return Ok(Movie);

            return BadRequest();
        }

        [HttpGet("id")]
        public async Task<ActionResult<Character>> Get(int id)
        {
            
            var movie = await _Repository.GetMovieByIdAsync(id);

            if (movie == null)
                return NotFound();


            return Ok(movie);
        }
        [HttpPut("Id")]
        public async Task<ActionResult> Put(int Id ,MovieCreateDto MovieDto)
        {
            if (Id != MovieDto.Id)
                return BadRequest("Los id no coinciden");

            var movieUpdate = await _Repository.GetMovieByIdAsync(MovieDto.Id);

            if (movieUpdate == null)
                return NotFound("Pelicula no encontrada");

            movieUpdate.Name = MovieDto.Name;
            movieUpdate.Ranking = MovieDto.Ranking;
            movieUpdate.Image = MovieDto.Image;

            if (!await _Repository.SaveAll())
                return NoContent();

            return Ok(movieUpdate);

        }

        [HttpDelete("id")]
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

        [HttpGet("Name")]
        public async Task<IActionResult> SearchMovieByName(string Name)
        {
            var Movie = await _Repository.GetMovieByNameAsync(Name);
            if (Movie == null)
                return NotFound();

            return Ok(Movie);
        }

        [HttpGet("IdGenero")]
        public async Task<IActionResult> SearchMovieByIdGenero(int IdGenero)
        {
            var Movie = await _Repository.GetMovieByIdGeneroAsync(IdGenero);
            if (Movie == null)
                return NotFound();

            return Ok(Movie);
        }


        [HttpGet("Order")]
        public async Task<IActionResult> SearchMovieByOrderBy(string Order)
        {
            var Movie = await _Repository.GetMovieByOrderByDescAsync(Order);
            if (Order == "Asc")
                Movie = await _Repository.GetMovieByOrderByAscAsync(Order);
            
            if (Movie == null)
                return NotFound();

            return Ok(Movie);
        }

        
    }
}
