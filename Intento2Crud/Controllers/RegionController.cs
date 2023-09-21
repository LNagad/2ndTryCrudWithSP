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
    public class RegionController : ControllerBase
    {
        private readonly IRegionService _regionService;

        public RegionController(IRegionService regionService)
        {
            _regionService = regionService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_regionService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok( await _regionService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]string name)
        {
            RegionDTO region = new() { Name = name };

            await _regionService.AddAsync(region);

            if (region.Id == 0 || region.Id == null) return BadRequest(string.Empty);

            return Ok(region);
        }
        
        [HttpPut]
        public async Task<IActionResult> Update([FromBody]string name, [FromQuery]int id)
        {
            RegionDTO region = new() { Name = name };

            await _regionService.UpdateAsync(id, region);

            if (region.Name != name) return BadRequest(string.Empty);

            return Ok(region);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool deleted = await _regionService.DeleteAsync(id);

            if (!deleted) return BadRequest(string.Empty);

            return Ok();
        }
    }
}
