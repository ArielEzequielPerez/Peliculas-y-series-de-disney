using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using peliculasDisney.Data;
using peliculasDisney.Models;
using System.Threading.Tasks;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace PeliculasSeries.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GeneroController : ControllerBase
    {
        private readonly IApiRepository _Repository;

        public GeneroController(IApiRepository Repository)
        {
            _Repository= Repository;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            var peliculasSeries = await _Repository.GetPeliculaSeriesAsync();
            return Ok(peliculasSeries);
        }

        [HttpPost("Post")]
        public async Task<IActionResult> Post(Genero Genero)
        {
            _Repository.Add(Genero);
            if (await _Repository.SaveAll())
                return Ok(Genero);

            return BadRequest();
        }
    }
}