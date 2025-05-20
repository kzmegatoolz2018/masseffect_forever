using masseffect_forever.DTO;

namespace masseffect_forever.Services
{
    public interface IRomanticInterestService
    {
        Task<IEnumerable<RomanticInterestDto>> GetAllAsync(string? filter, string? sort);
        Task<RomanticInterestDto?> GetByIdAsync(int id);
        Task<IEnumerable<RomanticInterestDto>> GetByCharacterIdAsync(int characterId);
        Task<RomanticInterestDto> CreateAsync(RomanticInterestCreateDto dto);
        Task<RomanticInterestDto?> UpdateAsync(int id, RomanticInterestUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
