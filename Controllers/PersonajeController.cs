using Microsoft.AspNetCore.Mvc;
using peliculasDisney.Data;
using peliculasDisney.Models;
using System.Threading.Tasks;

namespace PeliculasSeries.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonajeController : Controller
    {
        private readonly IApiRepository _Repository;
        public PersonajeController(IApiRepository Repository)
        {
            _Repository = Repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var Personajes = await _Repository.GetPersonajesAsync();
            return Ok(Personajes);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Personaje Personaje)
        {
            _Repository.Add(Personaje);
            if (await _Repository.SaveAll())
                return Ok(Personaje);

            return BadRequest();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Personaje>> Get(int id)
        {
            var personaje = await _Repository.GetPersonajeByIdAsync(id);

            if (personaje == null)
                return NotFound();


            return Ok(personaje);
        }
        [HttpPut]
        public async Task<ActionResult> Put(Personaje Personaje)
        {
            var characterUpdate = await _Repository.GetPersonajeByIdAsync(Personaje.Id);

            if (characterUpdate == null)
                return NotFound("Personaje no encontrado");

            characterUpdate.Nombre = Personaje.Nombre;
            characterUpdate.Edad = Personaje.Edad;
            characterUpdate.Historia = Personaje.Historia;
            characterUpdate.Imagen = Personaje.Imagen;

            if (!await _Repository.SaveAll())
                return NoContent();

            return Ok(characterUpdate);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var character = await _Repository.GetPersonajeByIdAsync(id);
            if (character == null)
                return NotFound("Personaje no encontrado");
            _Repository.Delete(character);
            if (!await _Repository.SaveAll())
                return BadRequest("no se pudo eliminar el personaje");

            return Ok("Personaje borrado");
        }
        
    }
}
