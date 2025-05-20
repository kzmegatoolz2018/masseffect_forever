using masseffect_forever.Data;
using masseffect_forever.DTO;
using masseffect_forever.Models;
using Microsoft.EntityFrameworkCore;

namespace masseffect_forever.Services
{
    public class BiographyService : IBiographyService
    {
        private readonly MassEffectContext _context;

        public BiographyService(MassEffectContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BiographyDto>> GetAllAsync(string? filter, string? sort)
        {
            IQueryable<Biography> query = _context.Biographies
                .Include(b => b.Character);

            // Фильтрация
            if (!string.IsNullOrWhiteSpace(filter))
            {
                filter = filter.ToLower();
                query = query.Where(b => 
                    b.Character.Name.ToLower().Contains(filter) ||
                    b.Birthplace.ToLower().Contains(filter) ||
                    b.Background.ToLower().Contains(filter) ||
                    b.PsychologicalProfile.ToLower().Contains(filter) ||
                    b.MilitaryHistory.ToLower().Contains(filter)
                );
            }

            // Сортировка
            if (!string.IsNullOrWhiteSpace(sort))
            {
                sort = sort.ToLower();
                query = sort switch
                {
                    "character" => query.OrderBy(b => b.Character.Name),
                    "character_desc" => query.OrderByDescending(b => b.Character.Name),
                    "birthplace" => query.OrderBy(b => b.Birthplace),
                    "birthplace_desc" => query.OrderByDescending(b => b.Birthplace),
                    _ => query.OrderBy(b => b.Id)
                };
            }
            else
            {
                query = query.OrderBy(b => b.Character.Name);
            }

            var biographies = await query.ToListAsync();
            
            return biographies.Select(MapToDto);
        }

        public async Task<BiographyDto?> GetByIdAsync(int id)
        {
            var biography = await _context.Biographies
                .Include(b => b.Character)
                .FirstOrDefaultAsync(b => b.Id == id);
                
            return biography != null ? MapToDto(biography) : null;
        }

        public async Task<BiographyDto?> GetByCharacterIdAsync(int characterId)
        {
            var biography = await _context.Biographies
                .Include(b => b.Character)
                .FirstOrDefaultAsync(b => b.CharacterId == characterId);
                
            return biography != null ? MapToDto(biography) : null;
        }

        public async Task<BiographyDto> CreateAsync(BiographyCreateDto dto)
        {
            var character = await _context.Characters.FindAsync(dto.CharacterId);
            if (character == null)
            {
                throw new KeyNotFoundException($"Персонаж с ID {dto.CharacterId} не найден");
            }
            
            // Проверка, что биография для персонажа еще не существует
            var existingBiography = await _context.Biographies
                .FirstOrDefaultAsync(b => b.CharacterId == dto.CharacterId);
                
            if (existingBiography != null)
            {
                throw new InvalidOperationException($"Биография для персонажа с ID {dto.CharacterId} уже существует");
            }
            
            var biography = new Biography
            {
                CharacterId = dto.CharacterId,
                Birthplace = dto.Birthplace,
                Background = dto.Background,
                PsychologicalProfile = dto.PsychologicalProfile,
                MilitaryHistory = dto.MilitaryHistory
            };

            _context.Biographies.Add(biography);
            await _context.SaveChangesAsync();

            // Загружаем Character для корректного маппинга
            await _context.Entry(biography)
                .Reference(b => b.Character)
                .LoadAsync();

            return MapToDto(biography);
        }

        public async Task<BiographyDto?> UpdateAsync(int id, BiographyUpdateDto dto)
        {
            var biography = await _context.Biographies
                .Include(b => b.Character)
                .FirstOrDefaultAsync(b => b.Id == id);
                
            if (biography == null) return null;

            biography.Birthplace = dto.Birthplace;
            biography.Background = dto.Background;
            biography.PsychologicalProfile = dto.PsychologicalProfile;
            biography.MilitaryHistory = dto.MilitaryHistory;

            await _context.SaveChangesAsync();

            return MapToDto(biography);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var biography = await _context.Biographies.FindAsync(id);
            if (biography == null) return false;

            _context.Biographies.Remove(biography);
            await _context.SaveChangesAsync();
            
            return true;
        }

        private static BiographyDto MapToDto(Biography biography)
        {
            return new BiographyDto
            {
                Id = biography.Id,
                CharacterId = biography.CharacterId,
                Birthplace = biography.Birthplace,
                Background = biography.Background,
                PsychologicalProfile = biography.PsychologicalProfile,
                MilitaryHistory = biography.MilitaryHistory
            };
        }
    }
}
