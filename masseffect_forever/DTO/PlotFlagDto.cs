using System.ComponentModel.DataAnnotations;

namespace masseffect_forever.DTO
{
    public class PlotFlagDto
    {
        public int Id { get; set; }
        
        public string Name { get; set; } = string.Empty;
        
        public string Game { get; set; } = string.Empty;
        
        public string Description { get; set; } = string.Empty;
        
        public string Impact { get; set; } = string.Empty;
        
        public bool IsCritical { get; set; }
    }
    
    public class PlotFlagCreateDto
    {
        [Required(ErrorMessage = "Название флага сюжета обязательно")]
        public string Name { get; set; } = string.Empty;
        
        public string Game { get; set; } = string.Empty;
        
        public string Description { get; set; } = string.Empty;
        
        public string Impact { get; set; } = string.Empty;
        
        public bool IsCritical { get; set; }
    }
    
    public class PlotFlagUpdateDto
    {
        [Required(ErrorMessage = "Название флага сюжета обязательно")]
        public string Name { get; set; } = string.Empty;
        
        public string Game { get; set; } = string.Empty;
        
        public string Description { get; set; } = string.Empty;
        
        public string Impact { get; set; } = string.Empty;
        
        public bool IsCritical { get; set; }
    }
}
