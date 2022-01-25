using Microsoft.AspNetCore.Mvc;
using peliculasDisney.Data;
using peliculasDisney.Models;
using System.Threading.Tasks;

namespace PeliculasSeries.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PelisculasSeriesController : Controller
    {
        private readonly IApiRepository _Repository;
        public PelisculasSeriesController(IApiRepository Repository)
        {
            _Repository = Repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var Peliculas = await _Repository.GetPersonajesAsync();
            return Ok(Peliculas);
        }
        
        [HttpPost]
        public async Task<IActionResult> Post(PeliculaSerie PeliculasSerie)
        {
            _Repository.Add(PeliculasSerie);
            if (await _Repository.SaveAll())
                return Ok(PeliculasSerie);

            return BadRequest();
        }



    }
}
