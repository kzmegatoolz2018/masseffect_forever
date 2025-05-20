using masseffect_forever.DTO;
using masseffect_forever.Services;
using Microsoft.AspNetCore.Mvc;

namespace masseffect_forever.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharactersController : ControllerBase
    {
        private readonly ICharacterService _characterService;
        private readonly IBiographyService _biographyService;
        private readonly IRomanticInterestService _romanticInterestService;

        public CharactersController(
            ICharacterService characterService, 
            IBiographyService biographyService,
            IRomanticInterestService romanticInterestService)
        {
            _characterService = characterService;
            _biographyService = biographyService;
            _romanticInterestService = romanticInterestService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterDto>>> GetAllCharacters(
            [FromQuery] string? filter, 
            [FromQuery] string? sort)
        {
            var characters = await _characterService.GetAllAsync(filter, sort);
            return Ok(characters);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterDto>> GetCharacter(int id)
        {
            var character = await _characterService.GetByIdAsync(id);
            if (character == null)
            {
                return NotFound($"Персонаж с ID {id} не найден");
            }
            return Ok(character);
        }

        [HttpPost]
        public async Task<ActionResult<CharacterDto>> CreateCharacter([FromBody] CharacterCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var characterDto = new CharacterDto
            {
                Name = dto.Name,
                Species = dto.Species,
                Class = dto.Class,
                Gender = dto.Gender,
                Affiliation = dto.Affiliation,
                Status = dto.Status,
                FirstAppearance = dto.FirstAppearance,
                LastAppearance = dto.LastAppearance
            };

            var createdCharacter = await _characterService.CreateAsync(characterDto);
            return CreatedAtAction(nameof(GetCharacter), new { id = createdCharacter.Id }, createdCharacter);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CharacterDto>> UpdateCharacter(int id, [FromBody] CharacterUpdateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var characterDto = new CharacterDto
            {
                Id = id,
                Name = dto.Name,
                Species = dto.Species,
                Class = dto.Class,
                Gender = dto.Gender,
                Affiliation = dto.Affiliation,
                Status = dto.Status,
                FirstAppearance = dto.FirstAppearance,
                LastAppearance = dto.LastAppearance
            };

            var updatedCharacter = await _characterService.UpdateAsync(id, characterDto);
            if (updatedCharacter == null)
            {
                return NotFound($"Персонаж с ID {id} не найден");
            }
            
            return Ok(updatedCharacter);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCharacter(int id)
        {
            var result = await _characterService.DeleteAsync(id);
            if (!result)
            {
                return NotFound($"Персонаж с ID {id} не найден");
            }
            
            return NoContent();
        }

        // Получение биографии персонажа
        [HttpGet("{id}/biography")]
        public async Task<ActionResult<BiographyDto>> GetCharacterBiography(int id)
        {
            var character = await _characterService.GetByIdAsync(id);
            if (character == null)
            {
                return NotFound($"Персонаж с ID {id} не найден");
            }

            var biography = await _biographyService.GetByCharacterIdAsync(id);
            if (biography == null)
            {
                return NotFound($"Биография для персонажа с ID {id} не найдена");
            }

            return Ok(biography);
        }

        // Получение романтических интересов персонажа
        [HttpGet("{id}/romanticinterests")]
        public async Task<ActionResult<IEnumerable<RomanticInterestDto>>> GetCharacterRomanticInterests(int id)
        {
            var character = await _characterService.GetByIdAsync(id);
            if (character == null)
            {
                return NotFound($"Персонаж с ID {id} не найден");
            }

            var romanticInterests = await _romanticInterestService.GetByCharacterIdAsync(id);
            return Ok(romanticInterests);
        }
    }
}
