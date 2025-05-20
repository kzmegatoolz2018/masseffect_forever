using masseffect_forever.DTO;
using masseffect_forever.Services;
using Microsoft.AspNetCore.Mvc;

namespace masseffect_forever.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlotFlagsController : ControllerBase
    {
        private readonly IPlotFlagService _plotFlagService;

        public PlotFlagsController(IPlotFlagService plotFlagService)
        {
            _plotFlagService = plotFlagService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlotFlagDto>>> GetAllPlotFlags(
            [FromQuery] string? filter, 
            [FromQuery] string? sort)
        {
            var plotFlags = await _plotFlagService.GetAllAsync(filter, sort);
            return Ok(plotFlags);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlotFlagDto>> GetPlotFlag(int id)
        {
            var plotFlag = await _plotFlagService.GetByIdAsync(id);
            if (plotFlag == null)
            {
                return NotFound($"Флаг сюжета с ID {id} не найден");
            }
            return Ok(plotFlag);
        }

        [HttpPost]
        public async Task<ActionResult<PlotFlagDto>> CreatePlotFlag([FromBody] PlotFlagCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdPlotFlag = await _plotFlagService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetPlotFlag), new { id = createdPlotFlag.Id }, createdPlotFlag);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PlotFlagDto>> UpdatePlotFlag(int id, [FromBody] PlotFlagUpdateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedPlotFlag = await _plotFlagService.UpdateAsync(id, dto);
            if (updatedPlotFlag == null)
            {
                return NotFound($"Флаг сюжета с ID {id} не найден");
            }
            
            return Ok(updatedPlotFlag);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePlotFlag(int id)
        {
            var result = await _plotFlagService.DeleteAsync(id);
            if (!result)
            {
                return NotFound($"Флаг сюжета с ID {id} не найден");
            }
            
            return NoContent();
        }
    }
}
