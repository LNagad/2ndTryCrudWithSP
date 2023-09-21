using Intento2Crud.Core.Application.DTO;
using Intento2Crud.Core.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Intento2Crud.Controllers
{
    [Route("api/[controller]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ApiController]
    public class PokemonTypeController : ControllerBase
    {
        private readonly IPokemonTypeService _pokemonTypeService;

        public PokemonTypeController(IPokemonTypeService pokemonTypeService)
        {
            _pokemonTypeService = pokemonTypeService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_pokemonTypeService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok( await _pokemonTypeService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]string name)
        {
            PokemonTypeDTO pokemonType = new() { Name = name };

            await _pokemonTypeService.AddAsync(pokemonType);

            if (pokemonType.Id == 0 || pokemonType.Id == null) return BadRequest(string.Empty);

            return Ok(pokemonType);
        }
        
        [HttpPut]
        public async Task<IActionResult> Update([FromBody]string name, [FromQuery]int id)
        {
            PokemonTypeDTO pokemonType = new() { Name = name };

            await _pokemonTypeService.UpdateAsync(id, pokemonType);

            if (pokemonType.Name != name) return BadRequest(string.Empty);

            return Ok(pokemonType);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool deleted = await _pokemonTypeService.DeleteAsync(id);

            if (!deleted) return BadRequest(string.Empty);

            return Ok();
        }
    }
}
