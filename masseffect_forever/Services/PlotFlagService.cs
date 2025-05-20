using masseffect_forever.Data;
using masseffect_forever.DTO;
using masseffect_forever.Models;
using Microsoft.EntityFrameworkCore;

namespace masseffect_forever.Services
{
    public class PlotFlagService : IPlotFlagService
    {
        private readonly MassEffectContext _context;

        public PlotFlagService(MassEffectContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PlotFlagDto>> GetAllAsync(string? filter, string? sort)
        {
            IQueryable<PlotFlag> query = _context.PlotFlags;

            // Фильтрация
            if (!string.IsNullOrWhiteSpace(filter))
            {
                filter = filter.ToLower();
                query = query.Where(p => 
                    p.Name.ToLower().Contains(filter) ||
                    p.Game.ToLower().Contains(filter) ||
                    p.Description.ToLower().Contains(filter) ||
                    p.Impact.ToLower().Contains(filter)
                );
            }

            // Сортировка
            if (!string.IsNullOrWhiteSpace(sort))
            {
                sort = sort.ToLower();
                query = sort switch
                {
                    "name" => query.OrderBy(p => p.Name),
                    "name_desc" => query.OrderByDescending(p => p.Name),
                    "game" => query.OrderBy(p => p.Game),
                    "game_desc" => query.OrderByDescending(p => p.Game),
                    "critical" => query.OrderBy(p => p.IsCritical),
                    "critical_desc" => query.OrderByDescending(p => p.IsCritical),
                    _ => query.OrderBy(p => p.Id)
                };
            }
            else
            {
                query = query.OrderBy(p => p.Game).ThenBy(p => p.Name);
            }

            var plotFlags = await query.ToListAsync();
            
            return plotFlags.Select(MapToDto);
        }

        public async Task<PlotFlagDto?> GetByIdAsync(int id)
        {
            var plotFlag = await _context.PlotFlags.FindAsync(id);
            return plotFlag != null ? MapToDto(plotFlag) : null;
        }

        public async Task<PlotFlagDto> CreateAsync(PlotFlagCreateDto dto)
        {
            var plotFlag = new PlotFlag
            {
                Name = dto.Name,
                Game = dto.Game,
                Description = dto.Description,
                Impact = dto.Impact,
                IsCritical = dto.IsCritical
            };

            _context.PlotFlags.Add(plotFlag);
            await _context.SaveChangesAsync();

            return MapToDto(plotFlag);
        }

        public async Task<PlotFlagDto?> UpdateAsync(int id, PlotFlagUpdateDto dto)
        {
            var plotFlag = await _context.PlotFlags.FindAsync(id);
            if (plotFlag == null) return null;

            plotFlag.Name = dto.Name;
            plotFlag.Game = dto.Game;
            plotFlag.Description = dto.Description;
            plotFlag.Impact = dto.Impact;
            plotFlag.IsCritical = dto.IsCritical;

            await _context.SaveChangesAsync();

            return MapToDto(plotFlag);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var plotFlag = await _context.PlotFlags.FindAsync(id);
            if (plotFlag == null) return false;

            _context.PlotFlags.Remove(plotFlag);
            await _context.SaveChangesAsync();
            
            return true;
        }

        private static PlotFlagDto MapToDto(PlotFlag plotFlag)
        {
            return new PlotFlagDto
            {
                Id = plotFlag.Id,
                Name = plotFlag.Name,
                Game = plotFlag.Game,
                Description = plotFlag.Description,
                Impact = plotFlag.Impact,
                IsCritical = plotFlag.IsCritical
            };
        }
    }
}
