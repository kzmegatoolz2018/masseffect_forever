using masseffect_forever.DTO;
using masseffect_forever.Services;
using Microsoft.AspNetCore.Mvc;

namespace masseffect_forever.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RomanticInterestsController : ControllerBase
    {
        private readonly IRomanticInterestService _romanticInterestService;
        private readonly ICharacterService _characterService;

        public RomanticInterestsController(
            IRomanticInterestService romanticInterestService,
            ICharacterService characterService)
        {
            _romanticInterestService = romanticInterestService;
            _characterService = characterService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RomanticInterestDto>>> GetAllRomanticInterests(
            [FromQuery] string? filter, 
            [FromQuery] string? sort)
        {
            var romanticInterests = await _romanticInterestService.GetAllAsync(filter, sort);
            return Ok(romanticInterests);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RomanticInterestDto>> GetRomanticInterest(int id)
        {
            var romanticInterest = await _romanticInterestService.GetByIdAsync(id);
            if (romanticInterest == null)
            {
                return NotFound($"Романтический интерес с ID {id} не найден");
            }
            return Ok(romanticInterest);
        }

        [HttpGet("character/{characterId}")]
        public async Task<ActionResult<IEnumerable<RomanticInterestDto>>> GetRomanticInterestsByCharacter(int characterId)
        {
            var character = await _characterService.GetByIdAsync(characterId);
            if (character == null)
            {
                return NotFound($"Персонаж с ID {characterId} не найден");
            }

            var romanticInterests = await _romanticInterestService.GetByCharacterIdAsync(characterId);
            return Ok(romanticInterests);
        }

        [HttpPost]
        public async Task<ActionResult<RomanticInterestDto>> CreateRomanticInterest([FromBody] RomanticInterestCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var createdRomanticInterest = await _romanticInterestService.CreateAsync(dto);
                return CreatedAtAction(nameof(GetRomanticInterest), new { id = createdRomanticInterest.Id }, createdRomanticInterest);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<RomanticInterestDto>> UpdateRomanticInterest(int id, [FromBody] RomanticInterestUpdateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedRomanticInterest = await _romanticInterestService.UpdateAsync(id, dto);
            if (updatedRomanticInterest == null)
            {
                return NotFound($"Романтический интерес с ID {id} не найден");
            }
            
            return Ok(updatedRomanticInterest);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRomanticInterest(int id)
        {
            var result = await _romanticInterestService.DeleteAsync(id);
            if (!result)
            {
                return NotFound($"Романтический интерес с ID {id} не найден");
            }
            
            return NoContent();
        }
    }
}
