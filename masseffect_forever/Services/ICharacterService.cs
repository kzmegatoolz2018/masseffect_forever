using masseffect_forever.DTO;

namespace masseffect_forever.Services
{
    public interface ICharacterService
    {
        Task<IEnumerable<CharacterDto>> GetAllAsync(string? filter, string? sort);
        Task<CharacterDto?> GetByIdAsync(int id);
        Task<CharacterDto> CreateAsync(CharacterDto dto);
        Task<CharacterDto?> UpdateAsync(int id, CharacterDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
