using masseffect_forever.DTO;

namespace masseffect_forever.Services
{
    public interface IBiographyService
    {
        Task<IEnumerable<BiographyDto>> GetAllAsync(string? filter, string? sort);
        Task<BiographyDto?> GetByIdAsync(int id);
        Task<BiographyDto?> GetByCharacterIdAsync(int characterId);
        Task<BiographyDto> CreateAsync(BiographyCreateDto dto);
        Task<BiographyDto?> UpdateAsync(int id, BiographyUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
