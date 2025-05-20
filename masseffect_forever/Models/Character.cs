using System.ComponentModel.DataAnnotations;

namespace masseffect_forever.Models
{
    public class Character
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; } = string.Empty;
        
        public string Species { get; set; } = string.Empty;
        
        public string Class { get; set; } = string.Empty;
        
        public string Gender { get; set; } = string.Empty;
        
        public string Affiliation { get; set; } = string.Empty;
        
        public string Status { get; set; } = string.Empty;
        
        public DateTime? FirstAppearance { get; set; }
        
        public DateTime? LastAppearance { get; set; }
        
        public ICollection<RomanticInterest> RomanticInterests { get; set; } = new List<RomanticInterest>();
        
        public Biography? Biography { get; set; }
    }
}
