using masseffect_forever.Data;
using masseffect_forever.DTO;
using masseffect_forever.Models;
using Microsoft.EntityFrameworkCore;

namespace masseffect_forever.Services
{
    public class RomanticInterestService : IRomanticInterestService
    {
        private readonly MassEffectContext _context;

        public RomanticInterestService(MassEffectContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RomanticInterestDto>> GetAllAsync(string? filter, string? sort)
        {
            IQueryable<RomanticInterest> query = _context.RomanticInterests
                .Include(r => r.Character);

            // Фильтрация
            if (!string.IsNullOrWhiteSpace(filter))
            {
                filter = filter.ToLower();
                query = query.Where(r => 
                    r.Character.Name.ToLower().Contains(filter) ||
                    r.AvailableFor.ToLower().Contains(filter) ||
                    r.Game.ToLower().Contains(filter) ||
                    r.CompatibleChoices.ToLower().Contains(filter) ||
                    r.RelationshipArc.ToLower().Contains(filter)
                );
            }

            // Сортировка
            if (!string.IsNullOrWhiteSpace(sort))
            {
                sort = sort.ToLower();
                query = sort switch
                {
                    "character" => query.OrderBy(r => r.Character.Name),
                    "character_desc" => query.OrderByDescending(r => r.Character.Name),
                    "game" => query.OrderBy(r => r.Game),
                    "game_desc" => query.OrderByDescending(r => r.Game),
                    "exclusive" => query.OrderBy(r => r.IsExclusive),
                    "exclusive_desc" => query.OrderByDescending(r => r.IsExclusive),
                    _ => query.OrderBy(r => r.Id)
                };
            }
            else
            {
                query = query.OrderBy(r => r.Character.Name);
            }

            var romanticInterests = await query.ToListAsync();
            
            return romanticInterests.Select(MapToDto);
        }

        public async Task<RomanticInterestDto?> GetByIdAsync(int id)
        {
            var romanticInterest = await _context.RomanticInterests
                .Include(r => r.Character)
                .FirstOrDefaultAsync(r => r.Id == id);
                
            return romanticInterest != null ? MapToDto(romanticInterest) : null;
        }

        public async Task<IEnumerable<RomanticInterestDto>> GetByCharacterIdAsync(int characterId)
        {
            var romanticInterests = await _context.RomanticInterests
                .Include(r => r.Character)
                .Where(r => r.CharacterId == characterId)
                .ToListAsync();
                
            return romanticInterests.Select(MapToDto);
        }

        public async Task<RomanticInterestDto> CreateAsync(RomanticInterestCreateDto dto)
        {
            var character = await _context.Characters.FindAsync(dto.CharacterId);
            if (character == null)
            {
                throw new KeyNotFoundException($"Персонаж с ID {dto.CharacterId} не найден");
            }
            
            var romanticInterest = new RomanticInterest
            {
                CharacterId = dto.CharacterId,
                AvailableFor = dto.AvailableFor,
                Game = dto.Game,
                CompatibleChoices = dto.CompatibleChoices,
                RelationshipArc = dto.RelationshipArc,
                IsExclusive = dto.IsExclusive
            };

            _context.RomanticInterests.Add(romanticInterest);
            await _context.SaveChangesAsync();

            
            await _context.Entry(romanticInterest)
                .Reference(r => r.Character)
                .LoadAsync();

            return MapToDto(romanticInterest);
        }

        public async Task<RomanticInterestDto?> UpdateAsync(int id, RomanticInterestUpdateDto dto)
        {
            var romanticInterest = await _context.RomanticInterests
                .Include(r => r.Character)
                .FirstOrDefaultAsync(r => r.Id == id);
                
            if (romanticInterest == null) return null;

            romanticInterest.AvailableFor = dto.AvailableFor;
            romanticInterest.Game = dto.Game;
            romanticInterest.CompatibleChoices = dto.CompatibleChoices;
            romanticInterest.RelationshipArc = dto.RelationshipArc;
            romanticInterest.IsExclusive = dto.IsExclusive;

            await _context.SaveChangesAsync();

            return MapToDto(romanticInterest);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var romanticInterest = await _context.RomanticInterests.FindAsync(id);
            if (romanticInterest == null) return false;

            _context.RomanticInterests.Remove(romanticInterest);
            await _context.SaveChangesAsync();
            
            return true;
        }

        private static RomanticInterestDto MapToDto(RomanticInterest romanticInterest)
        {
            return new RomanticInterestDto
            {
                Id = romanticInterest.Id,
                CharacterId = romanticInterest.CharacterId,
                CharacterName = romanticInterest.Character?.Name ?? string.Empty,
                AvailableFor = romanticInterest.AvailableFor,
                Game = romanticInterest.Game,
                CompatibleChoices = romanticInterest.CompatibleChoices,
                RelationshipArc = romanticInterest.RelationshipArc,
                IsExclusive = romanticInterest.IsExclusive
            };
        }
    }
}
