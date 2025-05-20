using masseffect_forever.DTO;
using masseffect_forever.Services;
using Microsoft.AspNetCore.Mvc;

namespace masseffect_forever.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BiographiesController : ControllerBase
    {
        private readonly IBiographyService _biographyService;
        private readonly ICharacterService _characterService;

        public BiographiesController(
            IBiographyService biographyService,
            ICharacterService characterService)
        {
            _biographyService = biographyService;
            _characterService = characterService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BiographyDto>>> GetAllBiographies(
            [FromQuery] string? filter, 
            [FromQuery] string? sort)
        {
            var biographies = await _biographyService.GetAllAsync(filter, sort);
            return Ok(biographies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BiographyDto>> GetBiography(int id)
        {
            var biography = await _biographyService.GetByIdAsync(id);
            if (biography == null)
            {
                return NotFound($"Биография с ID {id} не найдена");
            }
            return Ok(biography);
        }

        [HttpGet("character/{characterId}")]
        public async Task<ActionResult<BiographyDto>> GetBiographyByCharacter(int characterId)
        {
            var character = await _characterService.GetByIdAsync(characterId);
            if (character == null)
            {
                return NotFound($"Персонаж с ID {characterId} не найден");
            }

            var biography = await _biographyService.GetByCharacterIdAsync(characterId);
            if (biography == null)
            {
                return NotFound($"Биография для персонажа с ID {characterId} не найдена");
            }
            
            return Ok(biography);
        }

        [HttpPost]
        public async Task<ActionResult<BiographyDto>> CreateBiography([FromBody] BiographyCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var createdBiography = await _biographyService.CreateAsync(dto);
                return CreatedAtAction(nameof(GetBiography), new { id = createdBiography.Id }, createdBiography);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BiographyDto>> UpdateBiography(int id, [FromBody] BiographyUpdateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedBiography = await _biographyService.UpdateAsync(id, dto);
            if (updatedBiography == null)
            {
                return NotFound($"Биография с ID {id} не найдена");
            }
            
            return Ok(updatedBiography);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBiography(int id)
        {
            var result = await _biographyService.DeleteAsync(id);
            if (!result)
            {
                return NotFound($"Биография с ID {id} не найдена");
            }
            
            return NoContent();
        }
    }
}
