using System.ComponentModel.DataAnnotations;

namespace masseffect_forever.Models
{
    public class PlotFlag
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; } = string.Empty;
        
        public string Game { get; set; } = string.Empty;
        
        public string Description { get; set; } = string.Empty;
        
        public string Impact { get; set; } = string.Empty;
        
        public bool IsCritical { get; set; }
    }
}
