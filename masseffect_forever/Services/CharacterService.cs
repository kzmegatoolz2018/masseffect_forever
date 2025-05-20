using masseffect_forever.Data;
using masseffect_forever.DTO;
using masseffect_forever.Models;
using Microsoft.EntityFrameworkCore;

namespace masseffect_forever.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly MassEffectContext _context;

        public CharacterService(MassEffectContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CharacterDto>> GetAllAsync(string? filter, string? sort)
        {
            IQueryable<Character> query = _context.Characters
                .Include(c => c.Biography)
                .Include(c => c.RomanticInterests);

            // Применение фильтрации
            if (!string.IsNullOrWhiteSpace(filter))
            {
                filter = filter.ToLower();
                query = query.Where(c => 
                    c.Name.ToLower().Contains(filter) ||
                    c.Species.ToLower().Contains(filter) ||
                    c.Class.ToLower().Contains(filter) ||
                    c.Affiliation.ToLower().Contains(filter) ||
                    c.Status.ToLower().Contains(filter)
                );
            }

            // Применение сортировки
            if (!string.IsNullOrWhiteSpace(sort))
            {
                sort = sort.ToLower();
                query = sort switch
                {
                    "name" => query.OrderBy(c => c.Name),
                    "name_desc" => query.OrderByDescending(c => c.Name),
                    "species" => query.OrderBy(c => c.Species),
                    "species_desc" => query.OrderByDescending(c => c.Species),
                    "class" => query.OrderBy(c => c.Class),
                    "class_desc" => query.OrderByDescending(c => c.Class),
                    "affiliation" => query.OrderBy(c => c.Affiliation),
                    "affiliation_desc" => query.OrderByDescending(c => c.Affiliation),
                    "firstappearance" => query.OrderBy(c => c.FirstAppearance),
                    "firstappearance_desc" => query.OrderByDescending(c => c.FirstAppearance),
                    _ => query.OrderBy(c => c.Id)
                };
            }
            else
            {
                query = query.OrderBy(c => c.Name);
            }

            var characters = await query.ToListAsync();
            
            return characters.Select(MapToDto);
        }

        public async Task<CharacterDto?> GetByIdAsync(int id)
        {
            var character = await _context.Characters
                .Include(c => c.Biography)
                .Include(c => c.RomanticInterests)
                .FirstOrDefaultAsync(c => c.Id == id);

            return character != null ? MapToDto(character) : null;
        }

        public async Task<CharacterDto> CreateAsync(CharacterDto dto)
        {
            var character = new Character
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

            _context.Characters.Add(character);
            await _context.SaveChangesAsync();

            return MapToDto(character);
        }

        public async Task<CharacterDto?> UpdateAsync(int id, CharacterDto dto)
        {
            var character = await _context.Characters.FindAsync(id);
            if (character == null) return null;

            character.Name = dto.Name;
            character.Species = dto.Species;
            character.Class = dto.Class;
            character.Gender = dto.Gender;
            character.Affiliation = dto.Affiliation;
            character.Status = dto.Status;
            character.FirstAppearance = dto.FirstAppearance;
            character.LastAppearance = dto.LastAppearance;

            await _context.SaveChangesAsync();

            return MapToDto(character);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var character = await _context.Characters.FindAsync(id);
            if (character == null) return false;

            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();
            
            return true;
        }

        private static CharacterDto MapToDto(Character character)
        {
            return new CharacterDto
            {
                Id = character.Id,
                Name = character.Name,
                Species = character.Species,
                Class = character.Class,
                Gender = character.Gender,
                Affiliation = character.Affiliation,
                Status = character.Status,
                FirstAppearance = character.FirstAppearance,
                LastAppearance = character.LastAppearance,
                Biography = character.Biography != null ? new BiographyDto
                {
                    Id = character.Biography.Id,
                    CharacterId = character.Biography.CharacterId,
                    Birthplace = character.Biography.Birthplace,
                    Background = character.Biography.Background,
                    PsychologicalProfile = character.Biography.PsychologicalProfile,
                    MilitaryHistory = character.Biography.MilitaryHistory
                } : null,
                RomanticInterests = character.RomanticInterests?.Select(r => new RomanticInterestDto
                {
                    Id = r.Id,
                    CharacterId = r.CharacterId,
                    CharacterName = character.Name,
                    AvailableFor = r.AvailableFor,
                    Game = r.Game,
                    CompatibleChoices = r.CompatibleChoices,
                    RelationshipArc = r.RelationshipArc,
                    IsExclusive = r.IsExclusive
                }).ToList()
            };
        }
    }
}
