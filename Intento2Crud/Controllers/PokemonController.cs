using Intento2Crud.Core.Application.DTO;
using Intento2Crud.Core.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Intento2Crud.Controllers
{
    [Route("api/[controller]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _pokemonService;
        private readonly IPokemonRepository _pokemonRepository;

        public PokemonController(IPokemonRepository pokemonRepository, IPokemonService pokemonService)
        {
    
            _pokemonRepository = pokemonRepository;
            _pokemonService = pokemonService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_pokemonService.GetAll());
        } 
        
        [HttpGet("with-include")]
        public IActionResult GetWithInclude()
        {
            return Ok(_pokemonRepository.GetAllPokemonsWithExcludeAsync());
        }

        [HttpGet("with-include-sp")]
        public IActionResult GetWithIncludeSP()
        {
            return Ok(_pokemonRepository.SPGetAllPokemonsWithIncludeAsync());
        } 
        

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok( await _pokemonService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]PokemonDTO pokemon)
        {
            await _pokemonService.AddAsync(pokemon);

            if (pokemon.Id == 0 || pokemon.Id == null) return BadRequest(string.Empty);

            return Ok(pokemon);
        }
        
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PokemonDTO pokemon, [FromQuery]int id)
        {
            var updatedPokemon = await _pokemonService.UpdateAsync(id, pokemon);

            if (pokemon.Name != updatedPokemon?.Name) return BadRequest(string.Empty);

            return Ok(pokemon);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool deleted = await _pokemonService.DeleteAsync(id);

            if (!deleted) return BadRequest(string.Empty);

            return Ok();
        }
    }
}
