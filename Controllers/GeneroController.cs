using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using peliculasDisney.Data;
using System.Threading.Tasks;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace PeliculasSeries.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GeneroController : ControllerBase
    {
        private readonly IApiRepository _Repocitorio;

        public GeneroController(IApiRepository Repocitorio)
        {
            _Repocitorio= Repocitorio;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var peliculasSeries = await _Repocitorio.GetPeliculaSeriesAsync();
            return Ok(peliculasSeries);
        }
        
    }
}