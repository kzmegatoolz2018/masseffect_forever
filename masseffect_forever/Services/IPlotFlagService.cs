using masseffect_forever.DTO;

namespace masseffect_forever.Services
{
    public interface IPlotFlagService
    {
        Task<IEnumerable<PlotFlagDto>> GetAllAsync(string? filter, string? sort);
        Task<PlotFlagDto?> GetByIdAsync(int id);
        Task<PlotFlagDto> CreateAsync(PlotFlagCreateDto dto);
        Task<PlotFlagDto?> UpdateAsync(int id, PlotFlagUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
