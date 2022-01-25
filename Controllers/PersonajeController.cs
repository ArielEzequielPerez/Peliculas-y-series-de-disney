﻿using Microsoft.AspNetCore.Mvc;
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
    }
}