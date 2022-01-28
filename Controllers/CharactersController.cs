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
        


        [HttpGet("id")]
        public async Task<ActionResult<Character>> Get(int id)
        {
            var CharacterById = await _Repository.GetCharacterByIdAsync(id);

            if (CharacterById == null)
                return NotFound();


            return Ok(CharacterById);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Character Character)
        {
            var characterUpdate = await _Repository.GetCharacterByIdAsync(Character.Id);

            if (characterUpdate == null)
                return NotFound("Personaje no encontrado");

            characterUpdate.Name = Character.Name;
            characterUpdate.Age = Character.Age;
            characterUpdate.History = Character.History;
            characterUpdate.Image = Character.Image;

            if (!await _Repository.SaveAll())
                return NoContent();

            return Ok(characterUpdate);

        }

        [HttpDelete("id")]
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

        [HttpGet("Name")]
        public async Task<IActionResult> SearchCharacterByName(string Name)
        {
            var CharacterByName = await _Repository.GetCharacterByName(Name);
            if (CharacterByName == null)
                return NotFound("Personaje no encontrado");

            return Ok(CharacterByName);           
        }
        [HttpGet("Age")]
        public async Task<IActionResult> SearchCharacterByAge(int Age)
        {
            var CharacterByAge = await _Repository.GetCharacterByAgeAsync(Age);
            if (CharacterByAge == null)
                return NotFound("Personaje no encontrado");

            return Ok(CharacterByAge);
        }

        [HttpGet("IdMovie")]
        public async Task<IActionResult> SearchCharacterByMovie(int IdMovie)
        {
            var CharacterByMovie = await _Repository.GetCharacterByMovie(IdMovie);
            if (CharacterByMovie == null)
                return NotFound("Personaje no encontrado");

            return Ok(CharacterByMovie);
        }

        
        
    }
}
