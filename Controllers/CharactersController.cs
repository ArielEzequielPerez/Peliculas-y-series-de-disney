using Microsoft.AspNetCore.Mvc;
using peliculasDisney.Data;
using peliculasDisney.Models;
using System.Threading.Tasks;

namespace PeliculasSeries.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharactersController : Controller
    {
        private readonly IApiRepository _Repository;
        public CharactersController(IApiRepository Repository)
        {
            _Repository = Repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var Personajes = await _Repository.GetCharactersAsync();
            return Ok(Personajes);
        }

        

        [HttpPost]
        public async Task<IActionResult> Post(Character Characters)
        {
            _Repository.Add(Characters);
            if (await _Repository.SaveAll())
                return Ok(Characters);

            return BadRequest();
        }
        


        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> Get(int id)
        {
            var Character = await _Repository.GetCharacterByIdAsync(id);

            if (Character == null)
                return NotFound();


            return Ok(Character);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Character Character)
        {
            var characterUpdate = await _Repository.GetCharacterByIdAsync(Character.Id);

            if (characterUpdate == null)
                return NotFound("Personaje no encontrado");

            characterUpdate.Nombre = Character.Nombre;
            characterUpdate.Edad = Character.Edad;
            characterUpdate.Historia = Character.Historia;
            characterUpdate.Imagen = Character.Imagen;

            if (!await _Repository.SaveAll())
                return NoContent();

            return Ok(characterUpdate);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var character = await _Repository.GetCharacterByIdAsync(id);
            if (character == null)
                return NotFound("Personaje no encontrado");
            
            _Repository.Delete(character);
            
            if (!await _Repository.SaveAll())
                return BadRequest("no se pudo eliminar el personaje");

            return Ok("Personaje borrado");
        }
        
    }
}
